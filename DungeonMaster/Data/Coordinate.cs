namespace DungeonMaster.Data
{
    /// <summary>
    /// Coordinate represents the character's location in the game board using two ints.
    /// </summary>
    public class Coordinate
    {
        /// <summary>
        /// Int representing the player's row location in the gameboard.
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Int representing the player's column location in the gameboard.
        /// </summary>
        public int Column { get; set; }
    }
}
