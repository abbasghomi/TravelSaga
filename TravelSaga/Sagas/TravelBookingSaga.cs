using TravelSaga.Sagas.Contracts;
using TravelSaga.Steps.Contracts;

namespace TravelSaga.Sagas
{
    // Orchestrates the execution of all saga steps. Compensates if any step fails.
    public class TravelBookingSaga : ISagaOrchestrator
    {
        private readonly Stack<ISagaStep> _completedSteps = new();
        private readonly List<ISagaStep> _steps;

        public TravelBookingSaga(List<ISagaStep> steps)
        {
            _steps = steps;
        }

        // Runs all steps in order. If a step fails, compensates completed steps.
        public async Task<bool> ExecuteAsync()
        {
            foreach (var step in _steps)
            {
                Console.WriteLine($"Starting step: {step.Name}");
                bool success = await step.ExecuteAsync();
                if (!success)
                {
                    Console.WriteLine($"Step failed: {step.Name}. Starting compensation...");
                    await CompensateAsync();
                    return false;
                }
                _completedSteps.Push(step);
            }
            Console.WriteLine("All steps completed successfully.");
            return true;
        }

        // Compensates (rolls back) completed steps in reverse order.
        private async Task CompensateAsync()
        {
            while (_completedSteps.Count > 0)
            {
                var step = _completedSteps.Pop();
                Console.WriteLine($"Compensating: {step.Name}");
                await step.CompensateAsync();
            }
        }
    }
}