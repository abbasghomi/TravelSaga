namespace TravelSaga.Steps.Contracts
{
    // Represents a single step in the saga. Each step must be executable and compensatable.
    public interface ISagaStep
    {
        Task<bool> ExecuteAsync(); // Executes the step. Returns true if successful.
        Task CompensateAsync();    // Reverts the step if needed.
        string Name { get; }       // Name of the step for logging and tracking.
    }
}