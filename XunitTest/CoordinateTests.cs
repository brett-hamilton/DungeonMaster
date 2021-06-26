using DungeonMaster.Data;
using Xunit;

namespace XunitTest
{
    public class CoordinateTests
    {
        /// <summary>
        /// Gets the new y coordinate test.
        /// </summary>
        [Fact]
        public void GetNewYCoordinateTest()
        {
            var currentPosition = new Coordinate() { Column = 3, Row = 2 };
            var direction = CardinalDirection.N;
            var gameboard = new Gameboard();

            var newPosition = gameboard.GetNewCoordinate(currentPosition, direction);


            Assert.True(newPosition.Row == 1);
            Assert.True(newPosition.Column == 3);
        }
        /// <summary>
        /// Gets the new x coordinate test.
        /// </summary>
        [Fact]
        public void GetNewXCoordinateTest()
        {
            var currentPosition = new Coordinate() { Column = 3, Row = 2 };
            var direction = CardinalDirection.E;
            var gameboard = new Gameboard();

            var newPosition = gameboard.GetNewCoordinate(currentPosition, direction);


            Assert.True(newPosition.Row == 2);
            Assert.True(newPosition.Column == 4);
        }
        //love you jacob ;)
        /// <summary>
        /// Gets the new xy coordinate test.
        /// </summary>
        [Fact]
        public void GetNewXYCoordinateTest()
        {
            var currentPosition = new Coordinate() { Column = 3, Row = 2 };
            var direction = CardinalDirection.NE;
            var gameboard = new Gameboard();

            var newPosition = gameboard.GetNewCoordinate(currentPosition, direction);

            Assert.True(newPosition.Column == 4);
            Assert.True(newPosition.Row == 1);
        }
    }
}
