using TravelSaga.Steps.Contracts;
using TravelSaga.Utils;

namespace TravelSaga.Steps
{
    // Step to book an airport transfer as part of the travel saga.
    public class BookAirportTransferStep : ISagaStep
    {
        public string Name => "Book Airport Transfer";

        public async Task CompensateAsync()
        {
            "Airport transfer booking cancelled.".WriteColored(ConsoleMessageType.Warning);
            await Task.Delay(100);
        }

        public async Task<bool> ExecuteAsync()
        {
            "Airport transfer booked.".WriteColored(ConsoleMessageType.Success);
            await Task.Delay(100);
            return true;
        }
    }
}