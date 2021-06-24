using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public string getMoveResult()
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
