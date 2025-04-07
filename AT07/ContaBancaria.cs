using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT07
{
    class ContaBancaria
    {
        public string Titular { get; set; }
        private decimal saldo;

        public void Depositar(decimal valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("O valor do depósito deve ser positivo!");
            }
            else
            {
                saldo += valor;
                Console.WriteLine($"Depósito de R$ {valor} realizando com sucesso!");
            }
        }

        public void Sacar(decimal valor)
        {
            if (valor > saldo)
            {
                Console.WriteLine("Saldo insuficiente para realizar o saque!");
            }
            else
            {
                saldo -= valor;
                Console.WriteLine($"Saque de R$ {valor} realizando com sucesso!");
            }
        }

        public void ExibirSaldo()
        {
            Console.WriteLine($"Saldo atual: R$ {saldo}");
        }
    }
}
