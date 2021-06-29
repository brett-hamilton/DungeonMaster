namespace DungeonMaster.Data
{
    /// <summary>
    /// Report containing the information about an attempt to move.
    /// </summary>
    public class MoveReport
    {
        /// <summary>
        /// Item that is moving in the game.
        /// </summary>
        public Drawable ItemToMove { get; set; }

        /// <summary>
        /// Starting location of the item.
        /// </summary>
        public Coordinate CurrentCoordinate { get; set; } = new Coordinate();

        /// <summary>
        /// Ending location of the item.
        /// </summary>
        public Coordinate NewCoordinate { get; set; } = new Coordinate();

        /// <summary>
        /// If the move was successful.
        /// </summary>
        public bool MoveSuccessful { get; set; } = false;

        /// <summary>
        /// Error string to return to display to the user.
        /// </summary>
        public string ErrorString { get; set; } = string.Empty;

        /// <summary>
        /// Constructor to build a new move report. class.
        /// </summary>
        /// <param name="itemToMove">The item attempting to move.</param>
        /// <param name="currentCoordinate">The current coordinate of the item in the gameboard.</param>
        public MoveReport(Drawable itemToMove, Coordinate currentCoordinate)
        {
            ItemToMove = itemToMove;
            CurrentCoordinate = currentCoordinate;
        }

        /// <summary>
        /// After filling in the needed properties, returns a string representing the result of the move attempt.
        /// </summary>
        /// <returns>A string representing the result of the move attempt.</returns>
        public string GetMoveResult()
        {
            if (!MoveSuccessful)
            {
                return ErrorString;
            }
            // If the move was successful, output the new coordinates, but add 1 to each as most people use index 1.
            else
            {
                return $"{ItemToMove.Name} moved to ({NewCoordinate.Column + 1}, {NewCoordinate.Row + 1})";
            }
        }
    }
}
