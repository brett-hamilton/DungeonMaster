/*************************************************
 * Name: Status.cs
 * Author: Hunter Page
 * Date Created: 6/9/21
 * Last Modified: 6/9/21
 *************************************************/


namespace DungeonMaster.Data
{
    /// <summary>
    /// Enum Status represents the current status of the character.
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// Is Alive
        /// </summary>
        Alive,
        /// <summary>
        /// Is Dead
        /// </summary>
        Dead,
        /// <summary>
        /// Is Poisoned
        /// </summary>
        Poisoned,
        /// <summary>
        /// Is Bleeding
        /// </summary>
        Bleeding,
        /// <summary>
        /// Is Disoriented
        /// </summary>
        Disoriented,
        /// <summary>
        /// Is Incapacitated
        /// </summary>
        Incapacitated
    }
}