namespace AT05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime dataFormatura = new DateTime(2026, 01, 01);
            DateTime dataAtual = DateTime.Now;

            if (dataAtual == DateTime.MinValue)
            {
                Console.WriteLine("Erro: A data é inválida!");
                return;
            }

            if (dataAtual > DateTime.Now)
            {
                Console.WriteLine("Erro: A data informada não pode ser no futuro!");
                return;
            }
            if (dataAtual > dataFormatura)
            {
                Console.WriteLine("Parabéns! Você já deveria estar formado!");
                return;
            }

            var (anos, meses, dias) = CalcularTempoRestante(dataAtual, dataFormatura);

            Console.WriteLine($"Faltam {anos} anos, {meses} meses e {dias} dias para sua formatura!");

            if ( anos == 0 && meses < 6)
            {
                Console.WriteLine("A reta final chegou! Prepare-se para a formatura!");
            }

        }

        static (int anos, int meses, int dias) CalcularTempoRestante(DateTime dataAtual, DateTime dataFormatura)
        {
            int anos = dataFormatura.Year - dataAtual.Year;
            int meses = dataFormatura.Month - dataAtual.Month;
            int dias = dataFormatura.Day - dataAtual.Day;

            if (meses < 0)
            {
                anos--;
                meses += 12;
            }
            
            if (dias < 0)
            {
                meses--;
                dias += DateTime.DaysInMonth(dataAtual.Year, dataAtual.Month);
            }
            return (anos, meses, dias);
        }
    }
}
