using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pacman.BL
{
    class Cell
    {
        public Cell(int x, int y, char value)
        {
            setXY(x, y);
            setValue(value);
        }
        private int x;
        private int y;
        private char value;
        public void setX(int x)
        {
            this.x = x;
        }
        public void setY(int y)
        {
            this.y = y;
        }
        public void setXY(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void setValue(char value)
        {
            this.value = value;
        }
        public int getX()
        {
            return this.x;
        }
        public int getY()
        {
            return this.y;
        }
        public char getValue()
        {
            return this.value;
        }
        public bool isPacmanPresent()
        {
            if (value == 'P')
            {
                return true;
            }
            return false;
        }
        public bool isGhostPresent(char ghostChracter)
        {
            if (value == ghostChracter)
            {
                return true;
            }
            return false;
        }
    }
}
