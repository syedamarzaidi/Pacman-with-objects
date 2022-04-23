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
        private char previousItem;
        private float deltaChange;
        private Cell currentGhostCell;
        private Grid mazeGrid;
        private string ghostMovingPosition; //This will help in deciding to move in case of vertical or horizontal
        public void setX(int X)
        {
            if (X != 0 && (X != mazeGrid.getRowSize()-1))
            {
                this.X = X;
            }
        }
        public void setY(int Y)
        {
            if((Y != mazeGrid.getColSize()-1) && Y !=0)
            {
                this.Y = Y;
            }
        }
        public void setXY(int X,int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public void setPreviousItem(string direction)
        {
            if(direction == "up")
            {
                if ((mazeGrid.maze[X - 1, Y].getValue()) != '#')
                {
                    previousItem = mazeGrid.maze[X - 1, Y].getValue();
                }
            }
            else if(direction == "down")
            {
                if ((mazeGrid.maze[X + 1, Y].getValue()) != '#')
                {
                    previousItem = mazeGrid.maze[X + 1, Y].getValue();
                }
            }
            else if(direction == "left")
            {
                if ((mazeGrid.maze[X, Y - 1].getValue()) != '#')
                {
                    previousItem = mazeGrid.maze[X, Y - 1].getValue();
                }
            }
            else if(direction == "right")
            {
                if ((mazeGrid.maze[X, Y + 1].getValue()) != '#')
                {
                    previousItem = mazeGrid.maze[X, Y + 1].getValue();
                }
                }
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
        public void showPreviousItem(string direction)
        {
            if(direction == "right")
            {
                Console.SetCursorPosition(Y - 1, X);
            }
            else if(direction == "left")
            {
                Console.SetCursorPosition(Y + 1, X);
            }
            else if(direction == "up")
            {
                Console.SetCursorPosition(X + 1, Y);
            }
            else if(direction == "down")
            {
                Console.SetCursorPosition(X - 1, Y);
            }
            Console.Write(previousItem);
        }
        public void draw()
        {
            Cell c = new Cell(X, Y, ghostCharacter);
            mazeGrid.maze[X, Y] = c;
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
        public void moveLeft()
        {
            remove();
            setPreviousItem("left");
            setY(Y - 1);
            draw();
            showPreviousItem("left");
        }
        public void moveRight()
        {
           remove();
            setPreviousItem("right");
           setY(Y + 1); 
           draw();
            showPreviousItem("right");
        }
        public void moveUp()
        {
            remove();
            setPreviousItem("up");
            setX(X - 1);
            draw();
            showPreviousItem("up");
        }
        public void moveDown()
        {
            remove();
            setPreviousItem("down");
            setX(X + 1);
            draw();
            showPreviousItem("down");
        }
        public void moveVertical()
        {
            setGhostPosition(); //reversing the direction of ghost if ghost is blocked
            if(ghostMovingPosition == "up")
            {
                moveUp();
            }
            else if(ghostMovingPosition == "down")
            {
                moveDown();
            }
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
