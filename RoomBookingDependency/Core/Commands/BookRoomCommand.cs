using RoomBookingDependency.Core.Entities;

namespace RoomBookingDependency.Core.Commands;

public class BookRoomCommand
{
    public string Email { get; set; }
    public Guid RoomId { get; set; }
    public DateTime Day { get; set; }
    public CreditCard CreditCard { get; set; }
}