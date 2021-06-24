using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMaster.Data
{
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

        public string getPushResult()
        {
            if(!PushPossible)
            {
                return ErrorString;
            }
            else
            {
                return $"{Pusher.Name} pushed {PushedItem.Name} to ({NewCoordinate.Column}, {NewCoordinate.Row})";
            }
        }

    }
}
