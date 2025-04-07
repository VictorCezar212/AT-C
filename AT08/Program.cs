namespace AT08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var funcionario = new Funcionario("João Silva", "Analista", 5000m);
            var gerente = new Gerente("Maria Souza", 8000m);

            Console.WriteLine($"Funcionário: {funcionario.Nome} - Salário: {funcionario.CalcularSalario()}");
            Console.WriteLine($"Gerente: {gerente.Nome} - Salário: {gerente.CalcularSalario()}");
        }
    }
}
