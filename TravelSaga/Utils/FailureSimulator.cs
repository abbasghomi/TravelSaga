namespace TravelSaga.Utils
{
    // Utility to simulate random failures for testing saga compensation logic.
    public static class FailureSimulator
    {
        private static readonly Random Random = new();
        public static bool ShouldFail(double probability = 0.5)
        {
            return Random.NextDouble() < probability;
        }
    }
}