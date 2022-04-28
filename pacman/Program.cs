using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pacman.BL;
using System.Threading;
namespace pacman
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gameRunning = true;
            //Math.Floor function to decide objects to move
            string path = "maze.txt";
            Grid mazeGrid = new Grid(24, 71, path);
            Cell pacmanLocation = mazeGrid.findPacman();
            Cell horizontalGhostLocation = mazeGrid.findGhost('H');
            Cell verticalGhostLocation = mazeGrid.findGhost('V');
            Cell randomGhostLocation = mazeGrid.findGhost('R');
            Cell smartGhost = mazeGrid.findGhost('S');
            Pacman player = new Pacman(pacmanLocation.getX(), pacmanLocation.getY(), mazeGrid);
            Ghost ghost1 = new Ghost(horizontalGhostLocation.getX(), horizontalGhostLocation.getY(), 'H', "left", 0.4f, ' ', mazeGrid); //Horizontal Ghost
            Ghost ghost2 = new Ghost(verticalGhostLocation.getX(), verticalGhostLocation.getY(), 'V', "down", 0.9f, ' ', mazeGrid); // Vertical ghost
            Ghost ghost3 = new Ghost(randomGhostLocation.getX(), randomGhostLocation.getY(), 'R', "random", 0.8f, ' ', mazeGrid); //  Random moving ghost
            Ghost ghost4 = new Ghost(smartGhost.getX(), smartGhost.getY(), 'S', "smart", 0.6f, ' ', mazeGrid);//Smart ghost
            List<Ghost> enemies = new List<Ghost>();
            enemies.Add(ghost1);
            enemies.Add(ghost2);
            enemies.Add(ghost3);
            enemies.Add(ghost4);
            mazeGrid.draw();
            player.draw();
            while (gameRunning)
            {
                Thread.Sleep(90);
                player.printScore();
                player.move();
                foreach(Ghost g in enemies)
                {
                    g.draw();
                    g.move();
                }
                if(mazeGrid.isStoppingCondition() == true)
                {
                    gameRunning = false;
                } 
            }
            Console.ReadKey();
        }
    }
}

