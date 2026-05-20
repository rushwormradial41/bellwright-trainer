using Xunit;
using BellwrightTrainer.Core;

namespace BellwrightTrainer.Tests;

/// <summary>
/// Unit tests for ProcessManager class.
/// </summary>
public class ProcessManagerTests
{
    [Fact]
    public void TryAttach_ReturnsFalse_WhenProcessNotFound()
    {
        // Arrange
        var manager = new ProcessManager("NonExistentProcess");

        // Act
        var result = manager.TryAttach();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Detach_DoesNotThrow_WhenHandleIsZero()
    {
        // Arrange
        var manager = new ProcessManager("TestProcess");

        // Act & Assert
        var exception = Record.Exception(() => manager.Detach());
        Assert.Null(exception);
    }
}
