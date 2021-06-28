using AgendaRepositorio;
using ClassAgenda;
using Newtonsoft.Json;
using System;
using System.Linq;



namespace ConsoleAmigo
{
    class Program
    {
        private static IAgendaRepositorio RepositorioAmigo = new AgendaRepositorio.AgendaRepositorio();
        static void Main(string[] args)
        {
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-= | Agenda de Amigos | -=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");

            var sair = false;

            while (!sair)
            {

                ExibirOpcoes();
                var opcoesagenda = Console.ReadLine();

                switch (opcoesagenda)
                {
                    case "1":
                        AddAmigo();
                        break;
                    case "2":
                        AtualizarAmigo();
                        break;
                    case "3":
                        ExcluirAmigo();
                        break;
                    case "4":
                        InfoAmigo();
                        break;
                    case "5":
                        ListarAgenda();
                        break;
                    case "6":
                        Aniversariantes();
                        break;
                    case "9":
                        InfoCRUD();
                        break;
                    case "q":
                        Console.WriteLine("Até Logo :)");
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção Invalida!");
                        break;
                }
            }


        }

        
        private static void Aniversariantes()
        {
            Console.WriteLine("Exibindo Amigos que fazem aniversário hoje:");
            Console.WriteLine("");
            var aniversariantes = RepositorioAmigo.GetAll().Where(a => a.Aniversario.Day == DateTime.Now.Day && a.Aniversario.Month == DateTime.Now.Month);
            Console.WriteLine(JsonConvert.SerializeObject(aniversariantes, Formatting.Indented));
            Console.WriteLine("");
        }
        

        private static void ListarAgenda()
        {
            Console.WriteLine("Exibindo Amigos");
            Console.WriteLine("");
            var amigo = RepositorioAmigo.GetAll();
            Console.WriteLine(JsonConvert.SerializeObject(amigo, Formatting.Indented));
            Console.WriteLine("");
            Console.WriteLine("");
        }

        private static void InfoAmigo()
        {
            Console.WriteLine("");
            Console.WriteLine("Digite o número ID/SKU do Amigo");

            var id = Convert.ToInt32(Console.ReadLine());
            var amigox = RepositorioAmigo.GetAmigoById(id);

            Console.WriteLine("");
            Console.WriteLine($"Exibindo Amigo com o ID/SKU: {id}");
            Console.WriteLine("");
            Console.WriteLine(JsonConvert.SerializeObject(amigox, Formatting.Indented));
            Console.WriteLine("");
            Console.WriteLine("");
        }

        private static void ExcluirAmigo()
        {
            Console.WriteLine("");
            Console.WriteLine("Digite o ID/SKU do Amigo para realizar a exclusão");

            var id = Convert.ToInt32(Console.ReadLine());

            var amigo = RepositorioAmigo.GetAmigoById(id);

            if (amigo == null)
                Console.WriteLine("Amigo não encontrado!");
            else
            {
                RepositorioAmigo.DeleteAmigo(id);
                Console.WriteLine("Amigo excluido com sucesso!");
            }

        }

        private static void AtualizarAmigo()
        {
            Console.WriteLine("");
            Console.WriteLine("Digite o identificado do cliente");

            var id = Convert.ToInt32(Console.ReadLine());
            var amigo = RepositorioAmigo.GetAmigoById(id);

            if (amigo == null)
            {
                Console.WriteLine("Amigo não encontrado");
            }
            else
            {
                Console.WriteLine("Informe o nome do Amigo:");
                amigo.Nome = Console.ReadLine();

                Console.WriteLine("Informe o Sobrenome do Amigo:");
                amigo.SobreNome = Console.ReadLine();

                Console.WriteLine("Informe o Aniversário do Amigo:");
                amigo.Aniversario = Convert.ToDateTime(Console.ReadLine());

                RepositorioAmigo.UpdateAmigo(amigo, id);

                Console.WriteLine("As informações do Amigo foram atualizadas com sucesso!");
            }
        }

        private static void AddAmigo()
        {
            var amigo = new Amigo();

            Console.WriteLine("Informe o Nome do Amigo:");
            amigo.Nome = Console.ReadLine();

            Console.WriteLine("Informe o Sobrenome do Amigo:");
            amigo.SobreNome = Console.ReadLine();

            Console.WriteLine("Informe o Aniversario:");
            amigo.Aniversario = Convert.ToDateTime(Console.ReadLine());

            RepositorioAmigo.InsertAmigo(amigo);

            Console.WriteLine("Amigo registrado com sucesso!");
        }

        private static void ExibirOpcoes()
        {
            Console.WriteLine("");
            Console.WriteLine("Selecione as opções:");
            Console.WriteLine("1 - Para Adicionar um Amigo na Agenda");
            Console.WriteLine("2 - Para Editar um Amigo na Agenda");
            Console.WriteLine("3 - Para Excluir um Amigo na Agenda");
            Console.WriteLine("4 - Para obter Informações de um Amigo na Agenda");
            Console.WriteLine("5 - Para Exibir toda a Agenda");
            Console.WriteLine("6 - Para Listar Amigos que fazem aniversário hoje");
            Console.WriteLine("9 - Para mais informações");
            Console.WriteLine("q - Para sair");
            Console.WriteLine("");
        }

        private static void InfoCRUD()
        {
            Console.WriteLine("");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("-=-=-=-=-=-= ¨ AT - Agenda de Amigos © 2021 ¨ -=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-= # Instituto Infnet # -=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("-=-=-=-=-=-=| Análise e Desenvolvimento de Sistemas |-=-=-=-=-=-=-=-");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("=-=-=-=-=-=-=-=-=¨ Eric Fagundes Guimarães ¨-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("=-=-=-=-=-=| Fundamentos de Desenvolvimento com C# |=-=-=-=-=-=-=-=-");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-| 27/06/2021 - Rio de Janeiro |-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-# Professor - Rafael Cruz #-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("");
        }
    }
}
