using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMaster.Data
{
    /// <summary>
    /// This class is a go-between for pushing objects, as before we only were able to have a single bool return, which didn't tell the person why the push failed or passed.
    /// Now this means, if they push a wall that isn't pushable, somehow, it won't let them and it will tell them the wall isn't pushable!
    /// </summary>
    public class PushReport
    {
        public Drawable Pusher { get; set; }

        public Drawable PushedItem { get; set; }

        public Coordinate NewCoordinate { get; set; } = new Coordinate();

        public bool PushPossible { get; set; } = false;

        public string ErrorString { get; set; } = string.Empty;

        public PushReport(Drawable pusher, Drawable pushedItem)
        {
            Pusher = pusher;
            PushedItem = pushedItem;
        }

        /// <summary>
        /// After filling in a push report, returns a string representing the result or error.
        /// </summary>
        /// <returns>String representing the error or result of the move.</returns>
        public string GetPushResult()
        {
            if(!PushPossible)
            {
                return ErrorString;
            }
            else
            {
                return $"{Pusher.Name} pushed {PushedItem.Name} to ({NewCoordinate.Column + 1}, {NewCoordinate.Row + 1})";
            }
        }

    }
}
