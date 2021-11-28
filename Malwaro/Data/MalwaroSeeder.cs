using Malwaro.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Malwaro.Data
{
    public class MalwaroSeeder
    {
        public static async Task Seed(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<MalwaroContext>();

            context.Database.EnsureCreated();

            SeedProdutos(context);

            await SeedRoles(scope);

            await SeedUsers(scope);

            await context.SaveChangesAsync();

        }

        private static async Task SeedRoles(IServiceScope scope)
        {
            var roleMgtService = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleMgtService.RoleExistsAsync(MalwaroRoles.Admin))
                await roleMgtService.CreateAsync(new IdentityRole(MalwaroRoles.Admin));

            if (!await roleMgtService.RoleExistsAsync(MalwaroRoles.Usuario))
                await roleMgtService.CreateAsync(new IdentityRole(MalwaroRoles.Usuario));
        }

        private static void SeedProdutos(MalwaroContext context)
        {
            if (!context.Produto.Any())
            {
                context.Produto.Add(new Produto()
                {
                    Nome = "Processador AMD Ryzen 5 5600G",
                    Descricao = "Processador AMD Ryzen 5 5600G Esteja você jogando os jogos mais recentes, projetando o próximo arranha-céu ou analisando dados científicos, a velocidade sem precedentes dos processadores AMD Ryzen série 5000 G para desktop é imparável. Com os processadores AMD Ryzen para desktop, você está sempre na frente. Gráficos Integrados O processador de desktop AMD Ryzen 5 5600G oferece os gráficos mais rápidos do mundo em um processador de desktop. Jogue os melhores jogos em 1080p suave com + núcleos, 12 threads, impulsione clocks de até 4,4 Ghz, 19 MB de cache total e 7 unidades de computação gráfica de até 1,9 Ghz. As mais novas tecnologias Todos os processadores Ryzen série 5000 vêm com o conjunto completo de tecnologias Ryzen projetadas para elevar o poder de processamento do seu PC, incluindo Precision Boost 2 e Precision Boost Overdrive.",
                    Valor = 1734.90,
                    ProdutoCategoria = ProdutoCategoria.Hardwares,
                    ImageURL = "https://images.kabum.com.br/produtos/fotos/181088/processador-amd-ryzen-5-5600g-3-9ghz-4-4ghz-max-turbo-am4-video-integrado-6-nucleos-100-100000252box_1627588230_gg.jpg",
                });
                context.Produto.Add(new Produto()
                {
                    Nome = "SSD Kingston A400, 480GB, SATA",
                    Descricao = "SSD Kingston A400 480GB Sata Mais confiável e durável A unidade de estado sólido A400 da Kingston aumenta drasticamente a resposta do seu computador com tempos incríveis de inicialização, carregamento e transferência, comparados a discos rígidos mecânicos. Reforçado com uma controladora de última geração para velocidades de leitura e gravação de até 500MB/s e 450MB/s, este SSD é 10x mais rápido do que um disco rígido tradicional para melhor desempenho, resposta ultrarrápida em multitarefas e um computador mais rápido de modo geral. Também mais confiável e durável do que um disco rígido, o A400 é feito com memória Flash. Não há partes móveis, com menor probabilidade de falhas do que um disco rígido mecânico. Também é mais frio e mais silencioso e sua resistência a choques e vibração torna-o ideal para notebooks e outros dispositivos móveis de computação. O A400 está disponível em diversas capacidades de 120GB a 480GB oferecendo todo o espaço que você precisa para aplicativos, vídeos, fotos e outros documentos importantes. Você também pode substituir seu disco rígido ou um SSD menor por uma unidade grande o suficiente para conter todos os seus arquivos. SSD confiável e durável para melhor desempenho do computador e respostas ultrarrápidas em multitarefas. Rápida inicialização, carregamento e transferência de arquivos; Mais confiável e mais durável do que um disco rígido; Diversas capacidades com espaço para aplicativos ou para substituição do disco rígido. Garanta já o seu SSD Kingston A400 480GB Sata no KaBuM!",
                    Valor = 343.90,
                    ProdutoCategoria = ProdutoCategoria.Hardwares,
                    ImageURL = "https://images.kabum.com.br/produtos/fotos/85198/85198_index_gg.jpg",
                });
                context.Produto.Add(new Produto()
                {
                    Nome = "Fonte Corsair RM850x 850W",
                    Descricao = "Como fontes de alimentação totalmente modulares do CORSAIR RMx White Series, foram projetados com componentes de alta qualidade para fornecer energia e certificação 80 PLUS Gold ao PC para operar silenciosamente. Agora disponível em um acabamento branco elegante para realçar o seu setup Uma curvatura da ventoinha garante uma operação silenciosa, com o mínimo de ruído, mesmo com o máximo de carga. O RMx White oferece uma eficiência superior a 90% para reduzir o consumo de energia, o ruído de operação, como temperaturas e sua conta de luz. Ao usar capacitores eletrônicos de alta qualidade, o RM850x oferece o fornecimento de energia sem falhas e a manutenção de um longo prazo que você espera das fontes de alimentação da CORSAIR. Com cargas baixas e mídias, uma ventoinha de resfriamento RM850x não gira até que você precise novamente, usando uma operação praticamente silenciosa. Cabos brancos achatados e completamente modulares garantidos que você apenas conecta os cabos necessários ao funcionamento do seu sistema para manter sua criação organizada e bonita. A CORSAIR oferece uma garantia de dez anos para todas as fontes de alimentação da série RMx, que garante a operação confiável do equipamento em várias montagens de sistema. Se você tiver qualquer tipo de problema durante a instalação ou o uso de uma fonte de alimentação RMx, o serviço global de atendimento ao cliente da CORSAIR está preparado para ajudar.",
                    Valor = 1399.90,
                    ProdutoCategoria = ProdutoCategoria.Hardwares,
                    ImageURL = "https://images.kabum.com.br/produtos/fotos/108080/fonte-corsair-rmx-white-series-850w-80-plus-gold-modular-branca-cp-9020188-ww_1575462079_gg.jpg",
                });

                context.Produto.Add(new Produto()
                {
                    Nome = "Jogo GTA V Premium Online Edition - PS4",
                    Descricao = "GTA V Premium Online Edition PS4 GRAND THEFT AUTO V! Entre nas vidas de três criminosos muito diferentes, Michael, Franklin e Trevor, enquanto eles arriscam tudo em uma série de assaltos ousados que podem garantir o resto de suas vidas. Explore o deslumbrante mundo de Los Santos e Blaine County na experiência definitiva de Grand Theft Auto V, apresentando amplas atualizações e melhorias técnicas tanto para jogadores novos quanto para os que estão retornando. Além de distâncias maiores de renderização e melhor resolução, os jogadores podem esperar diversas adições e melhorias. O Grand Theft Auto V Premium Edition Inclui o Modo História completo do Grand Theft Auto V, acesso gratuito ao mundo em constante evolução do Grand Theft Auto Online e todo o conteúdo e melhorias de jogo já lançados, incluindo O Golpe do Juízo Final, Tráfico de Armas, Acima da Lei, Motoqueiros e muito mais. Você também recebe o Kit Inicial de Esquema Criminal, a maneira mais rápida de começar seu império do crime no Grand Theft Auto Online. Garanta o seu no KaBuM!",
                    Valor = 129.90,
                    ProdutoCategoria = ProdutoCategoria.Jogos,
                    ImageURL = "https://images.kabum.com.br/produtos/fotos/96697/96697_1526474799_index_gg.jpg",
                });
                context.Produto.Add(new Produto()
                {
                    Nome = "Jogo The Last Of Us Part II - PS4",
                    Descricao = "Cinco anos depois da jornada perigosa pelos Estados Unidos pós-pandêmicos, Ellie e Joel se estabelecem em Jackson, Wyoming. A vida em uma próspera comunidade de sobreviventes lhes trouxe paz e estabilidade, apesar da ameaça constante dos infectados e de outros sobreviventes mais desesperados. Quando um evento violento interrompe essa paz, Ellie embarca em uma jornada implacável para fazer justiça e encontrar uma solução. Enquanto vai atrás de cada um dos responsáveis, ela se confronta com as repercussões físicas e emocionais devastadoras de suas ações. Uma história complexa e emocionante. Vivencie os conflitos morais cada vez maiores criados pela busca implacável de Ellie por vingança. O ciclo de violência deixado em seu caminho desafiará suas noções de certo ou errado, bem ou mal e herói ou vilão. Um mundo belo, mas perigoso. Embarque na jornada de Ellie, levando-a das montanhas e florestas tranquilas de Jackson até as ruínas exuberantes e cobertas pela vegetação da área metropolitana de Seattle. Encontre novos grupos de sobreviventes, ambientes desconhecidos e traiçoeiros e evoluções terríveis dos infectados. Criados pela versão mais recente do mecanismo da Naughty Dog, o mundo e os personagens mortais estão mais realistas e meticulosamente detalhados do que nunca. Partida tensa e alucinante de ação e sobrevivência. Os sistemas de partida novos e avançados atendem aos desafios de vida ou morte da jornada de Ellie por um mundo hostil. Vivencie sua batalha alucinante pela sobrevivência através de recursos aprimorados como combate corpo a corpo de alta intensidade, movimento fluido e ações furtivas dinâmicas. Uma ampla variedade de armas, itens de criação, habilidades e atualizações possibilitam que você personalize as habilidades de Ellie de acordo com seu estilo de jogo.",
                    Valor = 196.44,
                    ProdutoCategoria = ProdutoCategoria.Jogos,
                    ImageURL = "https://images.kabum.com.br/produtos/fotos/107331/game-the-last-of-us-part-ii-ps4_1572466029_gg.jpg",
                }); context.Produto.Add(new Produto()
                {
                    Nome = "Jogo Red Dead Redemption 2 - PS4",
                    Descricao = "",
                    Valor = 129.90,
                    ProdutoCategoria = ProdutoCategoria.Jogos,
                    ImageURL = "https://images.kabum.com.br/produtos/fotos/98091/98091_1534880178_index_gg.jpg",
                });

                context.Produto.Add(new Produto()
                {
                    Nome = "Kaspersky Total Security",
                    Descricao = "Sua família é muito importante. Dê a eles a nossa melhor proteção. O Kaspersky Total Security ajuda a proteger sua família enquanto vocês navegam pela Internet, fazem compras, usam as redes sociais ou fazem streaming. Além disso, a proteção extra de privacidade armazena com segurança suas senhas e documentos importantes, protege arquivos e lembranças preciosas e ajuda a proteger as crianças dos perigos digitais.",
                    Valor = 29.90,
                    ProdutoCategoria = ProdutoCategoria.Softwares,
                    ImageURL = "https://images.kabum.com.br/produtos/fotos/170034/kaspersky-antivirus-total-security-2020-multidispositivos-1-pc-digital-para-download_1627931538_gg.jpg",
                });
                context.Produto.Add(new Produto()
                {
                    Nome = "Microsoft Office Home & Business",
                    Descricao = "Microsoft Office Home e Business 2019 ajuda você a fazer o seu melhor trabalho em qualquer lugar e a qualquer momento. As novas e modernas versões dos aplicativos clássicos foram construídas para máxima produtividade.",
                    Valor = 999.90,
                    ProdutoCategoria = ProdutoCategoria.Softwares,
                    ImageURL = "https://images.kabum.com.br/produtos/fotos/170094/microsoft-office-home-business-2019-esd-t5d-03191-digital-para-download_1625085129_gg.jpg",
                }); context.Produto.Add(new Produto()
                {
                    Nome = "Microsoft Windows 10 Pro",
                    Descricao = "O melhor Windows de todos os tempos. Simplesmente perfeito, o Windows 10 combina o Windows que você já conhece e adiciona excelentes aperfeiçoamentos que você vai adorar.",
                    Valor = 1396.90,
                    ProdutoCategoria = ProdutoCategoria.Softwares,
                    ImageURL = "https://images.kabum.com.br/produtos/fotos/168394/microsoft-windows-10-pro-32-64-bits-esd-fqc-09131-digital-para-download_1628089119_gg.jpg",
                });

                context.Produto.Add(new Produto()
                {
                    Nome = "Headset Gamer Razer Kraken Ultimate",
                    Descricao = "Um Fone de ouvido Gamer para PC desenvolvido para a melhor experiência competitiva em jogos. Com as ameaças à sua volta, é hora de atacar e avisar quem está caçando quem.",
                    Valor = 899.90,
                    ProdutoCategoria = ProdutoCategoria.Perifericos,
                    ImageURL = "https://images.kabum.com.br/produtos/fotos/110161/headset-gamer-razer-kraken-ultimate-chroma-usb-drivers-50mm-rz04-03180100-r3u1_1602677445_gg.jpg",
                });
                context.Produto.Add(new Produto()
                {
                    Nome = "Teclado Mecânico Gamer HyperX Alloy Origins Core",
                    Descricao = "O HyperX Alloy Origins Core é um teclado ultracompacto e resistente com switches exclusivos HyperX projetados para proporcionar aos gamers a melhor combinação de estilo, desempenho e confiabilidade. Os switches possuem LEDs aparentes para uma iluminação deslumbrante com uma pressão de atuação e distância de curso elegantemente equilibradas para melhor resposta e precisão. O Alloy Origins Core possui uma estrutura totalmente em alumínio para estabilidade, três níveis de inclinação customizáveis em um formato elegante. O design compacto TKL (Ten Key Less), sem o teclado numérico, ajuda a aumentar o espaço para movimentos do mouse em setups com espaço limitado, o cabo dele é USB tipo-C removível para máxima portabilidade.",
                    Valor = 549,
                    ProdutoCategoria = ProdutoCategoria.Perifericos,
                    ImageURL = "https://images.kabum.com.br/produtos/fotos/105009/teclado-mecanico-gamer-hyperx-alloy-origins-core-rgb-hx-kb7rdx-br_1574693479_gg.jpg",
                });
                context.Produto.Add(new Produto()
                {
                    Nome = "Gabinete NOX INFINITY DELTA + Kit 3 Cooler",
                    Descricao = "O Nox Infinity Delta é uma torre média com excelentes acabamentos e um inovador design ARGB Rainbow . Na parte frontal estão incluídas duas tiras sutis de LED que irão deliciar todos os jogadores. Seu painel lateral de acrílico também permite contemplar a imensidão do interior do seu interior. O Nox Infinity Delta incorpora as portas essenciais em seu painel frontal, facilitando o acesso. Nesta parte do gabinete você também encontrará uma porta USB 3.0 de alta velocidade e duas portas USB 2.0 . Junto com essas portas USB estão as conexões de áudio , bem como o controle que regula a iluminação ARGB. Esta é uma caixa para PC que permite criar uma configuração de alto desempenho , tornando-a uma escolha perfeita para jogos ou computadores profissionais , graças a um amplo espaço interno que permite a montagem de placas gráficas de até 315 mm de comprimento. como cooler para CPU com altura máxima de 154 mm. ",
                    Valor = 449.90,
                    ProdutoCategoria = ProdutoCategoria.Perifericos,
                    ImageURL = "https://images.kabum.com.br/produtos/fotos/262906/gabinete-nox-infinity-delta-kit-3-cooler-fan-apexgaming-a-cool-series-360mm-rgb_1636036657_gg.jpg",
                });
            }
        }

        public static async Task SeedUsers(IServiceScope scope)
        {
            var userMgtService = scope.ServiceProvider.GetRequiredService<UserManager<Usuario>>();

            string adminMail = "admin@example.com";
            string userMail = "user@example.com";

            Usuario admin = await userMgtService.FindByEmailAsync(adminMail);
            Usuario user = await userMgtService.FindByEmailAsync(userMail);

            if (admin == null)
            {
                admin = new Usuario()
                {
                    Nome = "Administrador",
                    Sobrenome = "Malwaro",
                    DataNascimento = new DateTime(1995, 01, 01),
                    CPF = "162.163.456-64",
                    Email = adminMail,
                    EmailConfirmed = true,
                    UserName="admin",
                    EnderecoBairro = "Coroadinho",
                    EnderecoCEP = "65040-655",
                    EnderecoCidade = "São Luís",
                    EnderecoComplemento = "Casa",
                    EnderecoNumero = 194,
                    EnderecoRua = "Rua Primeiro de Novembro",
                    EnderecoUF = UsuarioEnderecoUF.MA,
                };
                await userMgtService.CreateAsync(admin, "abc123");
                await userMgtService.AddToRoleAsync(admin, MalwaroRoles.Admin);
            }

            if (user == null)
            {
                user = new Usuario()
                {
                    Nome = "Márcio",
                    Sobrenome = "Giovanni da Mota",
                    DataNascimento = new DateTime(2002, 07, 23),
                    CPF = "688.583.827-65",
                    Email = userMail,
                    EmailConfirmed = true,
                    UserName = "user",
                    EnderecoBairro = "Condomínio Residencial Montreal",
                    EnderecoCEP = "13563-784",
                    EnderecoCidade = "São Paulo",
                    EnderecoComplemento = "Condomínio",
                    EnderecoNumero = 450,
                    EnderecoRua = "Vila de Acesso 3",
                    EnderecoUF = UsuarioEnderecoUF.SP,
                };
                await userMgtService.CreateAsync(user, "abc123");
                await userMgtService.AddToRoleAsync(user, MalwaroRoles.Usuario);
            }





        }
    }
}
