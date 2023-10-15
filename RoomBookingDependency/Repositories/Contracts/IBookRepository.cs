using RoomBookingDependency.Core.Models;

namespace RoomBookingDependency;

public interface IBookRepository
{
    Task<Book?> GetByRoomAndDate(int roomId, DateTime date);
    Task Save(Book book);
}
