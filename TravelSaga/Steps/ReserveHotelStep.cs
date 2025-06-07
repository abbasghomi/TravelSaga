using TravelSaga.Steps.Contracts;

namespace TravelSaga.Steps
{
    // Step to reserve a hotel as part of the travel saga.
    public class ReserveHotelStep : ISagaStep
    {
        public string Name => "Reserve Hotel";

        public async Task CompensateAsync()
        {
            Console.WriteLine("Hotel reservation cancelled.");
            await Task.Delay(100);
        }

        public async Task<bool> ExecuteAsync()
        {
            Console.WriteLine("Hotel reserved.");
            await Task.Delay(100);
            return true;
        }
    }
}