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
            Console.WriteLine("Restaurant reservation cancelled.");
            await Task.Delay(100);
        }

        public async Task<bool> ExecuteAsync()
        {
            Console.WriteLine("Restaurant reserved.");
            await Task.Delay(100);
            return FailureSimulator.ShouldFail(0.7) ? false : true;
        }
    }
}