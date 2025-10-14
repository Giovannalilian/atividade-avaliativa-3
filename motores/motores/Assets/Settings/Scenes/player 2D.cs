using System;
using System.Threading;

class Program
{
    static int x = 10;
    static int y = 10;

    static void Main()
    {
        Console.CursorVisible = false;
        while (true)
        {
            DrawCharacter();

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                MoveCharacter(keyInfo.Key);
            }

            Thread.Sleep(50); // Pequena pausa para não sobrecarregar o CPU
        }
    }

    static void DrawCharacter()
    {
        Console.Clear();
        Console.SetCursorPosition(x, y);
        Console.Write("@");
    }

    static void MoveCharacter(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.W:
                if (y > 0) y--;
                break;
            case ConsoleKey.S:
                if (y < Console.WindowHeight - 1) y++;
                break;
            case ConsoleKey.A:
                if (x > 0) x--;
                break;
            case ConsoleKey.D:
                if (x < Console.WindowWidth - 1) x++;
                break;
        }
    }
}