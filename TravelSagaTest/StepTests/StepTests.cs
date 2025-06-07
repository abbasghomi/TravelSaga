using TravelSaga.Steps;
using TravelSaga.Steps.Contracts;
using Xunit;

namespace TravelSagaTest.StepTests
{
    public class StepCompensateTests
    {
        [Theory(DisplayName = "CompensateAsync_DoesNotThrow_ForAllSteps")]
        [InlineData(typeof(BookFlightStep))]
        [InlineData(typeof(ReserveHotelStep))]
        [InlineData(typeof(RentCarStep))]
        [InlineData(typeof(BookTravelInsuranceStep))]
        [InlineData(typeof(ReserveTourStep))]
        [InlineData(typeof(BookAirportTransferStep))]
        [InlineData(typeof(ReserveRestaurantStep))]
        [InlineData(typeof(BookEventTicketsStep))]
        [InlineData(typeof(ArrangeVisaStep))]
        [InlineData(typeof(PurchaseSimCardStep))]
        public async Task CompensateAsync_DoesNotThrow_ForAllSteps(Type stepType)
        {
            var step = (ISagaStep)Activator.CreateInstance(stepType)!;
            await step.CompensateAsync();
        }
    }

    public class StepExecuteTests
    {
        [Theory(DisplayName = "ExecuteAsync_AlwaysSucceeds_ForStableSteps")]
        [InlineData(typeof(BookFlightStep))]
        [InlineData(typeof(ReserveHotelStep))]
        [InlineData(typeof(RentCarStep))]
        [InlineData(typeof(BookTravelInsuranceStep))]
        [InlineData(typeof(ReserveTourStep))]
        [InlineData(typeof(BookAirportTransferStep))]
        public async Task ExecuteAsync_AlwaysSucceeds_ForStableSteps(Type stepType)
        {
            var step = (ISagaStep)Activator.CreateInstance(stepType)!;
            var result = await step.ExecuteAsync();
            Assert.True(result);
        }

        [Theory(DisplayName = "ExecuteAsync_CanFailOrSucceed_ForUnstableSteps")]
        [InlineData(typeof(ReserveRestaurantStep))]
        [InlineData(typeof(BookEventTicketsStep))]
        [InlineData(typeof(ArrangeVisaStep))]
        [InlineData(typeof(PurchaseSimCardStep))]
        public async Task ExecuteAsync_CanFailOrSucceed_ForUnstableSteps(Type stepType)
        {
            var step = (ISagaStep)Activator.CreateInstance(stepType)!;
            bool sawTrue = false, sawFalse = false;
            for (int i = 0; i < 20; i++)
            {
                var result = await step.ExecuteAsync();
                if (result) sawTrue = true; else sawFalse = true;
                if (sawTrue && sawFalse) break;
            }
            Assert.True(sawTrue && sawFalse);
        }
    }

    public class StepNameTests
    {
        [Theory(DisplayName = "Step_Name_Is_Correct_ForAllSteps")]
        [InlineData(typeof(BookFlightStep), "Book Flight")]
        [InlineData(typeof(ReserveHotelStep), "Reserve Hotel")]
        [InlineData(typeof(RentCarStep), "Rent Car")]
        [InlineData(typeof(BookTravelInsuranceStep), "Book Travel Insurance")]
        [InlineData(typeof(ReserveTourStep), "Reserve Tour")]
        [InlineData(typeof(BookAirportTransferStep), "Book Airport Transfer")]
        [InlineData(typeof(ReserveRestaurantStep), "Reserve Restaurant")]
        [InlineData(typeof(BookEventTicketsStep), "Book Event Tickets")]
        [InlineData(typeof(ArrangeVisaStep), "Arrange Visa")]
        [InlineData(typeof(PurchaseSimCardStep), "Purchase SIM Card")]
        public void Name_ReturnsExpected_ForAllSteps(Type stepType, string expectedName)
        {
            var step = (ISagaStep)Activator.CreateInstance(stepType)!;
            Assert.Equal(expectedName, step.Name);
        }
    }
}