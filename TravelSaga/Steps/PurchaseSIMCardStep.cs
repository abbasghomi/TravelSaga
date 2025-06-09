using TravelSaga.Steps.Contracts;
using TravelSaga.Utils;

namespace TravelSaga.Steps
{
    // Step to purchase a SIM card as part of the travel saga. May randomly fail.
    public class PurchaseSimCardStep : ISagaStep
    {
        public string Name => "Purchase SIM Card";

        public async Task CompensateAsync()
        {
            "SIM card purchase cancelled.".WriteColored(ConsoleMessageType.Warning);
            await Task.Delay(100);
        }

        public async Task<bool> ExecuteAsync()
        {
            bool failed = FailureSimulator.ShouldFail(0.5);
            if (failed)
            {
                "SIM card purchase failed.".WriteColored(ConsoleMessageType.Fail);
                await Task.Delay(100);
                return false;
            }
            else
            {
                "SIM card purchased.".WriteColored(ConsoleMessageType.Success);
                await Task.Delay(100);
                return true;
            }
        }
    }
}