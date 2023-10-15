using RoomBookingDependency.Core.Models;

namespace RoomBookingDependency.Repositories.Contracts;

public interface IBookRepository
{
    Task<Book?> GetByRoomAndDate(Guid roomId, DateTime date);
    Task Save(Book book);
}
