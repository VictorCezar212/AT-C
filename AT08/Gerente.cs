using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT08
{
    public class Gerente : Funcionario
    {
        private const decimal PercentualBonus = 0.20m;

        public Gerente(string nome, decimal salarioBase)
            : base(nome, "Gerente", salarioBase)
        {
        }

        public override decimal CalcularSalario()
        {
            return SalarioBase + (SalarioBase * PercentualBonus);
        }
    }
}
