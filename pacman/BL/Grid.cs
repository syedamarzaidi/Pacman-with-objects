﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pacman.DL;
using System.IO;
namespace pacman.BL
{
    class Grid
    {
        private int rowSize;
        private int colSize;
        public static Cell[,] maze;

        public Grid(int rowSize, int colSize, string path)
        {
            setRowSize(rowSize);
            setColSize(colSize);
            maze = new Cell[rowSize, colSize];
            LoadMaze(path);
        }
        public void setRowSize(int rowSize)
        {
            this.rowSize = rowSize;
        }
        public void setColSize(int colSize)
        {
            this.colSize = colSize;
        }
        public int getRowSize()
        {
            return rowSize;
        }
        public int getColSize()
        {
            return this.colSize;
        }
        public Cell getLeftCell(Cell c)
        {
            int x = c.getX();
            int y = c.getY();
            char value = c.getValue();
            Cell leftCell = new Cell(x, y + 1, value);
            return leftCell;
        }
        public Cell getRightCell(Cell c)
        {
            int x = c.getX();
            int y = c.getY();
            char value = c.getValue();
            Cell RightCell = new Cell(x, y + 1, value);
            return RightCell;
        }
        public Cell getUpCell(Cell c)
        {
            int x = c.getX();
            int y = c.getY();
            char value = c.getValue();
            Cell UpCell = new Cell(x, y + 1, value);
            return UpCell;
        }
        public Cell getDownCell(Cell c)
        {
            int x = c.getX();
            int y = c.getY();
            char value = c.getValue();
            Cell downCell = new Cell(x, y + 1, value);
            return downCell;
        }
        public static void setArraySize(int rowSize, int colSize)
        {
        }
        public Cell findPacman()
        {
            foreach (var s in Grid.maze)
            {
                if (s.isPacmanPresent())
                {
                    return s;
                }
            }
            return null;
        }
        public Cell findGhostPosition(char ghostCharacter)
        {
            foreach (var s in Grid.maze)
            {
                if (s.isGhostPresent(ghostCharacter))
                {
                    return s;
                }
            }
            return null;
        }
        public static void LoadMaze(string path)
        {
            string line = "";
            StreamReader file = new StreamReader(path);
            if (File.Exists(path))
            {
                int x = -1;
                while ((line = file.ReadLine()) != null)
                {
                    x++;
                    for (int y = 0; y < line.Length; y++)
                    {
                        Cell cell = new Cell(x, y, line[y]);
                        Grid.maze[x, y] = cell;
                    }
                }
                file.Close();
            }
        }
        public static void draw()
        {
            for (int x = 0; x < Grid.maze.GetLength(0); x++)
            {
                for (int y = 0; y < Grid.maze.GetLength(1); y++)
                {
                    Console.Write(Grid.maze[x, y].getValue());
                }
                Console.Write('\n');
            }
        }
    }
}