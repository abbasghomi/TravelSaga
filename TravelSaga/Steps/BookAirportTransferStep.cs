using TravelSaga.Steps.Contracts;

namespace TravelSaga.Steps
{
    // Step to book an airport transfer as part of the travel saga.
    public class BookAirportTransferStep : ISagaStep
    {
        public string Name => "Book Airport Transfer";

        public async Task CompensateAsync()
        {
            Console.WriteLine("Airport transfer booking cancelled.");
            await Task.Delay(100);
        }

        public async Task<bool> ExecuteAsync()
        {
            Console.WriteLine("Airport transfer booked.");
            await Task.Delay(100);
            return true;
        }
    }
}