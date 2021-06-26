using DungeonMaster.Data;
using Xunit;

namespace XunitTest
{
    public class ObjectPushingTest
    {

        /// <summary>
        /// Attempts to push an object that is too far away, so it fails.
        /// </summary>
        [Fact]
        public void PushObjectShouldFailTest()
        {
            Game game = new Game(10, 10);
            Character character = new Character();
            game.AddCharacter(character, 5, 5);
            Drawable pushableItem = new Drawable("chair", true, null, null);
            game.AddDrawable(pushableItem, 5, 2);

            string pushReport = game.PushObject(character, pushableItem);
            string expectedString = "chair is too far away from Geralt.";

            Assert.True(pushReport.Equals(expectedString));
        }

        /// <summary>
        /// Attempts to push an object that is too far away, so it fails.
        /// </summary>
        [Fact]
        public void AttemptToPushUnpushableObjectTest()
        {
            Game game = new Game(10, 10);
            Character character = new Character();
            game.AddCharacter(character, 5, 5);
            Drawable nonPushable = new Drawable("unpushableWall", false, null, null);
            game.AddDrawable(nonPushable, 5, 4);

            PushReport pushReport = game.Gameboard.GetCoordinateAfterPush(character, nonPushable);

            Assert.False(pushReport.PushPossible);
        }


        /// <summary>
        /// Attempts to push the object north. Should pass.
        /// </summary>
        [Fact]
        public void PushObjectNorth()
        {
            Game game = new Game(10, 10);
            Character character = new Character();
            game.AddCharacter(character, 5, 5);
            Drawable pushableItem = new Drawable("chair", true, null, null);
            game.AddDrawable(pushableItem, 5, 4);

            PushReport pushReport = game.Gameboard.GetCoordinateAfterPush(character, pushableItem);
            Coordinate newCoordinates = pushReport.NewCoordinate;
            string outputString = pushReport.GetPushResult();
            string expectedString = "Geralt pushed chair to (6, 4)"; //This string includes the locations having been increased by 1 so the user isn't aware of the off by one of arrays.

            Assert.True(outputString.Equals(expectedString));
        }

        /// <summary>
        /// Pushes the object east. Should pass.
        /// </summary>
        [Fact]
        public void PushEast()
        {
            Game game = new Game(10, 10);
            Character character = new Character();
            game.AddCharacter(character, 5, 5);
            Drawable pushableItem = new Drawable("chair", true, null, null);
            game.AddDrawable(pushableItem, 6, 5);

            PushReport pushReport = game.Gameboard.GetCoordinateAfterPush(character, pushableItem);
            Coordinate newCoordinates = pushReport.NewCoordinate;

            Assert.True(newCoordinates.Row == 5);
            Assert.True(newCoordinates.Column == 7);
        }

        /// <summary>
        /// Pushes the object southeast. Should Pass.
        /// </summary>
        [Fact]
        public void PushSouthEast()
        {
            Game game = new Game(10, 10);
            Character character = new Character();
            game.AddCharacter(character, 5, 5);
            Drawable pushableItem = new Drawable("chair", true, null, null);
            game.AddDrawable(pushableItem, 6, 6);

            PushReport pushReport = game.Gameboard.GetCoordinateAfterPush(character, pushableItem);
            Coordinate newCoordinates = pushReport.NewCoordinate;

            Assert.True(newCoordinates.Row == 7);
            Assert.True(newCoordinates.Column == 7);
        }

        /// <summary>
        /// Test to see if there are nearby pushable objects. There should be one.
        /// </summary>
        [Fact]
        public void NearbyPushableObjectTest()
        {
            var game = new Game(10, 10);
            Character character = new Character();
            game.AddCharacter(character, 5, 5);
            Drawable pushableItem = new Drawable("chair", true, null, null);
            game.AddDrawable(pushableItem, 6, 6);

            var listOfItems = game.Gameboard.PushableItemsNearby(character);

            Assert.True(listOfItems[0] == pushableItem);
            Assert.True(listOfItems.Count == 1);
        }

        /// <summary>
        /// Test to see if there are nearby pushable objects, there should not be.
        /// </summary>
        [Fact]
        public void NoNearbyPushableObjectTest()
        {
            var game = new Game(10, 10);
            Character character = new Character();
            game.AddCharacter(character, 5, 5);
            Drawable pushableItem = new Drawable("chair", true, null, null);
            game.AddDrawable(pushableItem, 7, 7);

            var listOfItems = game.Gameboard.PushableItemsNearby(character);

            Assert.True(listOfItems.Count == 0);
        }
    }
}
