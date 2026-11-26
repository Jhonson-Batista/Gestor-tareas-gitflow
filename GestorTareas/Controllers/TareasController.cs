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

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tarea = await _context.Tareas.FindAsync(id);
        if (tarea == null)
        {
            return NotFound();
        }

        return View(tarea);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descripcion,Materia,FechaLimite,Prioridad,Completada")] Tarea tarea)
    {
        if (id != tarea.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(tarea);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Tareas.Any(t => t.Id == id))
                {
                    return NotFound();
                }
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(tarea);
    }

    public async Task<IActionResult> Delete(int? id)
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

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var tarea = await _context.Tareas.FindAsync(id);
        if (tarea != null)
        {
            _context.Tareas.Remove(tarea);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}