using System;
using System.Collections.Generic;
using System.Text;

namespace C__Collections
{
    internal class Assignment4
    {
        static void Main()
        {
            Stack<string> actions = new Stack<string>();
            actions.Push("Type A");
            actions.Push("Delete B");
            actions.Push("Type C");
            actions.Push("Paste D");

            Console.WriteLine("Undo:");
            for (int i = 0; i < 3; i++) Console.WriteLine(actions.Pop());

            Console.WriteLine($"Current Top: {actions.Peek()}");

            Stack<string> redo = new Stack<string>();
            redo.Push("Redo Delete B");
            Console.WriteLine($"Redo: {redo.Peek()}");
        }

    }
}
