using RoomBookingDependency.Core.Models;

namespace RoomBookingDependency;

public interface ICustomerRepository
{
    Task<Customer?> GetByEmail(string email);
}
