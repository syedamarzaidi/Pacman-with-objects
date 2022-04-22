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
        }
        private int X;
        private int Y;
        private string ghostDirection;
        private char ghostCharacter;
        private float speed;
        private char previousItem;
        private float deltaChange;
        private Cell currentGhostCell;
        public void setGhostDirection(string ghostDirection)
        {
            this.ghostDirection = ghostDirection;
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
            Grid.maze[X, Y] = currentGhostCell;
            Console.SetCursorPosition(getGhostY(), getGhostY());
            Console.Write(' ');
        }
        public void draw()
        {
            Console.SetCursorPosition(getGhostY(), getGhostX());
        }
        public void moveHorizontal()
        {

        }
        public void moveVertical()
        {

        }
        public int generateRandom()
        {

        }
        public void moveSmart()
        {

        }
        public double calculateDistance(Cell currentGhostCell,Cell pacmanLocation)
        {

        }



        /*public void setX(int X)
        {
            this.X = X;
        }
        public void setY(int Y)
        {
            this.Y = Y;
        }
        public void setGhostDirection(string ghostDirection)
        {
            this.ghostDirection = ghostDirection;
        }
        public void setGhostCharacter(char ghostCharacter)
        {
            this.ghostCharacter = ghostCharacter;
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
