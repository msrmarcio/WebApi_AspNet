using System.Web.Mvc;
using Impacta.MOD;
using Impacta.Tarefas.Business;
using System;

namespace Impacta.Tarefas.Controllers
{
	public class RealBooksController : Controller
	{
		// GET: RealBooks
		public ActionResult Index()
		{

			return View();
		}

		public ActionResult ListarNovasEditora()
		{
			try
			{
				EditoraBUS objEditora = new EditoraBUS();

				var lst = objEditora.ListarEditoras();

				return View(lst);

			}
			catch (Exception ex)
			{

				throw;
			}
		}

		// GET: RealBooks/Details/5
		public ActionResult Details(int id)
		{
			EditoraBUS objEditora = new EditoraBUS();

			var editora = objEditora.BuscarEditora(id);

			return View(editora);
		}
		 

		// GET: RealBooks/Create
		public ActionResult Create()
		{

			return View();
		}

		// POST: RealBooks/Create
		[HttpPost]
		public ActionResult Create(Editora collection)
		{
			try
			{
				// invocando na camada de negocio
				// o metodo para salvar os dados da Editora
				EditoraBUS editoraBUS = new EditoraBUS();

				// enviamos para a camada de negocio os dados da Editora
				editoraBUS.Salvar(collection);

				//se for bem sucedido, retornamos para a pagina principal
				return RedirectToAction("Index");
			}
			catch
			{

				return View();
			}
		}

		// GET: RealBooks/Edit/5
		public ActionResult Edit(int id)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					ModelState.AddModelError("Editora", "Editora inválida.");
				}

				EditoraBUS objEditora = new EditoraBUS();

				var lst = objEditora.BuscarEditora(id);

				return View(lst);
			}
			catch
			{
				return View();
			}
		}

		// POST: RealBooks/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, Editora editora)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					ModelState.AddModelError("Editora", "Editora inválida.");
				}

				EditoraBUS editoraBUS = new EditoraBUS();

				editoraBUS.Salvar(editora);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: RealBooks/Delete/5
		public ActionResult Delete(int id)
		{
			try
			{
				EditoraBUS editoraBUS = new EditoraBUS();

				editoraBUS.Excluir(id);
			}
			catch (Exception)
			{

				throw;
			}
			return View();
		}

		// POST: RealBooks/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
