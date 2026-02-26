using Malwaro.Data;
using Malwaro.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Malwaro.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signinManager;
        private readonly MalwaroContext _context;
        public UsuariosController(UserManager<Usuario> userManager, SignInManager<Usuario> signinManager, MalwaroContext context)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _context = context;
        }

        public IActionResult Login() => View(new UsuarioViewModel());

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioViewModel usuariovm)
        {
            if (!ModelState.IsValid) return View(usuariovm);

            Usuario usuario = await _userManager.FindByEmailAsync(usuariovm.EmailAddress);

            if (usuario != null)
            {
                var passCheck = await _userManager.CheckPasswordAsync(usuario, usuariovm.Password);

                if (passCheck)
                {
                    var login = await _signinManager.PasswordSignInAsync(usuario, usuariovm.Password, false, false);
                    if (login.Succeeded)
                    {
                        return RedirectToAction("Catalog", "Produtos");
                    }
                }
            }

            TempData["LoginError"] = "Email e/ou senha inválidos. Tente novamente.";
            return View(usuariovm);
        }

        public IActionResult Create() => View(new NovoUsuarioViewModel());

        [HttpPost]
        public async Task<IActionResult> Create(NovoUsuarioViewModel usuariovm)
        {
            if (!ModelState.IsValid) return View(usuariovm);

            Usuario usuario = await _userManager.FindByEmailAsync(usuariovm.EmailAddress);


            if (usuario != null)
            {
                TempData["CreateError"] = "Este endereço de email  já está em uso.";
                return View(usuariovm);
            }


            usuario = new()
            {
                Nome = usuariovm.Nome,
                Sobrenome = usuariovm.Sobrenome,
                Email = usuariovm.EmailAddress,
                UserName = usuariovm.Nome,
                EmailConfirmed = true,
                CPF = usuariovm.CPF,
                DataNascimento = usuariovm.DataNascimento,
                EnderecoBairro = usuariovm.EnderecoBairro,
                EnderecoCEP = usuariovm.EnderecoCEP,
                EnderecoCidade = usuariovm.EnderecoCidade,
                EnderecoRua = usuariovm.EnderecoRua,
                EnderecoComplemento = usuariovm.EnderecoComplemento,
                EnderecoNumero = usuariovm.EnderecoNumero,
                EnderecoUF = usuariovm.EnderecoUF,
            };

            var signup = await _userManager.CreateAsync(usuario, usuariovm.Password);

            if (!signup.Succeeded)
            {
                TempData["CreateError"] = "Senha muito fácil. (Usar ao menos 6 caracteres minúsculos e digitos)";
                return View(usuariovm);
            }

            await _userManager.AddToRoleAsync(usuario, MalwaroRoles.Usuario);

            TempData["LoginSuccess"] = "Conta criada com sucesso.";
            return View("Login", new UsuarioViewModel() { EmailAddress = usuariovm.EmailAddress });

        }

        [HttpPost]
        public async Task<IActionResult> Logout() {
            await _signinManager.SignOutAsync();
            return RedirectToAction("Catalog", "Produtos");
        }
    }
}
