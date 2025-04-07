namespace AT07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContaBancaria conta = new ContaBancaria();
            conta.Titular = "João Silva";

            Console.WriteLine($"Titular: {conta.Titular}\n");

            conta.Depositar(500);
            conta.ExibirSaldo();

            Console.WriteLine();

            conta.Sacar(700);//Erro demonstrar
            conta.Sacar(200);
            conta.ExibirSaldo();
        }
    }
}
