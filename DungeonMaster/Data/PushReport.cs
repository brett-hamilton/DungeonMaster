namespace DungeonMaster.Data
{
    /// <summary>
    /// This class is a go-between for pushing objects, as before we only were able to have a single bool return, which didn't tell the person why the push failed or passed.
    /// Now this means, if they push a wall that isn't pushable, somehow, it won't let them and it will tell them the wall isn't pushable!
    /// </summary>
    public class PushReport
    {
        /// <summary>
        /// Drawable that is pushing another.
        /// </summary>
        public Drawable Pusher { get; set; }

        /// <summary>
        /// Item that is being pushed.
        /// </summary>
        public Drawable PushedItem { get; set; }

        /// <summary>
        /// New coordinate of the item after being pushed.
        /// </summary>
        public Coordinate NewCoordinate { get; set; } = new Coordinate();

        /// <summary>
        /// Bool representing pushing the item is possible.
        /// </summary>
        public bool PushPossible { get; set; } = false;

        /// <summary>
        /// Error string to output to the user if the push was unsuccessful.
        /// </summary>
        public string ErrorString { get; set; } = string.Empty;

        /// <summary>
        /// Constructor to create a new Push Report.
        /// </summary>
        /// <param name="pusher">The drawable who is pushing an item.</param>
        /// <param name="pushedItem">The item that is being pushed.</param>
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
            if (!PushPossible)
            {
                return ErrorString;
            }
            // Return a string containing information about the successful push. Add 1 to both coordinate as most people use index 1.
            else
            {
                return $"{Pusher.Name} pushed {PushedItem.Name} to ({NewCoordinate.Column + 1}, {NewCoordinate.Row + 1})";
            }
        }

    }
}
