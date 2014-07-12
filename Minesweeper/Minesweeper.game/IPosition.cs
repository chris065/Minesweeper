namespace Minesweeper
{
    using System;

    public interface IPosition
    {
        /// <summary>
        /// Gets or sets value for position by row.
        /// </summary>
        /// <value>Position by row.</value>
        int Row { get; set; }

        /// <summary>
        /// Gets or sets value for position by column.
        /// </summary>
        /// <value>Position by column.</value>
        int Col { get; set; }
    }
}