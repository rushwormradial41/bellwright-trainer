using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BellwrightTrainer.Core;

/// <summary>
/// Manages attachment and detachment from a target process.
/// </summary>
public class ProcessManager
{
    private readonly string _processName;
    private IntPtr _processHandle;

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool CloseHandle(IntPtr hObject);

    private const uint PROCESS_ALL_ACCESS = 0x1F0FFF;

    public IntPtr ProcessHandle => _processHandle;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProcessManager"/> class.
    /// </summary>
    /// <param name="processName">The name of the target process (without extension).</param>
    public ProcessManager(string processName)
    {
        _processName = processName;
    }

    /// <summary>
    /// Attempts to attach to the target process.
    /// </summary>
    /// <returns>True if attachment succeeded, false otherwise.</returns>
    public bool TryAttach()
    {
        var processes = Process.GetProcessesByName(_processName);
        if (processes.Length == 0)
            return false;

        var targetProcess = processes[0];
        _processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, targetProcess.Id);
        return _processHandle != IntPtr.Zero;
    }

    /// <summary>
    /// Detaches from the target process by closing the handle.
    /// </summary>
    public void Detach()
    {
        if (_processHandle != IntPtr.Zero)
        {
            CloseHandle(_processHandle);
            _processHandle = IntPtr.Zero;
        }
    }
}
