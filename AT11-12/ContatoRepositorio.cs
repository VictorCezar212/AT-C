using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT11_12
{
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
}
