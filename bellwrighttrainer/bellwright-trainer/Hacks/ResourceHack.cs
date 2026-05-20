using BellwrightTrainer.Memory;

namespace BellwrightTrainer.Hacks;

/// <summary>
/// Provides unlimited resources functionality for Bellwright.
/// </summary>
public class ResourceHack
{
    private readonly MemoryReader _memoryReader;
    private readonly IntPtr _resourceAddress;

    /// <summary>
    /// Initializes a new instance of the <see cref="ResourceHack"/> class.
    /// </summary>
    /// <param name="memoryReader">The memory reader instance for the target process.</param>
    /// <param name="resourceAddress">The base address of the resource array in memory.</param>
    public ResourceHack(MemoryReader memoryReader, IntPtr resourceAddress)
    {
        _memoryReader = memoryReader;
        _resourceAddress = resourceAddress;
    }

    /// <summary>
    /// Enables or disables unlimited resources by setting wood, stone, and food to high values.
    /// </summary>
    /// <param name="enable">True to enable unlimited resources, false to disable.</param>
    public void SetUnlimitedResources(bool enable)
    {
        if (enable)
        {
            // Assuming resources are stored as floats at offsets 0x00, 0x04, 0x08
            _memoryReader.WriteFloat(_resourceAddress + 0x00, 999.0f); // Wood
            _memoryReader.WriteFloat(_resourceAddress + 0x04, 999.0f); // Stone
            _memoryReader.WriteFloat(_resourceAddress + 0x08, 999.0f); // Food
        }
    }
}
