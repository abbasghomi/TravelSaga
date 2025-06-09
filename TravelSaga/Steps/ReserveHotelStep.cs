using TravelSaga.Steps.Contracts;
using TravelSaga.Utils;

namespace TravelSaga.Steps
{
    // Step to reserve a hotel as part of the travel saga.
    public class ReserveHotelStep : ISagaStep
    {
        public string Name => "Reserve Hotel";

        public async Task CompensateAsync()
        {
            "Hotel reservation cancelled.".WriteColored(ConsoleMessageType.Warning);
            await Task.Delay(100);
        }

        public async Task<bool> ExecuteAsync()
        {
            "Hotel reserved.".WriteColored(ConsoleMessageType.Success);
            await Task.Delay(100);
            return true;
        }
    }
}