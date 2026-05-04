using HerederosDelReyBackend.DTOs;

namespace HerederosDelReyBackend.Interfaces
{
    public interface IReporteService 
    {
        Task<IEnumerable<ReporteDto>> GetReport(DateTime fechaInicial, DateTime fechaFinal);
        
    }
}
