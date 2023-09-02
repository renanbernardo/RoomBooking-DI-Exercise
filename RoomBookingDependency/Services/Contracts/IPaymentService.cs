using RoomBookingDependency.Core.Models;
using RoomBookingDependency.Core.Responses;

namespace RoomBookingDependency.Services.Contracts;

public interface IPaymentService
{
    Task<PaymentResponse> Pay();
}
