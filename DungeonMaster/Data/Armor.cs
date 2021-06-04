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

namespace PageHunter_SE1_Project.Data
{
    
    public class Armor
    {
        /// <summary>
        /// name of the armor
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// number of points to represent the protection
        /// </summary>
        public double ProtectionPoints { get; set; }

        /// <summary>
        /// Constructor to initialize the object
        /// </summary>
        /// <param name="name"></param>
        /// <param name="protectionPoints"></param>
        public Armor(string name, double protectionPoints)
        {
            this.Name = name;
            this.ProtectionPoints = protectionPoints;
        }
    }
}
