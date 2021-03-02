using System.Threading.Tasks;
using Service.Models;

namespace Service.Interfaces
{
    public interface IUnitOfWork
    {
        public VehicleService VehicleService { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}