using Xunit;
using BellwrightTrainer.Memory;
using Moq;

namespace BellwrightTrainer.Tests;

/// <summary>
/// Unit tests for MemoryReader class.
/// </summary>
public class MemoryReaderTests
{
    [Fact]
    public void ReadFloat_ReturnsZero_WhenProcessHandleInvalid()
    {
        // Arrange
        var invalidHandle = IntPtr.Zero;
        var reader = new MemoryReader(invalidHandle);

        // Act
        var result = reader.ReadFloat(new IntPtr(0x12345678));

        // Assert
        Assert.Equal(0f, result);
    }

    [Fact]
    public void WriteFloat_ReturnsFalse_WhenProcessHandleInvalid()
    {
        // Arrange
        var invalidHandle = IntPtr.Zero;
        var reader = new MemoryReader(invalidHandle);

        // Act
        var result = reader.WriteFloat(new IntPtr(0x12345678), 100.0f);

        // Assert
        Assert.False(result);
    }
}
