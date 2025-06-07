using TravelSaga.Utils;
using Xunit;

namespace TravelSagaTest.UtilsTests
{
    // Tests for FailureSimulator utility
    public class FailureSimulatorTests
    {
        [Fact(DisplayName = "ShouldFail_Default_ReturnsBool")]
        public void ShouldFail_Default_ReturnsBool()
        {
            // Act
            var result = FailureSimulator.ShouldFail();
            // Assert
            Assert.IsType<bool>(result);
        }

        [Fact(DisplayName = "ShouldFail_ProbabilityZero_AlwaysFalse")]
        public void ShouldFail_ProbabilityZero_AlwaysFalse()
        {
            // Act & Assert
            for (int i = 0; i < 10; i++)
                Assert.False(FailureSimulator.ShouldFail(0));
        }

        [Fact(DisplayName = "ShouldFail_ProbabilityOne_AlwaysTrue")]
        public void ShouldFail_ProbabilityOne_AlwaysTrue()
        {
            // Act & Assert
            for (int i = 0; i < 10; i++)
                Assert.True(FailureSimulator.ShouldFail(1));
        }
    }
}
