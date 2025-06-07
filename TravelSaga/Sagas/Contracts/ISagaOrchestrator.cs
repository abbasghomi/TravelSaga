namespace TravelSaga.Sagas.Contracts
{
    // Defines the contract for a saga orchestrator that can execute a saga workflow.
    public interface ISagaOrchestrator
    {
        Task<bool> ExecuteAsync(); // Runs the saga. Returns true if all steps succeed.
    }
}