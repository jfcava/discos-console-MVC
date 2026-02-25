using dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using negocio;

namespace web_app_discos.Controllers
{
    public class DiscoController : Controller
    {
        //Para no tener que crear una instancia de DiscoNegocio en cada acción,
        //se inyecta a través del constructor de la clase.
        private DiscoNegocio _negocio;
        
        //El constructor recibe una instancia de DiscoNegocio,
        //que es proporcionada por el sistema de inyección de dependencias de ASP.NET Core.
        public DiscoController(DiscoNegocio negocio)
        {
            _negocio = negocio;
        }
        // GET: DiscoController
        public ActionResult Index(string filtro)
        {
            var discos = _negocio.listar();

            if (!string.IsNullOrEmpty(filtro))
            {
                discos = discos.FindAll(p => p.Titulo.Contains(filtro));
            }

            ViewBag.filtro = filtro;

            return View(discos);
        }

        // GET: DiscoController/Details/5
        public ActionResult Details(int id)
        {

            var disco = _negocio.listar().Find(d => d.Id == id);
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
                _negocio.agregar(disco);

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

            var disco = _negocio.listar().Find(d => d.Id == id);

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

                _negocio.modificar(disco);

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
            var disco = _negocio.listar().Find(d => d.Id == id);
            return View(disco);
        }

        // POST: DiscoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _negocio.eliminar(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
