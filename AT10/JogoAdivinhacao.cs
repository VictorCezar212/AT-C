using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT10
{
    class JogoAdivinhacao
    {
        private const int MinNumero = 1;
        private const int MaxNumero = 50;
        private const int MaxTentativas = 5;

        private readonly int numeroSecreto;
        private int tentativasRestantes;

        public JogoAdivinhacao()
        {
            var random = new Random();
            numeroSecreto = random.Next(MinNumero, MaxNumero + 1);
            tentativasRestantes = MaxTentativas;
        }

        public void Iniciar()
        {
            Console.WriteLine($"Bem-vindo ao jogo de adivinhação! Tente acertar um número entre {MinNumero} e {MaxNumero}.");
            Console.WriteLine($"Você tem {MaxTentativas} tentativas. Boa sorte!\n");

            while (tentativasRestantes > 0)
            {
                Console.WriteLine($"Tentativa {MaxTentativas - tentativasRestantes + 1} de {MaxTentativas}");
                Console.WriteLine("Digite seu palpite:");

                try
                {
                    int palpite = ObterPalpiteValido();
                    
                    if(palpite == numeroSecreto)
                    {
                        Console.WriteLine($"\nnParabéns! Você acertou o número secreto {numeroSecreto}!");
                        return;
                    }

                    tentativasRestantes--;

                    if (tentativasRestantes > 0)
                    {
                        string dica = palpite < numeroSecreto ? "maior" : "menor";
                        Console.WriteLine($"Errou! O número secreto é {dica} que {palpite}.");
                        Console.WriteLine($"Você ainda tem {tentativasRestantes} tentativa(s).\n");
                    }
                }
                
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}\n");
                }
            }

            Console.WriteLine($"\nGame Over! Você esgotou todas as tentativas. O número secreto era {numeroSecreto}.");
        }

        private int ObterPalpiteValido()
        {
            if(!int.TryParse(Console.ReadLine(), out int palpite))
            {
                throw new ArgumentException("Por favor, digite um número válido.");
            }

            if (palpite < MinNumero || palpite > MaxNumero)
            {
                throw new ArgumentException($"O palpite deve estar entre {MinNumero} e {MaxNumero}.");
            }
            return palpite;
        }
    }
}
