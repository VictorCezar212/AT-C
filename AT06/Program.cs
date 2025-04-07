namespace AT06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Aluno meuAluno = new Aluno
            {
                Nome = "Victor Cezar",
                Matricula = "20240701",
                Curso = "Ciência de Dados",
                MediaNotas = 8.5
            };

            meuAluno.ExibirDados();

            Console.WriteLine($"Situação: {meuAluno.VerificarAprovacao()}");
        }
    }
}
