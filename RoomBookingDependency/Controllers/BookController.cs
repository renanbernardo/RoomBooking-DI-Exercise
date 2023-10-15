using Microsoft.AspNetCore.Mvc;
using RoomBookingDependency.Core.Commands;
using RoomBookingDependency.Core.Models;
using RoomBookingDependency.Repositories.Contracts;
using RoomBookingDependency.Services.Contracts;

namespace DependencyRoomBooking.Controllers;

[ApiController]
public class BookController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IPaymentService _paymentService;

    public BookController(IPaymentService paymentService,
    ICustomerRepository customerRepository,
    IBookRepository bookRepository)
    {
        _paymentService = paymentService;
        _customerRepository = customerRepository;
        _bookRepository = bookRepository;
    }


    public async Task<IActionResult> Book(BookRoomCommand command)
    {
        var customer = await _customerRepository.GetByEmail(command.Email);        

        if (customer == null)
            return NotFound();

        var room = await _bookRepository.GetByRoomAndDate(command.RoomId, command.Day);

        if (room is not null)
            return BadRequest();

        var pay = await _paymentService.Pay(command.Email, command.CreditCard.Number);

        if (pay is null)
            return BadRequest();

        if (pay?.Status != "paid")
            return BadRequest();

        var book = new Book(command.Email, command.RoomId, command.Day);
        await _bookRepository.Save(book);

        return Ok();
    }
}