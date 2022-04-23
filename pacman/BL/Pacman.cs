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
            this.pacmanCurrentCell = new Cell(x, y, 'P');
        }
        private int x;
        private int y;
        private int score;
        Cell pacmanCurrentCell;
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
        public void remove()
        {
            pacmanCurrentCell.setValue(' ');
            mazeGrid.maze[x, y] = pacmanCurrentCell;
            Console.SetCursorPosition(y, x);
            Console.Write(pacmanCurrentCell.getValue());
        }
        public void moveLeft()
        {
            remove();
            setY(y - 1);
            draw();
        }
        public void moveRight()
        {
            remove();
            setY(y + 1);
            draw();
        }
        public void moveUp()
        {
            remove();
            setX(x - 1);
            draw();
        }
        public void moveDown()
        {
            remove();
            setX(x + 1);
            draw();
        }

    }
}
