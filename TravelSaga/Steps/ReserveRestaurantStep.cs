using TravelSaga.Steps.Contracts;
using TravelSaga.Utils;

namespace TravelSaga.Steps
{
    // Step to reserve a restaurant as part of the travel saga. May randomly fail.
    public class ReserveRestaurantStep : ISagaStep
    {
        public string Name => "Reserve Restaurant";

        public async Task CompensateAsync()
        {
            "Restaurant reservation cancelled.".WriteColored(ConsoleMessageType.Warning);
            await Task.Delay(100);
        }

        public async Task<bool> ExecuteAsync()
        {
            bool failed = FailureSimulator.ShouldFail(0.7);
            if (failed)
            {
                "Restaurant reservation failed.".WriteColored(ConsoleMessageType.Fail);
                await Task.Delay(100);
                return false;
            }
            else
            {
                "Restaurant reserved.".WriteColored(ConsoleMessageType.Success);
                await Task.Delay(100);
                return true;
            }
        }
    }
}