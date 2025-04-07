using AT11_12;

namespace AT11
{
    internal class Program
    {
        private static readonly ContatoServico _contatoServico = new ContatoServico();

        static void Main(string[] args)
        {
            bool sair = false;

            while (!sair)
            {
                ExibirMenu();
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        _contatoServico.AdicionarContato();
                        break;
                    case "2":
                        _contatoServico.ListarContatos();
                        break;
                    case "3":
                        sair = true;
                        Console.WriteLine("Encerrando programa...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.\n");
                        break;
                }
            }
        }

        private static void ExibirMenu()
        {
            Console.WriteLine("=== Gerenciador de Contatos ===");
            Console.WriteLine("1 - Adicionar novo contato");
            Console.WriteLine("2 - Listar contatos cadastrados");
            Console.WriteLine("3 - Sair");
            Console.Write("Escolha uma opção: ");
        }
    }

}
