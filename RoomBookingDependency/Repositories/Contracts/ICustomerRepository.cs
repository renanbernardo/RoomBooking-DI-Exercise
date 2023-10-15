using RoomBookingDependency.Core.Models;

namespace RoomBookingDependency.Repositories.Contracts;

public interface ICustomerRepository
{
    Task<Customer?> GetByEmail(string email);
}
