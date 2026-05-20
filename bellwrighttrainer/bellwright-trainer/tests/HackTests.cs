using Xunit;
using BellwrightTrainer.Hacks;
using BellwrightTrainer.Memory;

namespace BellwrightTrainer.Tests;

/// <summary>
/// Unit tests for hack classes.
/// </summary>
public class HackTests
{
    [Fact]
    public void HealthHack_SetUnlimitedHealth_DoesNotThrow()
    {
        // Arrange
        var invalidReader = new MemoryReader(IntPtr.Zero);
        var hack = new HealthHack(invalidReader, new IntPtr(0x1000));

        // Act & Assert
        var exception = Record.Exception(() => hack.SetUnlimitedHealth(true));
        Assert.Null(exception);
    }

    [Fact]
    public void StaminaHack_SetUnlimitedStamina_DoesNotThrow()
    {
        // Arrange
        var invalidReader = new MemoryReader(IntPtr.Zero);
        var hack = new StaminaHack(invalidReader, new IntPtr(0x2000));

        // Act & Assert
        var exception = Record.Exception(() => hack.SetUnlimitedStamina(true));
        Assert.Null(exception);
    }

    [Fact]
    public void ResourceHack_SetUnlimitedResources_DoesNotThrow()
    {
        // Arrange
        var invalidReader = new MemoryReader(IntPtr.Zero);
        var hack = new ResourceHack(invalidReader, new IntPtr(0x3000));

        // Act & Assert
        var exception = Record.Exception(() => hack.SetUnlimitedResources(true));
        Assert.Null(exception);
    }
}
