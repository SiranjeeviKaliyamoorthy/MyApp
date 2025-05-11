using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Data;
using StudentAPI.Data.AppDbContext;
using StudentAPI.Models;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class StudentController : ControllerBase
{
    private readonly AppDbContext _context;

    public StudentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get() => Ok(_context.Students.ToList());

    [HttpPost]
    public IActionResult Create(Student student)
    {
        _context.Students.Add(student);
        _context.SaveChanges();
        return Ok(student);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Student student)
    {
        var existing = _context.Students.Find(id);
        if (existing == null) return NotFound();
        existing.Name = student.Name;
        existing.Age = student.Age;
        _context.SaveChanges();
        return Ok(existing);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var existing = _context.Students.Find(id);
        if (existing == null) return NotFound();
        _context.Students.Remove(existing);
        _context.SaveChanges();
        return NoContent();
    }
}
