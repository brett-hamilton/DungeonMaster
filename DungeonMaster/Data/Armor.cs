/*************************************************
 * Name: Armor.cs
 * Author: Hunter Page
 * Date Created: 6/2/21
 * Last Modified: 6/2/21
 *************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMaster.Data
{
    
    public class Armor
    {
        /// <summary>
        /// Name of the armor
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Number of points to represent the protection
        /// </summary>
        public double ProtectionPoints { get; set; }

        /// <summary>
        /// Constructor to initialize the object
        /// </summary>
        /// <param name="name">Name of the armor to set up.</param>
        /// <param name="protectionPoints">Represents the level of protection for armor.</param>
        public Armor(string name, double protectionPoints)
        {
            this.Name = name;
            this.ProtectionPoints = protectionPoints;
        }
    }
}
