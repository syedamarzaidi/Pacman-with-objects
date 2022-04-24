using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace pacman.BL
{
    class Ghost
    {
        public Ghost(int X, int Y, char ghostCharacter, string ghostDirection, float speed, char previousItem,Grid mazeGrid)
        {
            this.X = X;
            this.Y = Y;
            this.ghostCharacter = ghostCharacter;
            this.ghostDirection = ghostDirection;
            this.speed = speed;
            this.previousItem = previousItem;
            this.currentGhostCell = new Cell(X, Y, this.ghostCharacter);
            this.mazeGrid = mazeGrid;
            this.ghostMovingPosition = ghostDirection;
            this.smartFlag = true;
        }
        private int X;
        private int Y;
        private string ghostDirection;
        private char ghostCharacter;
        private float speed;
        private char previousItem = ' ';
        private float deltaChange;
        private Cell currentGhostCell;
        private Grid mazeGrid;
        private string ghostMovingPosition; //This will help in deciding to move in case of vertical or horizontal
        private bool smartFlag;
        Random rd = new Random();
        public void setX(int X)
        {
            if ((mazeGrid.maze[X,Y].getValue()) != '#' && (mazeGrid.maze[X, Y].getValue()) != '%')
            {
                this.X = X;
            }
        }
        public void setY(int Y)
        {
            if((mazeGrid.maze[X,Y].getValue()) != '#' && (mazeGrid.maze[X, Y].getValue()) != '%')
            {
                this.Y = Y;
            }
        }
        public void setXY(int X,int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public void setGhostCharacter(char ghostCharacter)
        {
            this.ghostCharacter = ghostCharacter;
        }
        public void setGhostDirection(string ghostDirection)
        {
                this.ghostDirection = ghostDirection;
        }
        public void setGhostPosition()
        {
            if ((Y == mazeGrid.getColSize() - 2) || Y == 1)
            {
                // helping horizontal ghost to change his direction 
                if (ghostMovingPosition == "left")
                {
                    this.ghostMovingPosition = "right";
                }
                else if (ghostMovingPosition == "right")
                {
                    this.ghostMovingPosition = "left";
                }
            }
            else if(X == mazeGrid.getRowSize()-2 || X == 1)
            {
                //Helping vertical ghost to change his direction
                if (ghostMovingPosition == "up")
                {
                    this.ghostMovingPosition = "down";
                }
                else if (ghostMovingPosition == "down")
                {
                    this.ghostMovingPosition = "up";
                }
            }
        }
        public string getDirection()
        {
            return this.ghostDirection;
        }
        public char getGhostCharacter()
        {
            return this.ghostCharacter;
        }
        public float getDelta()
        {
            return this.deltaChange;
        }
        public int getGhostX()
        {
            return this.X;
        }
        public int getGhostY()
        {
            return this.Y;
        }
        public void changeDelta()
        {
            this.deltaChange = this.deltaChange + speed;
        }

        public void setDeltaToZero()
        {
             this.deltaChange = 0;
        }
        public void remove()
        {
            currentGhostCell.setValue(' ');
            mazeGrid.maze[X, Y] = currentGhostCell;
            Console.SetCursorPosition(Y, X);
            Console.Write(' ');
        }
        public void showPreviousItem()
        {
            Console.SetCursorPosition(Y, X);
            Console.Write(previousItem);
        }
        public void setPreviousItem()
        {
            if ((mazeGrid.maze[X, Y].getValue()) == ' ' || (mazeGrid.maze[X, Y].getValue()) == '.')
            {
                previousItem = mazeGrid.maze[X, Y].getValue();
            }
        }
        public void draw()
        {
            Cell c = new Cell(X, Y, ghostCharacter);
            mazeGrid.maze[X, Y].setValue(ghostCharacter);
            Console.SetCursorPosition(Y, X);
            Console.Write(ghostCharacter);
        }
        public void move()
        {
            changeDelta();
            if(Math.Floor(getDelta()) == 1)
            {
                if(ghostCharacter == 'H')
                {
                    moveHorizontal();
                }
                else if(ghostCharacter == 'V')
                {
                    moveVertical();
                }
                else if(ghostCharacter == 'R')
                {
                    moveRandom('R');
                }
                else if(ghostCharacter == 'S')
                {
                    moveSmart('S');
                }
                setDeltaToZero();
            }
        }
        public void moveHorizontal()
        {
            setGhostPosition(); //Reversing the direction of ghost if ghost is blocked
            Cell ghostCurrentCell = mazeGrid.findGhost('H');
            if (ghostMovingPosition == "left")
            {
                moveLeft(ghostCurrentCell,mazeGrid.getLeftCell(ghostCurrentCell));
            }
            else if(ghostMovingPosition == "right")
            {
                moveRight(ghostCurrentCell,mazeGrid.getRightCell(ghostCurrentCell));
            }
        }
        public void moveVertical()
        {
            setGhostPosition(); //reversing the direction of ghost if ghost is blocked
            Cell ghostCurrentCell = mazeGrid.findGhost('V');
            if (ghostMovingPosition == "up")
            {
                moveUp(ghostCurrentCell,mazeGrid.getUpCell(ghostCurrentCell));
            }
            else if (ghostMovingPosition == "down")
            {
                moveDown(ghostCurrentCell,mazeGrid.getDownCell(ghostCurrentCell));
            }
        }
        public void moveRandom(char ghostCharacter)
        {
            int direction = generateRandom();
            Cell ghost = mazeGrid.findGhost(ghostCharacter);
            if (direction == 1)
            {
                moveRight(ghost,mazeGrid.getRightCell(ghost));
            }
            else if(direction == 2)
            {
                moveLeft(ghost,mazeGrid.getLeftCell(ghost));
            }
            else if(direction == 3)
            {
                moveDown(ghost,mazeGrid.getDownCell(ghost));
            }
            else if(direction == 4)
            {
                moveUp(ghost,mazeGrid.getUpCell(ghost));
            }
        }
        public int generateRandom()
        {
            int num = rd.Next(1, 5);
            return num;
        }
        public void moveGhostToNextCell(Cell current,Cell next)
        {
            if (!isObstacleNext(next))
            {
                if (next.isPacmanPresent())
                {
                    mazeGrid.setIsPacmanCaught("CAUGHT");
                }
                mazeGrid.maze[current.getX(), current.getY()].setValue(previousItem);
                Console.SetCursorPosition(current.getY(), current.getX());
                Console.Write(previousItem);
                X = next.getX();
                Y = next.getY();
                setPreviousItem();
            }
            draw();
        }
        public bool isObstacleNext(Cell next)
        {
            if(mazeGrid.maze[next.getX(),next.getY()].getValue() == '#' || mazeGrid.maze[next.getX(), next.getY()].getValue() == '%')
            {
                return true;
            }
            return false;
        }
        public void  moveLeft(Cell current,Cell next)
        {
            moveGhostToNextCell(current, next);
        }
        public void moveRight(Cell current,Cell next)
        {
            moveGhostToNextCell(current, next);
        }
        public void moveUp(Cell current,Cell next)
        {
            moveGhostToNextCell(current, next);
        }
        public void moveDown(Cell current,Cell next)
        {
            moveGhostToNextCell(current, next);
        }
        public void moveSmart(char ghostCharacter)
        {
            Cell ghost = mazeGrid.findGhost(ghostCharacter);
            Cell pacman = mazeGrid.findPacman();
            string command = decideSmartDirection(ghost, pacman);
            if(smartFlag == true)
            {
                if (command != null)
                {
                    if (command == "left")
                    {
                        moveLeft(ghost, mazeGrid.getLeftCell(ghost));
                    }
                    else if (command == "right")
                    {
                        moveRight(ghost, mazeGrid.getRightCell(ghost));
                    }
                    else if (command == "up")
                    {
                        moveUp(ghost, mazeGrid.getUpCell(ghost));
                    }
                    else if (command == "down")
                    {
                        moveDown(ghost, mazeGrid.getDownCell(ghost));
                    }
                    smartFlag = false;
                }
            }
            else
            {
                moveRandom('S');
                smartFlag = true;
            }
        }
        public string decideSmartDirection(Cell currentGhostCell,Cell pacmanLocation)
        {
            Cell up = mazeGrid.getUpCell(currentGhostCell);
            Cell down = mazeGrid.getDownCell(currentGhostCell);
            Cell left = mazeGrid.getLeftCell(currentGhostCell);
            Cell right = mazeGrid.getRightCell(currentGhostCell);
            double distanceRight = 11111;
            double distanceLeft = 11111;
            double distanceUp = 11111;
            double distanceDown = 11111;
            if (right.getValue() != '#' && right.getValue() != '%')
            {
                distanceRight = calculateDistance(right, mazeGrid.findPacman());
            }
            if (up.getValue() != '#' && up.getValue() != '%')
            {
                distanceUp = calculateDistance(up, mazeGrid.findPacman());
            }
            if (down.getValue() != '#' && down.getValue() != '%')
            {
                distanceDown = calculateDistance(down, mazeGrid.findPacman());
            }
            if (left.getValue() != '#' && left.getValue() != '%')
            {
                 distanceLeft = calculateDistance(left, mazeGrid.findPacman());
            }
            double dis = Math.Min(distanceUp, Math.Min(distanceDown, Math.Min(distanceRight, distanceLeft)));
            if(dis == distanceDown)
            {
                return "down";
            }
            else if(dis == distanceUp)
            {
                return "up";
            }
            else if(dis == distanceRight)
            {
                return "right";
            }
            else if(dis == distanceLeft)
            {
                return "left";
            }
            return null;
        }
        public double calculateDistance(Cell currentGhostCell,Cell pacmanLocation)
        {
            double distance = Math.Sqrt(Math.Pow((currentGhostCell.getY() - pacmanLocation.getY()), 2) + Math.Pow((currentGhostCell.getX() - pacmanLocation.getX()), 2));
            return distance;
        }
    }
}
