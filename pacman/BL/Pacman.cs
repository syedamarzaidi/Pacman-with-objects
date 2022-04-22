using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pacman.BL
{
    class Pacman
    {
        public Pacman(int x,int y,Grid mazeGrid)
        {
            this.x = x;
            this.y = y;
            this.mazeGrid = mazeGrid;
        }
        private int x;
        private int y;
        private int score;
        private Grid mazeGrid;
        public void setX(int x)
        {
            this.x = x;
        }
        public void setY(int y)
        {
            this.y = y;
        }
        public void setScore(int score)
        {
            this.score = score;
        }
        public void setXY(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        public void draw()
        {
            Cell pacman = new Cell(x, y, 'P');
            mazeGrid.maze[x, y] = pacman;
            Console.SetCursorPosition(y, x);
            Console.Write(pacman.getValue());
        }

    }
}
