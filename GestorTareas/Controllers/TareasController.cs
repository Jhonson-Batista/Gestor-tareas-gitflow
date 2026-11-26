using GestorTareas.Data;
using GestorTareas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorTareas.Controllers;

public class TareasController : Controller
{
    private readonly AppDbContext _context;

    public TareasController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var tareas = await _context.Tareas
            .OrderBy(t => t.FechaLimite)
            .ToListAsync();
        return View(tareas);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tarea = await _context.Tareas.FirstOrDefaultAsync(t => t.Id == id);
        if (tarea == null)
        {
            return NotFound();
        }

        return View(tarea);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Titulo,Descripcion,Materia,FechaLimite,Prioridad,Completada")] Tarea tarea)
    {
        if (ModelState.IsValid)
        {
            _context.Add(tarea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(tarea);
    }
}