using TravelSaga.Steps.Contracts;
using TravelSaga.Utils;

namespace TravelSaga.Steps
{
    // Step to book event tickets as part of the travel saga. May randomly fail.
    public class BookEventTicketsStep : ISagaStep
    {
        public string Name => "Book Event Tickets";

        public async Task CompensateAsync()
        {
            Console.WriteLine("Event tickets booking cancelled.");
            await Task.Delay(100);
        }

        public async Task<bool> ExecuteAsync()
        {
            Console.WriteLine("Event tickets booked.");
            await Task.Delay(100);
            return FailureSimulator.ShouldFail(0.5) ? false : true;
        }
    }
}