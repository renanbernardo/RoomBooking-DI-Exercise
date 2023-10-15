using RoomBookingDependency.Core.Models;
using Microsoft.Data.SqlClient;
using Dapper;
using RoomBookingDependency.Repositories.Contracts;

namespace RoomBookingDependency.Repositories;

public class CustomerRepository : ICustomerRepository
{
    public async Task<Customer?> GetByEmail(string email)     
    {
        await using var connection = new SqlConnection();
        return await connection
            .QueryFirstOrDefaultAsync<Customer?>("SELECT * FROM [Customer] WHERE [Email]=@email",
                new { email });
    }
}
