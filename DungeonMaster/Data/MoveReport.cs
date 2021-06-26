namespace DungeonMaster.Data
{
    public class MoveReport
    {
        public Drawable ItemToMove { get; set; }

        public Coordinate CurrentCoordinate { get; set; } = new Coordinate();

        public Coordinate NewCoordinate { get; set; } = new Coordinate();

        public bool MoveSuccessful { get; set; } = false;

        public string ErrorString { get; set; } = string.Empty;

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
            else
            {
                return $"{ItemToMove.Name} moved to ({NewCoordinate.Column + 1}, {NewCoordinate.Row + 1})";
            }
        }
    }
}
