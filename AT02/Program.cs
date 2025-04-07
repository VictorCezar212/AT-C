using System;

namespace AT02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite seu nome completo:");
            string nomeOriginal = Console.ReadLine();

            string nomeCifrado = CifrarNome(nomeOriginal, 2);

            Console.WriteLine("Nome original: " + nomeOriginal);
            Console.WriteLine("Nome cifrado: " + nomeCifrado);
        }

        static string CifrarNome(string nome, int deslocamento)
        {
            char[] caracteres = nome.ToCharArray();

            for (int i = 0; i < caracteres.Length; i++)
            {
                char c = caracteres[i];

                if (!char.IsLetter(c))
                {
                    continue;
                }

                char baseChar = char.IsUpper(c) ? 'A' : 'a';
                c = (char)(baseChar + (c - baseChar + deslocamento) % 26);
                caracteres[i] = c;
            }

            return new string(caracteres);
        }
    }
}