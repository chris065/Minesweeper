﻿//-----------------------------------------------------------------------
// <copyright file="Engine.cs" company="Telerik Academy">
//     Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
// <summary>The engine of the game that runs the game loop.</summary>
//-----------------------------------------------------------------------

namespace Minesweeper.Game
{
    using Minesweeper.Lib;

    /// <summary>
    /// A class that runs the main game loop.
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// Runs the main game loop - accepts user input, parses the input and executes the command.
        /// </summary>
        public void Run()
        {
            // IUIManager bridged with IRenderer and IUserInputReader
            IUIManager consoleUIManager = new UIManager(new ConsoleRenderer(), new ConsoleReader());

            MinesweeperGame game = new MinesweeperGameEasy(consoleUIManager);
            CommandParser commandParser = new CommandParser(game);
            CommandExecutor cmdExecutor = new CommandExecutor();
          
            // Start game loop
            bool gameRunning = true;
            while (gameRunning)
            {
                string input = consoleUIManager.ReadInput();

                ICommand command = commandParser.ParseCommand(input);

                gameRunning = cmdExecutor.ExecuteCommand(command);
            }
        }
    }
}