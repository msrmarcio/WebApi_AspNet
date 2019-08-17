using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Impacta.WebApi.Pessoas.Models;

namespace Impacta.WebApi.Pessoas.Controllers
{
    public class PessoasController : ApiController
    {
		// como não temos ainda o BD, vamos simular utilizando
		// uma lista, do tipo Static
		static List<Pessoa> pessoas = new List<Pessoa>();

		public PessoasController()
		{

		}

		public List<Pessoa> GetListaPessoas()
		{
			return pessoas;
		}

		public void Post(string nomeDaPessoa)
		{
			if (!string.IsNullOrEmpty(nomeDaPessoa))
			{
				pessoas.Add(new Pessoa { Nome = nomeDaPessoa });
			}
		}

		public void Post(Pessoa pessoa)
		{
			if (pessoa != null)
			{
				pessoas.Add(pessoa);
			}
		}

    }
}
