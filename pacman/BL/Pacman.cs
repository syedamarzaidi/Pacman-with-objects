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
        public bool isNextObstacle(Cell next)
        {
            if (((mazeGrid.maze[next.getX(), next.getY()].getValue() == '%') || (mazeGrid.maze[next.getX(),next.getY()].getValue() == '#')))
            {
                return true;
            }
            return false;
        }
        public void moveToNextCell(Cell current,Cell next)
        {
            if (!isNextObstacle(next))
            {
                mazeGrid.maze[current.getX(), current.getY()].setValue(' ');
                Console.SetCursorPosition(current.getY(), current.getX());
                Console.Write(' ');
                if ((next.getValue()) == '.')
                {
                    score++;
                }
                x = next.getX();
                y = next.getY();
                draw();
            }
        }
        public void moveUp(Cell current,Cell next)
        {
            moveToNextCell(current, next);
        }
        public void moveLeft(Cell current,Cell next)
        {
            moveToNextCell(current, next);
        }
        public void moveRight(Cell current,Cell next)
        {
            moveToNextCell(current, next);
        }
        public void moveDown(Cell current,Cell next)
        {
            moveToNextCell(current, next);
        }
        public void move()
        {
          /*  Cell pacmanCurrentCell = mazeGrid.findPacman();
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                moveRight(pacmanCurrentCell, mazeGrid.getRightCell(pacmanCurrentCell));
            }
            else if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                moveLeft(pacmanCurrentCell, mazeGrid.getLeftCell(pacmanCurrentCell));
            }
            else if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                moveUp(pacmanCurrentCell, mazeGrid.getUpCell(pacmanCurrentCell));
            }
            else if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                moveDown(pacmanCurrentCell, mazeGrid.getDownCell(pacmanCurrentCell));
            }
            else if()
            */
        }
        public void printScore()
        {
            Console.SetCursorPosition(5, 26);
            Console.WriteLine("Score = :{0}", score);
        }
    }
}
