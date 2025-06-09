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
            "Event tickets booking cancelled.".WriteColored(ConsoleMessageType.Warning);
            await Task.Delay(100);
        }

        public async Task<bool> ExecuteAsync()
        {
            bool failed = FailureSimulator.ShouldFail(0.5);
            if (failed)
            {
                "Event tickets booking failed.".WriteColored(ConsoleMessageType.Fail);
                await Task.Delay(100);
                return false;
            }
            else
            {
                "Event tickets booked.".WriteColored(ConsoleMessageType.Success);
                await Task.Delay(100);
                return true;
            }
        }
    }
}