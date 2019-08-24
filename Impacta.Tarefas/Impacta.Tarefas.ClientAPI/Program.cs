using Impacta.MOD;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Impacta.Tarefas.ClientAPI
{
	class Program
	{

		static void Main(string[] args)
		{

			// executa o metodo assincrono para a chamada da api
			RunAsync().Wait();

			// wait solicita que aguarde ate que o processamento da api
			// retorne valor
		}


		static async Task RunAsync()
		{
			// definido para o HEADER da chamada http qual tipo de Content-Type
			// se realizará na comunicação: Text, XML, JSON e etc....
			var formato = new MediaTypeWithQualityHeaderValue("application/json");

			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("http://localhost:52380/");
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(formato);

				// o metodo GetAsync() ele vai solicitar a execução da sua API
				// e obter um valor de resposta, armazenado na variavel RESPOSTA
				var resposta = await client.GetAsync("api/WebApiEditora");

				// Nós precisamos definir qual tipo de retorno iremos obter
				// neste caso podemos definir de duas maneiras
				// 1) Definimos um objeto de retorno similar ao da assinatura da API
				// 2) Ou defini-se uma Modelagem de uma classe igual a retornada pela API
				//var conteudo = await resposta.Content.ReadAsAsync<IEnumerable<object>>();

				// no segunda forma seria assim
				var conteudo = await resposta.Content.ReadAsAsync<IEnumerable<Editora>>();

				//string conteudo = await resposta.Content.ReadAsAsync<string>();
				foreach (var item in conteudo)
				{
					Console.WriteLine(
						string.Format(
							"EditoraID: {0}, Nome: {1}", item.EditoraId, item.Nome));
				}
			}
			Console.ReadLine();
		}
	}
}
