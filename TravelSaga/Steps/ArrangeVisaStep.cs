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
            Console.WriteLine("Visa arrangement cancelled.");
            await Task.Delay(100);
        }

        public async Task<bool> ExecuteAsync()
        {
            Console.WriteLine("Visa arranged.");
            await Task.Delay(100);
            return FailureSimulator.ShouldFail(0.5) ? false : true;
        }
    }
}