namespace AT10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var jogo = new JogoAdivinhacao();
            jogo.Iniciar();

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
