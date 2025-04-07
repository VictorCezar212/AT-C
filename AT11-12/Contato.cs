using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT11_12
{
    public class Contato
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{Nome},{Telefone},{Email}";
        }

        public static Contato FromString(string linha)
        {
            var partes = linha.Split(',');
            return new Contato
            {
                Nome = partes[0],
                Telefone = partes[1],
                Email = partes[2]
            };
        }
    }

    public class ContatoRepositorio
    {
        private const string ArquivoContatos = "contatos.txt";

        public void Adicionar(Contato contato)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(ArquivoContatos, true))
                {
                    sw.WriteLine(contato.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar contato: {ex.Message}");
            }
        }

        public List<Contato> ListarTodos()
        {
            var contatos = new List<Contato>();

            if (!File.Exists(ArquivoContatos))
            {
                return contatos;
            }

            try
            {
                using (StreamReader sr = new StreamReader(ArquivoContatos))
                {
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(linha))
                        {
                            contatos.Add(Contato.FromString(linha));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler contatos: {ex.Message}");
            }

            return contatos;
        }
    }

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
