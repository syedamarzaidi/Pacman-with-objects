using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pacman.BL;
using pacman.UI;
using pacman.DL;

namespace pacman
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid g = new Grid(21, 71, "C:\\Users\\kali\\Documents\\Visual Studio 2015\\Projects\\pacman\\pacman\\files\\maze.txt");
            Grid.draw();
            Console.ReadKey();
        }
    }
}

