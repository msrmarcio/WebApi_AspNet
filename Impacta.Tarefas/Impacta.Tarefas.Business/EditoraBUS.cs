using Impacta.MOD;
using Impacta.Tarefas.EF;
using System;
using System.Collections.Generic;

namespace Impacta.Tarefas.Business
{
	public class EditoraBUS
	{
		public List<Editora> ListarEditoras()
		{
			// instanciamos o objeto que se comunica com Banco dados
			EditoraEF editoraEF = new EditoraEF();

			List<Editora> ed;
			try
			{
				// executa o metodo listar Editoras (Faz Select)
				ed = editoraEF.ListarEditoras();


			}
			catch (Exception ex)
			{
				throw new Exception(
					"Falha ao tentar Validar a busca das Editoras. Erro: \n"
						+ ex.Message);
			}

			return ed;
		}

		public void Salvar(Editora editora)
		{
			try
			{
				if (string.IsNullOrEmpty(editora.Nome))
				{
					throw new Exception("Nome invalido");
				}

				if (string.IsNullOrEmpty(editora.Email))
				{
					throw new Exception("E-mail invalido");
				}

				EditoraEF editoraEF = new EditoraEF();

				editoraEF.Salvar(editora);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Editora BuscarEditora(int id)
		{
			// instanciamos o objeto que se comunica com Banco dados
			EditoraEF editoraEF = new EditoraEF();

			Editora ed;

			try
			{
				// executa o metodo listar Editoras (Faz Select)
				ed = editoraEF.BuscarEditora(id);
			}
			catch (Exception ex)
			{
				throw new Exception(
					"Falha ao tentar Validar a busca das Editoras. Erro: \n"
						+ ex.Message);
			}

			return ed;
		}

		public void Excluir(int id)
		{
			EditoraEF edEF = new EditoraEF();

			edEF.Excluir(id);
		}
	}
}
