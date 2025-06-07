using TravelSaga.Steps.Contracts;

namespace TravelSaga.Steps
{
    // Step to rent a car as part of the travel saga.
    public class RentCarStep : ISagaStep
    {
        public string Name => "Rent Car";

        public async Task CompensateAsync()
        {
            Console.WriteLine("Car rental cancelled.");
            await Task.Delay(100); // Simulate async work
        }

        public async Task<bool> ExecuteAsync()
        {
            Console.WriteLine("Car rented.");
            await Task.Delay(100); // Simulate async work
            return true;
        }
    }
}