using TravelSaga.Steps.Contracts;
using TravelSaga.Utils;

namespace TravelSaga.Steps
{
    // Step to rent a car as part of the travel saga.
    public class RentCarStep : ISagaStep
    {
        public string Name => "Rent Car";

        public async Task CompensateAsync()
        {
            "Car rental cancelled.".WriteColored(ConsoleMessageType.Warning);
            await Task.Delay(100); // Simulate async work
        }

        public async Task<bool> ExecuteAsync()
        {
            "Car rented.".WriteColored(ConsoleMessageType.Success);
            await Task.Delay(100); // Simulate async work
            return true;
        }
    }
}