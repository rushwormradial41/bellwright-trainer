using BellwrightTrainer.Memory;

namespace BellwrightTrainer.Hacks;

/// <summary>
/// Provides unlimited stamina functionality for Bellwright.
/// </summary>
public class StaminaHack
{
    private readonly MemoryReader _memoryReader;
    private readonly IntPtr _staminaAddress;

    /// <summary>
    /// Initializes a new instance of the <see cref="StaminaHack"/> class.
    /// </summary>
    /// <param name="memoryReader">The memory reader instance for the target process.</param>
    /// <param name="staminaAddress">The base address of the stamina value in memory.</param>
    public StaminaHack(MemoryReader memoryReader, IntPtr staminaAddress)
    {
        _memoryReader = memoryReader;
        _staminaAddress = staminaAddress;
    }

    /// <summary>
    /// Enables or disables unlimited stamina by freezing the stamina value at a high constant.
    /// </summary>
    /// <param name="enable">True to enable unlimited stamina, false to disable.</param>
    public void SetUnlimitedStamina(bool enable)
    {
        if (enable)
        {
            // Set stamina to a large value (500.0f) to simulate unlimited stamina
            _memoryReader.WriteFloat(_staminaAddress, 500.0f);
        }
    }
}
