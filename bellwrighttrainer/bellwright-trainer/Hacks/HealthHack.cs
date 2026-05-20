using BellwrightTrainer.Memory;

namespace BellwrightTrainer.Hacks;

/// <summary>
/// Provides unlimited health functionality for Bellwright.
/// </summary>
public class HealthHack
{
    private readonly MemoryReader _memoryReader;
    private readonly IntPtr _healthAddress;

    /// <summary>
    /// Initializes a new instance of the <see cref="HealthHack"/> class.
    /// </summary>
    /// <param name="memoryReader">The memory reader instance for the target process.</param>
    /// <param name="healthAddress">The base address of the health value in memory.</param>
    public HealthHack(MemoryReader memoryReader, IntPtr healthAddress)
    {
        _memoryReader = memoryReader;
        _healthAddress = healthAddress;
    }

    /// <summary>
    /// Enables or disables unlimited health by freezing the health value at a high constant.
    /// </summary>
    /// <param name="enable">True to enable unlimited health, false to disable.</param>
    public void SetUnlimitedHealth(bool enable)
    {
        if (enable)
        {
            // Set health to a large value (1000.0f) to simulate unlimited health
            _memoryReader.WriteFloat(_healthAddress, 1000.0f);
        }
        // When disabled, we simply stop overwriting; the game will manage health normally
    }
}
