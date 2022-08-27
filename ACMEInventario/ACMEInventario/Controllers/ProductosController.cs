using ACMEInventario.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ACMEInventario.Controllers
{
    public class ProductosController : Controller
    {
        private readonly inventarioContext _context;

        public ProductosController(inventarioContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            var inventarioContext = _context.Productos.Include(p => p.IdSucursalNavigation).Include(p => p.IdTipoMovimientoNavigation);
            return View(await inventarioContext.ToListAsync());
        }

        // GET: Productos/Details/id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.IdSucursalNavigation)
                .Include(p => p.IdTipoMovimientoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            ViewBag.Sucursal = _context.Sucursals.ToList();
            ViewBag.TipoMovimiento = _context.TipoMovimientos.ToList();
            return View();
        }
        // POST: Productos/Create, obtiene el objeto producto y lo agrega 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto producto)
        {
                _context.Add(producto);
            //Agregar saveChanges, si no se agrega no se verá reflejado en la bd
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }


        // GET: Productos/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Sucursal = _context.Sucursals.ToList();
            ViewBag.TipoMovimiento = _context.TipoMovimientos.ToList();
            var producto = await _context.Productos
                .Include(p => p.IdSucursalNavigation)
                .Include(p => p.IdTipoMovimientoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            return View(producto);
        }
        // POST: Productos/Edit, obtiene el objeto producto y lo actualiza
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Producto producto)
        {
            _context.Update(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }
            var producto = await _context.Productos
                .Include(p => p.IdSucursalNavigation)
                .Include(p => p.IdTipoMovimientoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }
        // POST: Productos/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Productos == null)
            {
                return Problem("Entity set 'inventarioContext.Productos'  is null.");
            }
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        // GET: Productos/Create
        public IActionResult Find()
        {
            ViewBag.Sucursal = _context.Sucursals.ToList();
            return View();
        }
        // POST: Productos/Create, obtiene el objeto producto y lo agrega 
        [HttpPost]
        public IActionResult FindCodBarra(int codigoBarra)
        {

            List<Producto> listaProducto = _context.Productos.Where(x => x.CodigoBarra == codigoBarra)
                .Include(p => p.IdSucursalNavigation)
                .Include(p => p.IdTipoMovimientoNavigation)
                .ToList();

            return View(listaProducto);
        }
    }
}
