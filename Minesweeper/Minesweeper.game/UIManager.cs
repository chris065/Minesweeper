﻿namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Minesweeper.Lib;

    public class UIManager
    {
        private int cmdLineRow;
        private int cmdLineCol;
        private readonly IRenderer renderer;
        private readonly IUserInputReader inputReader;

        private BoardDrawer boardDrawer;

        public UIManager(int minefieldRows, int minefieldCols, int cmdLineCol)
        {
            this.renderer = new ConsoleRenderer();
            this.inputReader = new ConsoleReader();

            this.cmdLineRow = 8 + minefieldRows;
            this.cmdLineCol = cmdLineCol;
            CellPos minefieldTopLeft = new CellPos(6, 4);
            this.boardDrawer = new BoardDrawer(minefieldRows, minefieldCols, minefieldTopLeft);            
        }

        public void DisplayIntro(string msg)
        {
            this.renderer.WriteAt(0, 0, msg);
        }

        public void DisplayEnd(string msg, int numberOfOpenedCells)
        {
            this.renderer.WriteAt(0, this.cmdLineRow + 1, msg, numberOfOpenedCells);
        }      

        public void GoodBye(string goodByeMsg)
        {
            this.renderer.WriteLine();
            this.renderer.WriteLine(goodByeMsg);
        }

        public void DisplayHighScores(IEnumerable<KeyValuePair<string, int>> topScores)
        {
            this.renderer.WriteAt(0, this.cmdLineRow + 4, "Scoreboard:");
            this.renderer.WriteLine();

            var place = 0;
            foreach (var result in topScores)
            {
                this.renderer.WriteLine("{0}. {1} --> {2} cells", place, result.Key, result.Value);
                place++;
            }
        }

        public void DisplayError(string errorMsg)
        {
            this.renderer.WriteAt(this.cmdLineCol, this.cmdLineRow, errorMsg);
            this.WaitForKey(" Press any key to continue...");
        }

        public void WaitForKey(string promptMsg)
        {
            this.renderer.Write(promptMsg);
            this.inputReader.WaitForKey();
            this.ClearCommandLine();
        }

        public string ReadInput()
        {
            // set the cursor at the command line
            this.renderer.WriteAt(this.cmdLineCol, this.cmdLineRow, "");
            string input = this.inputReader.ReadLine();
            this.ClearCommandLine();
            return input;
        }

        public string ReadName()
        {
            string name = this.inputReader.ReadLine();
            this.ClearCommandLine();
            return name;
        }

        public void DrawInitialGameField(string enterRowColPrompt)
        {
            int left = 0;
            int top = 3;
            this.boardDrawer.DrawInitialGameField(left, top);
            this.renderer.Write(enterRowColPrompt);
        }

        public void DrawOpenCell(int rowOnField, int colOnField, int neighborMinesCount)
        {
            this.boardDrawer.DrawOpenCell(rowOnField, colOnField, neighborMinesCount);
        }

        public void DrawFinalGameField(bool[,] minefield, bool[,] openedCells)
        {
            this.boardDrawer.DrawFinalGameField(minefield, openedCells);
        }

        private void ClearCommandLine()
        {
            this.renderer.ClearLines(this.cmdLineCol, this.cmdLineRow, 3);
        }
    }
}
