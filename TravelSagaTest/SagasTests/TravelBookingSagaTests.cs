using TravelSaga.Sagas;
using TravelSaga.Steps.Contracts;
using Xunit;

namespace TravelSagaTest.SagasTests
{
    // Tests for TravelBookingSaga orchestrator
    public class TravelBookingSagaTests
    {
        #region Public Methods

        [Fact(DisplayName = "ExecuteAsync_AllStepsSucceed_ReturnsTrue")]
        public async Task ExecuteAsync_AllStepsSucceed_ReturnsTrue()
        {
            // Arrange
            var steps = new List<ISagaStep> { new AlwaysSuccessStep(), new AlwaysSuccessStep() };
            var saga = new TravelBookingSaga(steps);
            // Act
            var result = await saga.ExecuteAsync();
            // Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "ExecuteAsync_EmptySteps_ReturnsTrue")]
        public async Task ExecuteAsync_EmptySteps_ReturnsTrue()
        {
            // Arrange
            var saga = new TravelBookingSaga(new List<ISagaStep>());
            // Act
            var result = await saga.ExecuteAsync();
            // Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "ExecuteAsync_StepFails_CompensatesPreviousSteps")]
        public async Task ExecuteAsync_StepFails_CompensatesPreviousSteps()
        {
            // Arrange
            var track1 = new TrackCompensateStep();
            var track2 = new TrackCompensateStep();
            var steps = new List<ISagaStep> { track1, track2, new AlwaysFailStep() };
            var saga = new TravelBookingSaga(steps);
            // Act
            var result = await saga.ExecuteAsync();
            // Assert
            Assert.False(result);
            Assert.True(track1.Compensated);
            Assert.True(track2.Compensated);
        }

        #endregion Public Methods

        // Helper: Step that always fails
        private class AlwaysFailStep : ISagaStep
        {
            public string Name => "AlwaysFail";

            public Task CompensateAsync() => Task.CompletedTask;

            public Task<bool> ExecuteAsync() => Task.FromResult(false);
        }

        // Helper: Step that always succeeds
        private class AlwaysSuccessStep : ISagaStep
        {
            public string Name => "AlwaysSuccess";

            public Task CompensateAsync() => Task.CompletedTask;

            public Task<bool> ExecuteAsync() => Task.FromResult(true);
        }

        // Helper: Step that tracks compensation
        private class TrackCompensateStep : ISagaStep
        {
            public bool Compensated { get; private set; }
            public string Name => "TrackCompensate";

            public Task CompensateAsync()
            { Compensated = true; return Task.CompletedTask; }

            public Task<bool> ExecuteAsync() => Task.FromResult(true);
        }
    }
}