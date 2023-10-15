using RoomBookingDependency.Core.Responses;
using RoomBookingDependency.Services.Contracts;
using RestSharp;

namespace RoomBookingDependency.Services
{
    public class PaymentService : IPaymentService
    {
        public async Task<PaymentResponse?> Pay(string email, string creditCardNumber)
        {
            var client = new RestClient("https://payments.com");
            var request = new RestRequest()
            .AddQueryParameter("api_key", "c20c8acb-bd76-4597-ac89-10fd955ac60d")
            .AddJsonBody(new
            {
                User = email,
                CreditCard = creditCardNumber
            });
        return await client.PostAsync<PaymentResponse>(request, new CancellationToken());
        }
    }
}