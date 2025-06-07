using TravelSaga.Steps.Contracts;

namespace TravelSaga.Steps
{
    // Step to reserve a tour as part of the travel saga.
    public class ReserveTourStep : ISagaStep
    {
        public string Name => "Reserve Tour";

        public async Task CompensateAsync()
        {
            Console.WriteLine("Tour reservation cancelled.");
            await Task.Delay(100);
        }

        public async Task<bool> ExecuteAsync()
        {
            Console.WriteLine("Tour reserved.");
            await Task.Delay(100);
            return true;
        }
    }
}