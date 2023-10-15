using RoomBookingDependency.Core.Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace RoomBookingDependency;

public class BookRepository : IBookRepository
{
    public async Task<Book?> GetByRoomAndDate(int roomId, DateTime date)
    {
        await using var connection = new SqlConnection();
        return await connection.QueryFirstOrDefaultAsync<Book?>(
            "SELECT * FROM [Book] WHERE [Room]=@room AND [Date] BETWEEN @dateStart AND @dateEnd",
            new
            {
                Room = roomId,
                DateStart = date,
                DateEnd = date.AddDays(1).AddTicks(-1),
            });
    }

    public async Task Save(Book book)
    {
        await using var connection = new SqlConnection();
        await connection.ExecuteAsync("INSERT INTO [Book] VALUES(@date, @email, @room)", new
        {
            book.Day,
            book.Email,
            book.RoomId
        });
    }
}
