using BellwrightTrainer.Core;
using BellwrightTrainer.Memory;

namespace BellwrightTrainer;

/// <summary>
/// Main entry point for the Bellwright Trainer application.
/// </summary>
class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Bellwright Trainer v1.0");
        Console.WriteLine("Searching for Bellwright process...");

        var processManager = new ProcessManager("Bellwright-Win64-Shipping");
        if (!processManager.TryAttach())
        {
            Console.WriteLine("Bellwright process not found. Please start the game first.");
            return;
        }

        Console.WriteLine("Attached to Bellwright process.");

        var memoryReader = new MemoryReader(processManager.ProcessHandle);
        var healthHack = new HealthHack(memoryReader, 0x4A2B1C00); // Example base address
        var staminaHack = new StaminaHack(memoryReader, 0x4A2B1C10);
        var resourceHack = new ResourceHack(memoryReader, 0x4A2B1C20);

        Console.WriteLine("Activating cheats...");

        while (true)
        {
            healthHack.SetUnlimitedHealth(true);
            staminaHack.SetUnlimitedStamina(true);
            resourceHack.SetUnlimitedResources(true);

            await Task.Delay(100); // Poll every 100ms

            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                Console.WriteLine("Exiting...");
                break;
            }
        }

        processManager.Detach();
    }
}
