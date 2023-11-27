using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.VisualBasic;
using System.IO;

namespace CSharpLight
{
    internal class Program
    {
        static void Master(string[] args)
        {
            int[] array = new int[5] { 1, 2, 3, 4, 5 };
            int[,] array2 = new int[5,5];
            array = ExpansionArray(array);
            array2 = ExpansionArray(array2);
            for (int i = 0; i < array.Length; i++)
            {
                System.Console.WriteLine(array[i]);
            }
        }

        static int[] ExpansionArray(int[] array)
        {
            array = new int[array.Length + 1];
            return array;
        }


        static int[,] ExpansionArray(int[,] array)
        {
            array = new int[6,6]; 
            return array;
        }
    }
    public class Program2
    {
        static void Master()
        {
            int health = 5, maxHealth = 10;
            int mana =7, maxMana=10;
            DrawBar(health, maxHealth, ConsoleColor.Green);
            DrawBar(mana, maxMana, ConsoleColor.Blue, positionX:2);
        }
        static void DrawBar(int value, int maxValue, ConsoleColor colorConsole, int positionX = 0, int positionY = 0)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;
            string bar = "";

            for (int i = 0; i < value; i++)
            {
                bar+=" ";
            
            }
        Console.SetCursorPosition (positionX,positionY);
        Console.Write('[');
        Console.BackgroundColor = colorConsole;
        System.Console.Write(bar);
        Console.BackgroundColor = defaultColor;
        bar ="";
        for (int i = value; i < maxValue; i++)
        {
            bar +=" ";
        }
        System.Console.Write(']');
        }
    }
}