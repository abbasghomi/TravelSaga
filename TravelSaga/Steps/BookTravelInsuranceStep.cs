using TravelSaga.Steps.Contracts;

namespace TravelSaga.Steps
{
    // Step to book travel insurance as part of the travel saga.
    public class BookTravelInsuranceStep : ISagaStep
    {
        public string Name => "Book Travel Insurance";

        public async Task CompensateAsync()
        {
            Console.WriteLine("Travel insurance booking cancelled.");
            await Task.Delay(100);
        }

        public async Task<bool> ExecuteAsync()
        {
            Console.WriteLine("Travel insurance booked.");
            await Task.Delay(100);
            return true;
        }
    }
}