using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// para acessar o BD usamos a classe
using System.Data.SqlClient;
using Impacta.MOD;

namespace Impacta.Tarefas.DAL
{
	public class Data
	{
		// connection
		SqlConnection sqlConn;

		// comando
		SqlCommand cmd;

		bool resultado;

		//String de conexão
		string conexao =
			@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Pessoal;Integrated Security=True;Pooling=False";

		public Data()
		{

		}

		private bool CriarConexao()
		{
			bool criadoConexao = false;

			if (sqlConn == null)
			{
				// para criar o objeto de conexao precisamos dos dados da conexao
				// endereco do server, instancia, usuario e senha quando necessario
				sqlConn = new SqlConnection(conexao);

				criadoConexao = true;
			}

			return criadoConexao;
		}

		private void CriarComandoTarefa(string querySql, TarefaMOD objModelTarefa)
		{
			// o SQLcommand
			cmd = new SqlCommand();

			cmd.CommandText = querySql;
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.Parameters.AddWithValue("@Nome", objModelTarefa.Nome);
			cmd.Parameters.AddWithValue("@Prioridade", objModelTarefa.Prioridade);
			cmd.Parameters.AddWithValue("@Concluida", objModelTarefa.Concluida);
			cmd.Parameters.AddWithValue("@Observacoes", objModelTarefa.Observacoes);

			cmd.Connection = sqlConn;
		}

		public bool CriarTarefa(TarefaMOD tarefa)
		{
			resultado = false;

			try
			{
				string query =
					@"INSERT INTO TAREFAS (Nome, Prioridade, Concluida, Observacoes) 
								VALUES(@Nome, @Prioridade, @Concluida, @Observacoes)";

				if (CriarConexao())
				{
					CriarComandoTarefa(query, tarefa);

					sqlConn.Open();

					var ret = cmd.ExecuteNonQuery();

					resultado = true;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally // bloco opcional, uma vez definido ele sera sempre executado
			{
				if (sqlConn.State == System.Data.ConnectionState.Open)
				{
					sqlConn.Close();
				}
			}

			return resultado;
		}

		public List<TarefaMOD> ListarTarefas()
		{
			resultado = false;
			List<TarefaMOD> lista = new List<TarefaMOD>();

			try
			{
				if (CriarConexao())
				{

					string sql = @"SELECT Id,Nome,Prioridade,Concluida, Observacoes FROM Tarefas 
									ORDER BY Concluida,Prioridade";

					// bloco USING fecha automaticamente a comunicação com banco de dados
					using (var conn = sqlConn)
					{
						using (var cmd = new SqlCommand(sql, conn))
						{
							conn.Open();

							using (var dr = cmd.ExecuteReader())
							{
								// fazemos uso do While para percorrer o resultado do SELECT
								while (dr.Read())
								{
									var tarefa = new TarefaMOD();

									tarefa.Id = Convert.ToInt32(dr["Id"]);
									tarefa.Nome = Convert.ToString(dr["Nome"].ToString());
									tarefa.Prioridade = Convert.ToInt32(dr["Prioridade"]);
									tarefa.Concluida = Convert.ToBoolean(dr["Concluida"]);
									tarefa.Observacoes = Convert.ToString(dr["Observacoes"]);

									//adiciona na lista
									lista.Add(tarefa);
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally // bloco opcional, uma vez definido ele sera sempre executado
			{
				if (sqlConn.State == System.Data.ConnectionState.Open)
				{
					sqlConn.Close();
				}
			}

			return lista;
		}

		public bool AtualizarTarefa(int id, TarefaMOD collection)
		{
			bool retorno = false;

			try
			{
				if (CriarConexao())
				{

					string sql = @"UPDATE Tarefas 
									SET Nome = @Nome, 
									Prioridade = @Prioridade, 
									Concluida= @Concluida, 
									Observacoes= @Observacoes
								WHERE ID=@Id";

					// bloco USING fecha automaticamente a comunicação com banco de dados
					using (var conn = sqlConn)
					{
						using (var cmd = new SqlCommand(sql, conn))
						{
							cmd.Parameters.AddWithValue("@Id", collection.Id);
							cmd.Parameters.AddWithValue("@Nome", collection.Nome);
							cmd.Parameters.AddWithValue("@Prioridade", collection.Prioridade);
							cmd.Parameters.AddWithValue("@Concluida", collection.Concluida);
							cmd.Parameters.AddWithValue("@Observacoes", collection.Observacoes);

							// abre conexao com BD
							conn.Open();

							// if ternario
							retorno = cmd.ExecuteNonQuery() > 0 ? true : false;
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return retorno;
		}

		public TarefaMOD ConsultarTarefa(int id)
		{
			TarefaMOD tarefa = null;

			try
			{
				if (CriarConexao())
				{

					string sql = @"SELECT Id,Nome,Prioridade,Concluida, Observacoes FROM Tarefas WHERE Id=@Id";

					// bloco USING fecha automaticamente a comunicação com banco de dados
					using (var conn = sqlConn)
					{
						using (var cmd = new SqlCommand(sql, conn))
						{
							cmd.Parameters.AddWithValue("@Id", id);
							// abre conexao com BD
							conn.Open();

							var res = cmd.ExecuteReader();

							if (res.HasRows && res.Read())
							{
								tarefa = new TarefaMOD()
								{
									Id = (int)res["Id"],
									Nome = res["Nome"].ToString(),
									Prioridade = (int)res["Prioridade"],
									Concluida = (bool)res["Concluida"],
									Observacoes = res["Observacoes"].ToString()
								};
							}
						}
					}
				}

				return tarefa;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public bool ExcluirTarefa(int id)
		{
			string sql = @"DELETE TAREFAS WHERE Id=@Id";
			bool retorno = false;

			using (var cn = new SqlConnection(conexao))
			{
				using (var cmd = new SqlCommand(sql, cn))
				{
					cmd.Parameters.AddWithValue("@Id", id);

					cn.Open();

					retorno = Convert.ToInt32(cmd.ExecuteNonQuery()) > 0 ? true : false;
				}
			}
			return retorno;
		}
	}
}
