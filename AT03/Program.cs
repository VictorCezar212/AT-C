namespace AT03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1 = ObterNumeroValido("Digite o primeiro número: ");
            double num2 = ObterNumeroValido("Digite o segundo número: ");

            int opcao = ObterOperacaoValida();

            double resultado = ExecutarOperacao(num1, num2, opcao);

            ExibirResultado(resultado, opcao);
        }

        static double ObterNumeroValido(string mensagem)
        {
            double numero;
            while(true)
            {
                Console.WriteLine(mensagem);
                string entrada = Console.ReadLine();

                if (double.TryParse(entrada, out numero))
                    return numero;
                else
                    Console.WriteLine("Entrada inválida. Por favor, insira um número válido.");
            }
        }

        static int ObterOperacaoValida()
        {
            int opcao;
            while (true)
            {
                Console.WriteLine("\nEscolha a operação desejada:");
                Console.WriteLine("1. Soma");
                Console.WriteLine("2. Subtração");
                Console.WriteLine("3. Multiplicação");
                Console.WriteLine("4. Divisão");

                string entrada = Console.ReadLine();

                if (int.TryParse(entrada, out opcao) && opcao >= 1 && opcao <= 4)
                    return opcao;
                else
                    Console.WriteLine("Opção inválida. Por favor, escolha uma operação entre 1 e 4");
            }
        }

        static double ExecutarOperacao(double num1, double num2, int opcao)
        {
            switch (opcao)
            {
                case 1:
                    return num1 + num2;
                case 2:
                    return num1 - num2;
                case 3:
                    return num1 * num2;
                case 4:
                    if (num2 == 0)
                    {
                        Console.WriteLine("\nErro: Não é possível dividir por zero.");
                        return double.NaN;
                    }
                    return num1 / num2;
                default:
                    return double.NaN;
            }
        }

        static void ExibirResultado(double resultado, int opcao)
        {
            if (resultado != double.NaN)
            {
                string operacao = opcao switch
                {
                    1 => "Soma",
                    2 => "Subtração",
                    3 => "Multiplicação",
                    4 => "Divisão",
                    _ => "Operação desconhecida"
                };
                Console.WriteLine($"\nResultado da {operacao}: {resultado}");
            }
        }
    }
}
