namespace AT09
{
    internal class Program
    {
        static string caminhoArquivo = "estoque.txt";
        static void Main(string[] args)
        {
            while(true)
            {
                ExibirMenu();
                string escolha = Console.ReadLine();

                switch(escolha)
                {
                    case "1":
                        InserirProduto();
                        break;
                    case "2":
                        ListarProdutos();
                        break;
                    case "3":
                        Console.WriteLine("Saindo do sistema...");
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
            if (GetQuantidadeProdutos() >= 5 )
            {
                Console.WriteLine("Limite de produtos atingido");
                Console.ReadLine();
                return;
            }

            string nomeProduto = ObterInput("Digite o nome do produto: ");
            int quantidade = ObterNumeroPositivo("Digite a quantidade em estoque: ");
            decimal preco = ObterDecimalPositivo("Digite o preço unitário: ");

            GravarProduto(nomeProduto, quantidade, preco);
            Console.WriteLine($"Produto '{nomeProduto}' inserido com sucesso!");
            Console.ReadLine();
        }

        static void ListarProdutos()
        {
            var produtos = LerProdutos();

            if (produtos.Any())
            {
                Console.WriteLine("Produtos Cadastrados: ");
                foreach (var produto in produtos)
                {
                    Console.WriteLine($"Produto: {produto.Nome} | Quantidade: {produto.Quantidade} | Preço: R$ {produto.Preco:F2}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum produto cadastrado.");
            }

            Console.ReadLine();
        }

        static Produto[] LerProdutos()
        {
            if(!File.Exists(caminhoArquivo))
            {
                return new Produto[0];
            }

            var linhas = File.ReadAllLines(caminhoArquivo);
            return linhas.Select(linha =>
            {
                var partes = linha.Split(',');
                return new Produto
                {
                    Nome = partes[0],
                    Quantidade = int.Parse(partes[1]),
                    Preco = decimal.Parse(partes[2])
                };
            }).ToArray();
        }

        static void GravarProduto(string nome, int quantidade, decimal preco)
        {
            using (StreamWriter sw = File.AppendText(caminhoArquivo))
            {
                sw.WriteLine($"{nome},{quantidade},{preco:F2}");
            }
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


        static int GetQuantidadeProdutos()
        {
            return File.Exists(caminhoArquivo) ? File.ReadAllLines(caminhoArquivo).Length : 0;
        }
    }

    class Produto
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
    }

}

