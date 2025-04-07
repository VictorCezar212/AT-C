namespace AT04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime dataNascimento = ObterDataNascimento();

            int diasFaltando = CalcularDiasParaProximoAniversario(dataNascimento);

            ExibirResultado(diasFaltando);
        }

        static DateTime ObterDataNascimento()
        {
            DateTime dataNascimento;
            while (true)
            {
                Console.WriteLine("Digite sua data de nascimento (formato: dd/MM/yyyy):");
                string entrada = Console.ReadLine();

                if (DateTime.TryParseExact(entrada, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataNascimento))
                    return dataNascimento;
                Console.WriteLine("Data inválida. Por Favor, insira a data no formato correto.");
            }
        }

        static int CalcularDiasParaProximoAniversario(DateTime dataNascimento)
        {
            DateTime dataAtual = DateTime.Today;

            DateTime proximoAniversario = new DateTime(dataAtual.Year, dataNascimento.Month, dataNascimento.Day);

            if (proximoAniversario < dataAtual)
            {
                proximoAniversario = proximoAniversario.AddYears(1);
            }

            return (proximoAniversario - dataAtual).Days;
        }

        static void ExibirResultado(int diasFaltando)
        {
            if (diasFaltando < 7)
            {
                Console.WriteLine($"\nFaltam apenas {diasFaltando} dias para o seu próximo aniversario! Que otimo Parabens!!!!");
            }
            else
            {
                Console.WriteLine($"\nFaltam {diasFaltando} dias para o seu próximo aniversário.");
            }
        }
    }
}
