using System;
using System.Diagnostics;

public class PositionSynchronizer
{
    private static PositionSynchronizer instance;
    private static object lockObject = new object();

    private PositionSynchronizer()
    {
        Debug.WriteLine("Hello World Position Synchroniser");
    }

    public static PositionSynchronizer Instance
    {
        get
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new PositionSynchronizer();
                }
                return instance;
            }
        }
    }

    public void SynchronizeScene()
    {
        // Hier kannst du die Synchronisationslogik für die Szene implementieren
        Console.WriteLine("Synchronizing scene...");
        // Füge hier den Code hinzu, der die Szene synchronisiert
    }
}
