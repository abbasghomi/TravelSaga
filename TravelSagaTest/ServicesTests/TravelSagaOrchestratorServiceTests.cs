using TravelSaga.Services;
using Xunit;

namespace TravelSagaTest.ServicesTests
{
    // Tests for TravelSagaOrchestratorService
    public class TravelSagaOrchestratorServiceTests
    {
        [Fact(DisplayName = "RunAsync_CompletesWithoutException")]
        public async Task RunAsync_CompletesWithoutException()
        {
            // Arrange
            var orchestrator = new TravelSagaOrchestratorService();
            // Act & Assert
            await orchestrator.RunAsync();
        }

        [Fact(DisplayName = "Constructor_CreatesInstance")]
        public void Constructor_CreatesInstance()
        {
            // Act
            var orchestrator = new TravelSagaOrchestratorService();
            // Assert
            Assert.NotNull(orchestrator);
        }
    }
}
