using dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using negocio;

namespace web_app_discos.Controllers
{
    public class DiscoController : Controller
    {
        // GET: DiscoController
        public ActionResult Index()
        {
            DiscoNegocio negocio = new DiscoNegocio();
            var discos = negocio.listar();
            return View(discos);
        }

        // GET: DiscoController/Details/5
        public ActionResult Details(int id)
        {
            DiscoNegocio negocio = new DiscoNegocio();

            var disco = negocio.listar().Find(d => d.Id == id);
            return View(disco);
        }

        // GET: DiscoController/Create
        public ActionResult Create()
        {
            EstiloNegocio estiloNegocio = new EstiloNegocio();
            TipoEdicionNegocio tipoEdicionNegocio = new TipoEdicionNegocio();

            //ViewBag.Elementos = new SelectList(elementoNegocio.listar(), "Id", "Descripcion");

            ViewBag.Estilos = new SelectList(estiloNegocio.listar(), "Id", "Descripcion");
            ViewBag.TiposEdicion = new SelectList(tipoEdicionNegocio.listar(), "Id", "Descripcion");

            return View();
        }

        // POST: DiscoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Disco disco)
        {
            try
            {
                DiscoNegocio negocio = new DiscoNegocio();

                negocio.agregar(disco);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DiscoController/Edit/5
        public ActionResult Edit(int id)
        {
            DiscoNegocio negocio = new DiscoNegocio();

            var disco = negocio.listar().Find(d => d.Id == id);

            EstiloNegocio estiloNegocio = new EstiloNegocio();
            TipoEdicionNegocio tipoEdicionNegocio = new TipoEdicionNegocio();

            ViewBag.Estilos = new SelectList(estiloNegocio.listar(), "Id", "Descripcion");
            ViewBag.TiposEdicion = new SelectList(tipoEdicionNegocio.listar(), "Id", "Descripcion");

            return View(disco);
        }

        // POST: DiscoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Disco disco)
        {
            try
            {
                DiscoNegocio negocio = new DiscoNegocio();

                negocio.modificar(disco);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DiscoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DiscoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
