namespace AT09
{
    internal class Program
    {
        static Produto[] produtos = new Produto[5];
        static int quantidadeProdutos = 0;
        static void Main(string[] args)
        {
            while (true)
            {
                ExibirMenu();
                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        InserirProduto();
                        break;
                    case "2":
                        ListarProdutos();
                        break;
                    case "3":
                        Console.WriteLine("Saindo do Sistema...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente!");
                        break;
                }
            }
        }

        static void ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("===== Sistema de Gerenciamento de Estoque =====");
            Console.WriteLine("1. Inserir Produto");
            Console.WriteLine("2. Listar Produtos");
            Console.WriteLine("3. Sair");
            Console.Write("Escolha uma opção: ");
        }

        static void InserirProduto()
        {
            if (quantidadeProdutos >= 5)
            {
                Console.WriteLine("Limite de produtos atingido");
                Console.ReadLine();
                return;
            }

            string nomeProduto = ObterInput("Digite o nome do produto: ");
            int quantidade = ObterNumeroPositivo("Digite a quantidade em estoque: ");
            decimal preco = ObterDecimalPositivo("Digite o preço unitário: ");

            produtos[quantidadeProdutos] = new Produto
            {
                Nome = nomeProduto,
                Quantidade = quantidade,
                Preco = preco
            };

            quantidadeProdutos++;

            Console.WriteLine($"Produto '{nomeProduto}' inserido com sucesso!");
            Console.ReadLine();
        }

        static void ListarProdutos()
        {
            if (quantidadeProdutos > 0)
            {
                Console.WriteLine("Produtos Cadastrados: ");
                for (int i = 0; i < quantidadeProdutos; i++)
                {
                    Console.WriteLine($"Produto: {produtos[i].Nome} | Quantidade: {produtos[i].Quantidade} | Preço: R$ {produtos[i].Preco:F2}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum produto cadastrado.");
            }

            Console.ReadLine();
        }

        static int ObterNumeroPositivo(string mensagem)
        {
            int numero;
            do
            {
                Console.Write(mensagem);
            } while (!int.TryParse(Console.ReadLine(), out numero) || numero <= 0);

            return numero;
        }

        static decimal ObterDecimalPositivo(string mensagem)
        {
            decimal numero;
            do
            {
                Console.Write(mensagem);
            } while (!decimal.TryParse(Console.ReadLine(), out numero) || numero <= 0);

            return numero;
        }

        static string ObterInput(string mensagem)
        {
            Console.Write(mensagem);
            return Console.ReadLine();
        }
    }

    class Produto
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
    }

}

