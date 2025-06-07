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
            Console.WriteLine("SIM card purchase cancelled.");
            await Task.Delay(100);
        }

        public async Task<bool> ExecuteAsync()
        {
            Console.WriteLine("SIM card purchased.");
            await Task.Delay(100);
            return FailureSimulator.ShouldFail(0.5) ? false : true;
        }
    }
}