using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pacman.BL;
using pacman.UI;
using pacman.DL;
using System.Threading;
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
            Ghost ghost1 = new Ghost(22, 4, 'H', "left", 0.4f, ' ', mazeGrid); //Horizontal Ghost
            Ghost ghost2 = new Ghost(2, 2, 'V', "down", 0.9f, ' ', mazeGrid); // Vertical ghost
            Ghost ghost3 = new Ghost(9, 24, 'R', " ", 0.8f, ' ', mazeGrid); //  Random moving ghost
            //Ghost ghost3 = new Ghost();
            mazeGrid.draw();
           // player.draw();
            ghost1.draw();
            ghost2.draw();
            ghost3.draw();
            while (true)
            {
                Thread.Sleep(60);
                ghost1.move();//Move horizontal ghost
              ghost2.move();//move vertical ghost
                ghost3.move();//move random ghost
                              // player.moveToNextCell(mazeGrid.findPacman(), mazeGrid.getDownCell(mazeGrid.findPacman()));
                              // Console.ReadKey();
                player.printScore();
            }
           // Console.ReadKey();
        }
    }
}

