// Entry point for the TravelSaga application. Runs the travel booking saga.
using TravelSaga.Services;

var orchestrator = new TravelSagaOrchestratorService();
await orchestrator.RunAsync();