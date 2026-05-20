using System.Runtime.InteropServices;

namespace BellwrightTrainer.Memory;

/// <summary>
/// Provides low-level memory reading and writing operations for a target process.
/// </summary>
public class MemoryReader
{
    private readonly IntPtr _processHandle;

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, out int lpNumberOfBytesWritten);

    /// <summary>
    /// Initializes a new instance of the <see cref="MemoryReader"/> class.
    /// </summary>
    /// <param name="processHandle">Handle to the target process with appropriate access rights.</param>
    public MemoryReader(IntPtr processHandle)
    {
        _processHandle = processHandle;
    }

    /// <summary>
    /// Reads a float value from a specified memory address.
    /// </summary>
    /// <param name="address">The memory address to read from.</param>
    /// <returns>The float value read from memory.</returns>
    public float ReadFloat(IntPtr address)
    {
        byte[] buffer = new byte[4];
        if (ReadProcessMemory(_processHandle, address, buffer, 4, out _))
        {
            return BitConverter.ToSingle(buffer, 0);
        }
        return 0f;
    }

    /// <summary>
    /// Writes a float value to a specified memory address.
    /// </summary>
    /// <param name="address">The memory address to write to.</param>
    /// <param name="value">The float value to write.</param>
    /// <returns>True if the write succeeded, false otherwise.</returns>
    public bool WriteFloat(IntPtr address, float value)
    {
        byte[] buffer = BitConverter.GetBytes(value);
        return WriteProcessMemory(_processHandle, address, buffer, 4, out _);
    }
}
