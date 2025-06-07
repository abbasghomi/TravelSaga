using TravelSaga.Steps.Contracts;

namespace TravelSaga.Steps
{
    // Step to book a flight as part of the travel saga.
    public class BookFlightStep : ISagaStep
    {
        public string Name => "Book Flight";

        public async Task CompensateAsync()
        {
            Console.WriteLine("Flight booking cancelled.");
            await Task.Delay(100);
        }

        public async Task<bool> ExecuteAsync()
        {
            Console.WriteLine("Flight booked.");
            await Task.Delay(100);
            return true;
        }
    }
}