using RemindMe.Data;
using RemindMe.Models;
using Microsoft.EntityFrameworkCore;

namespace RemindMe.Services
{
    public class RecordatorioService
    {
        private readonly DataContext _context;

        public RecordatorioService(DataContext context)
        {
            _context = context;
        }

        // Obtener todos los recordatorios
        public async Task<List<Recordatorio>> ObtenerTodos()
        {
            return await _context.Recordatorios.ToListAsync();
        }

        // Obtener por ID
        public async Task<Recordatorio?> ObtenerPorId(Guid id)
        {
            return await _context.Recordatorios.FindAsync(id);
        }

        // Crear recordatorio
        public async Task<Recordatorio> Crear(Recordatorio recordatorio)
        {
            recordatorio.Id = Guid.NewGuid();
            recordatorio.Created_At = DateTime.UtcNow; // Asigna la fecha actual

            _context.Recordatorios.Add(recordatorio);
            await _context.SaveChangesAsync();

            return recordatorio;
        }

        // Actualizar recordatorio
        public async Task<bool> Actualizar(Guid id, Recordatorio recordatorioActualizado)
        {
            var recordatorio = await _context.Recordatorios.FindAsync(id);
            if (recordatorio == null) return false;

            // Actualiza solo los campos permitidos
            recordatorio.Titulo = recordatorioActualizado.Titulo;
            recordatorio.Descripcion = recordatorioActualizado.Descripcion;
            recordatorio.Fecha_Hora = recordatorioActualizado.Fecha_Hora;

            await _context.SaveChangesAsync();
            return true;
        }

        // Eliminar recordatorio
        public async Task<bool> Eliminar(Guid id)
        {
            var recordatorio = await _context.Recordatorios.FindAsync(id);
            if (recordatorio == null) return false;

            _context.Recordatorios.Remove(recordatorio);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
