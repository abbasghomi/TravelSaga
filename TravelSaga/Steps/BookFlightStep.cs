using TravelSaga.Steps.Contracts;
using TravelSaga.Utils;

namespace TravelSaga.Steps
{
    // Step to book a flight as part of the travel saga.
    public class BookFlightStep : ISagaStep
    {
        public string Name => "Book Flight";

        public async Task CompensateAsync()
        {
            "Flight booking cancelled.".WriteColored(ConsoleMessageType.Warning);
            await Task.Delay(100);
        }

        public async Task<bool> ExecuteAsync()
        {
            "Flight booked.".WriteColored(ConsoleMessageType.Success);
            await Task.Delay(100);
            return true;
        }
    }
}