using TravelSaga.Steps.Contracts;
using TravelSaga.Utils;

namespace TravelSaga.Steps
{
    // Step to reserve a tour as part of the travel saga.
    public class ReserveTourStep : ISagaStep
    {
        public string Name => "Reserve Tour";

        public async Task CompensateAsync()
        {
            "Tour reservation cancelled.".WriteColored(ConsoleMessageType.Warning);
            await Task.Delay(100);
        }

        public async Task<bool> ExecuteAsync()
        {
            "Tour reserved.".WriteColored(ConsoleMessageType.Success);
            await Task.Delay(100);
            return true;
        }
    }
}