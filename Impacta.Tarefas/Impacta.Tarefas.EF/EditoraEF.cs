using Impacta.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Impacta.Tarefas.EF
{
	public class EditoraEF
	{
		public List<Editora> ListarEditoras()
		{
			List<Editora> listaDeEditora = null;

			using (RealBooksContexto realDB = new RealBooksContexto())
			{
				// uma vez instanciado o contexto
				// precisamos retornar os dados do Banco via SELECT
				listaDeEditora = realDB.Editoras.ToList();
			}

			return listaDeEditora;
		}

		public void Salvar(Editora editora)
		{
			using (RealBooksContexto db = new RealBooksContexto())
			{
				// verifica se o ID já existe, se existe é pq não é 
				// um cadastro novo, então é uma alteração
				if (editora.EditoraId > 0)
				{
					// busca no banco de dados o registro por ID
					var result = db.Editoras.Where(x => x.EditoraId == editora.EditoraId).FirstOrDefault();

					result.Nome = editora.Nome;
					result.Email = editora.Email;

					// Faz update no banco no registro alterado
					db.SaveChanges();
				}
				else
				{
					// adiciona o objeto
					db.Editoras.Add(editora);
					// faz um INSERT no banco de dados
					db.SaveChanges();
				}
			}
		}

		public Editora BuscarEditora(int id)
		{
			Editora editora = null;

			using (RealBooksContexto realDB = new RealBooksContexto())
			{
				// uma vez instanciado o contexto precisamos retornar os dados do Banco via SELECT
				using (var db = new RealBooksContexto())
				{
					editora = db.Editoras.Where(p => p.EditoraId == id).FirstOrDefault();
				}
			}
			return editora;
		}

		public void Excluir(int id)
		{
			using (var realDB = new RealBooksContexto())
			{
				// busca a editora pelo ID
				var editora = realDB.Editoras.Where(i => i.EditoraId == id).FirstOrDefault();
				realDB.Editoras.Remove(editora);
				realDB.SaveChanges();
			}
		}
	}
}
