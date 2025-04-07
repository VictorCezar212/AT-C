namespace AT12
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
                        ExibirSubMenuFormatos();
                        string formato = Console.ReadLine();
                        if (int.TryParse(formato, out int formatoEscolhido) && formatoEscolhido >= 1 && formatoEscolhido <= 3)
                        {
                            _contatoServico.ListarContatos(formatoEscolhido);
                        }
                        else
                        {
                            Console.WriteLine("Opção inválida. Exibindo em formato padrão (Texto Puro).");
                            _contatoServico.ListarContatos(3);
                        }
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

        private static void ExibirSubMenuFormatos()
        {
            Console.WriteLine("\nEscolha o formato de exibição:");
            Console.WriteLine("1 - Markdown");
            Console.WriteLine("2 - Tabela");
            Console.WriteLine("3 - Texto Puro");
            Console.Write("Digite sua opção: ");
        }
    }
}
