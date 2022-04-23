using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pacman.DL;
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
                //this if condition will change ghost direction variable if 
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
            // Change
            currentGhostCell.setValue(' ');
            mazeGrid.maze[X, Y] = currentGhostCell;
            Console.SetCursorPosition(Y, X);
            Console.Write(' ');
        }
        public void showPreviousItem()
        {
          //  currentGhostCell.setValue(previousItem);
          //  mazeGrid.maze[X, Y] = currentGhostCell;
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
                    moveRandom();
                }
                setDeltaToZero();
            }
        }
        public void moveHorizontal()
        {
            setGhostPosition(); //Reversing the direction of ghost if ghost is blocked
            if(ghostMovingPosition == "left")
            {
                moveLeft();
            }
            else if(ghostMovingPosition == "right")
            {
                moveRight();
            }
        }
        public void moveVertical()
        {
            setGhostPosition(); //reversing the direction of ghost if ghost is blocked
            if (ghostMovingPosition == "up")
            {
                moveUp();
            }
            else if (ghostMovingPosition == "down")
            {
                moveDown();
            }
        }
        public void moveRandom()
        {
            int direction = getRandomNumber();
            if(direction == 1)
            {
                moveRight();
            }
            else if(direction == 2)
            {
                moveLeft();
            }
            else if(direction == 3)
            {
                moveDown();
            }
            else if(direction == 4)
            {
                moveUp();
            }
        }
        public int getRandomNumber()
        {
            int num = rd.Next(1, 5);
            return num;
        }
        public void moveLeft()
        {
            mazeGrid.maze[X, Y].setValue(previousItem);
            showPreviousItem();
            setY(Y - 1);
            setPreviousItem();
            draw();     
        }
        public void moveRight()
        {
            mazeGrid.maze[X, Y].setValue(previousItem);
            showPreviousItem();
            setY(Y + 1);
            setPreviousItem();
            draw();
        }
        public void moveUp()
        {
            mazeGrid.maze[X, Y].setValue(previousItem);
            showPreviousItem();
            setX(X - 1);
            setPreviousItem();
            draw();
        }
        public void moveDown()
        {
            mazeGrid.maze[X, Y].setValue(previousItem);
            showPreviousItem();
            setX(X + 1);
            setPreviousItem();
            draw();
        }
        public int generateRandom()
        {
            return 0;
        }
        public void moveSmart()
        {

        }
        public double calculateDistance(Cell currentGhostCell,Cell pacmanLocation)
        {
            return 0;
        }
        
        /*
        public void setGhostDirection(string ghostDirection)
        {
            this.ghostDirection = ghostDirection;
        }
        
        public void setSpeed(float speed)
        {
            this.speed = speed;
        }
        public void setPreviousItem(char previousItem)
        {
            this.previousItem = previousItem;
        } 
        */
        //Grid mazeGrid;
    }
}
