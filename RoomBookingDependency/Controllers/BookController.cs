using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Dapper;


namespace DependencyRoomBooking.Controllers;

[ApiController]
public class BookController : ControllerBase
{
    public async Task<IActionResult> Book(BookRoomCommand command)
    {
        // Recupera o usuário
        

        if (customer == null)
            return NotFound();

        // Verifica se a sala está disponível
        

        // Se existe uma reserva, a sala está indisponível
        if (room is not null)
            return BadRequest();

        // Tenta fazer um pagamento
        

        // Se a requisição não pode ser completa
        if (response is null)
            return BadRequest();

        // Se o status foi diferente de "pago"
        if (response?.Status != "paid")
            return BadRequest();

        // Cria a reserva
        var book = new Book(command.Email, command.RoomId, command.Day);

        // Salva os dados
        

        // Retorna o número da reserva
        return Ok();
    }
}