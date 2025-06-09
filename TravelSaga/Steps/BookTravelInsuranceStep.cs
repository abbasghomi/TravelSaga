using TravelSaga.Steps.Contracts;
using TravelSaga.Utils;

namespace TravelSaga.Steps
{
    // Step to book travel insurance as part of the travel saga.
    public class BookTravelInsuranceStep : ISagaStep
    {
        public string Name => "Book Travel Insurance";

        public async Task CompensateAsync()
        {
            "Travel insurance booking cancelled.".WriteColored(ConsoleMessageType.Warning);
            await Task.Delay(100);
        }

        public async Task<bool> ExecuteAsync()
        {
            "Travel insurance booked.".WriteColored(ConsoleMessageType.Success);
            await Task.Delay(100);
            return true;
        }
    }
}