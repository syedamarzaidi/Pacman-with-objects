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
            //Math.Floor function to decide objects to move
            string path = "C:\\Users\\kali\\Documents\\Visual Studio 2015\\Projects\\pacman\\pacman\\files\\maze.txt";
            Grid mazeGrid = new Grid(24, 71, path);
            Pacman player = new Pacman(5, 10, mazeGrid);
            Ghost ghost1 = new Ghost(10, 15, 'H', "left", 0.1f, ' ', mazeGrid);
            mazeGrid.draw();
            player.draw();
            ghost1.draw();
            Console.ReadKey();
            ghost1.remove();
            Console.ReadKey();
        }
    }
}

