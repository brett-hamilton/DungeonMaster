using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DungeonMaster.Data;

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

            var outputString = game.PushObject(character, pushableItem);
            var expectedString = "chair was too far from Geralt to push.";

            Assert.True(outputString.Equals(expectedString));
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
            Drawable nonPushable = new Drawable("unpushableWall", true, null, null);
            game.AddDrawable(nonPushable, 5, 2);

            var outputString = game.PushObject(character, nonPushable);
            var expectedString = "unpushableWall was too far from Geralt to push.";

            Assert.True(outputString.Equals(expectedString));
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

            var outputString = game.PushObject(character, pushableItem);
            var expectedString = "Character moved to 6, 4";

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

            Coordinate newCoordinates = game.Gameboard.GetCoordinateAfterPush(character, pushableItem);

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

            Coordinate newCoordinates = game.Gameboard.GetCoordinateAfterPush(character, pushableItem);

            Assert.True(newCoordinates.Row == 7);
            Assert.True(newCoordinates.Column == 7);
        }
    }
}
