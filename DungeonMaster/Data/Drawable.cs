/*************************************************
 * Name: Drawable.cs
 * Author: Dustin Ollis
 * Date Created: 6/14/21
 * Last Modified: 6/14/21
 *************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMaster.Data
{
    /// <summary>
    /// Represents a class that can be drawn to a screen.
    /// </summary>
    public class Drawable
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is collidable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is collidable; otherwise, <c>false</c>.
        /// </value>
        public bool IsCollidable { get; set; }

        /// <summary>
        /// Gets or sets the image location.
        /// </summary>
        /// <value>The image location.</value>
        public string ImageLocation { get; set; }

        /// <summary>
        /// Gets or sets the backup color code. In hex format without he leading #, 6 digit.
        /// </summary>
        /// <value>The backup color code.</value>
        public string BackupColorCode { get; set; }

        /// <summary>
        /// Gets or sets the direction the character will be facing when drawn.
        /// </summary>
        /// <value>
        /// The direction (Only 8 options, the 4 cardinals and the intermediates.)
        /// </value>
        public CardinalDirection Direction { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Drawable"/> class.
        /// </summary>
        public Drawable()
        {
            Name = "Empty Drawable";
            IsCollidable = false;
            ImageLocation = null;
            BackupColorCode = "#FF0000";
            Direction = CardinalDirection.N;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Drawable"/> class.
        /// </summary>
        /// <param name="name">The name of the object.</param>
        /// <param name="isCollidable">If set to <c>true</c> [is collidable].</param>
        /// <param name="ImageLocation">The image location.</param>
        public Drawable(string name, Boolean isCollidable, string ImageLocation, string ColorCode)
        {
            this.Name = name;
            this.IsCollidable = isCollidable;
            this.ImageLocation = ImageLocation;
            this.BackupColorCode = ColorCode;
            this.Direction = CardinalDirection.N;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Drawable"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="isCollidable">if set to <c>true</c> [is collidable].</param>
        /// <param name="ImageLocation">The image location.</param>
        /// <param name="direction">The direction (Only 8 options, the 4 cardinals and the intermediates.)</param>
        public Drawable(string name, Boolean isCollidable, string ImageLocation, string ColorCode, CardinalDirection direction)
        {
            this.Name = name;
            this.IsCollidable = isCollidable;
            this.ImageLocation = ImageLocation;
            this.BackupColorCode = ColorCode;
            this.Direction = direction;
        }
    }
}
