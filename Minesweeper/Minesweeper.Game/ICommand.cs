﻿//-----------------------------------------------------------------------
// <copyright file="ICommand.cs" company="Telerik Academy">
//     Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
// <summary>The interface for commands in the game.</summary>
//-----------------------------------------------------------------------

namespace Minesweeper.Game
{
    /// <summary>
    /// The 'Command' interface.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Invokes the action on the needed object.
        /// </summary>
        /// <returns>Returns true if more commands can be executed.</returns>
        bool Execute();
    }
}