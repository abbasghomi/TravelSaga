using TravelSaga.Steps.Contracts;
using TravelSaga.Utils;

namespace TravelSaga.Steps
{
    // Step to arrange a visa as part of the travel saga. May randomly fail.
    public class ArrangeVisaStep : ISagaStep
    {
        public string Name => "Arrange Visa";

        public async Task CompensateAsync()
        {
            "Visa arrangement cancelled.".WriteColored(ConsoleMessageType.Warning);
            await Task.Delay(100);
        }

        public async Task<bool> ExecuteAsync()
        {
            bool failed = FailureSimulator.ShouldFail(0.5);
            if (failed)
            {
                "Visa arrangement failed.".WriteColored(ConsoleMessageType.Fail);
                await Task.Delay(100);
                return false;
            }
            else
            {
                "Visa arranged.".WriteColored(ConsoleMessageType.Success);
                await Task.Delay(100);
                return true;
            }
        }
    }
}