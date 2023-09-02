namespace RoomBookingDependency.Core.Models;

public record Book(string Email, Guid RoomId, DateTime Day);