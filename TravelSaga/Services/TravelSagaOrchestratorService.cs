using TravelSaga.Sagas;
using TravelSaga.Sagas.Contracts;
using TravelSaga.Steps;
using TravelSaga.Steps.Contracts;
using TravelSaga.Utils;

namespace TravelSaga.Services
{
    // Service to configure and run the travel booking saga.
    public class TravelSagaOrchestratorService
    {
        private readonly ISagaOrchestrator _sagaOrchestrator;

        // Sets up the saga steps and orchestrator.
        public TravelSagaOrchestratorService()
        {
            var steps = new List<ISagaStep>
            {
                new BookFlightStep(),
                new ReserveHotelStep(),
                new RentCarStep(),
                new BookTravelInsuranceStep(),
                new ReserveTourStep(),
                new BookAirportTransferStep(),
                new ReserveRestaurantStep(),
                new BookEventTicketsStep(),
                new ArrangeVisaStep(),
                new PurchaseSimCardStep()
            };
            _sagaOrchestrator = new TravelBookingSaga(steps);
        }

        // Runs the saga and prints the result.
        public async Task RunAsync()
        {
            Console.WriteLine("\n--- Travel Booking Saga Starting ---\n");
            bool result = await _sagaOrchestrator.ExecuteAsync();
            Console.Write("\n--- Travel Booking Saga Completed: ");

            if (result)
            {
                "SUCCESS ---".WriteColored(ConsoleMessageType.Success);
            }
            else
            {
                "FAILURE ---".WriteColored(ConsoleMessageType.Fail);
            }
        }
    }
}