using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT11_12
{
    public class ContatoServico
    {
        private readonly ContatoRepositorio _repositorio;

        public ContatoServico()
        {
            _repositorio = new ContatoRepositorio();
        }


        public void AdicionarContato()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            var contato = new Contato
            {
                Nome = nome,
                Telefone = telefone,
                Email = email
            };

            _repositorio.Adicionar(contato);
            Console.WriteLine("Contato cadastrado com sucesso!\n");
        }

        public void ListarContatos()
        {
            var contatos = _repositorio.ListarTodos();

            if (contatos.Count == 0)
            {
                Console.WriteLine("Nenhum contato cadastrado.\n");
                return;
            }

            Console.WriteLine("Contatos cadastrados:");
            foreach (var contato in contatos)
            {
                Console.WriteLine($"Nome: {contato.Nome} | Telefone: {contato.Telefone} | Email: {contato.Email}");
            }
            Console.WriteLine();
        }
    }
}
