using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace DungeonMaster.Data
{
    /// <summary>
    /// Class of methods to manage the IO of character saves.
    /// 
    /// Created by: Brett Hamilton
    /// Created on: 6/21/2021
    /// </summary>
    public static class CharacterFile
    {
        /// <summary>
        /// The path to the character file.
        /// </summary>
        private const string PATH = "Saves/characters.json";

        /// <summary>
        /// Getter for the path to the characters file.
        /// </summary>
        /// <returns>The path to the characters file.</returns>
        public static string GetPath()
        {
            return PATH;
        }

        /// <summary>
        /// Writes a character to the characters file in JSON format.
        /// </summary>
        /// <param name="character">The character to save.</param>
        /// <param name="overwrite">True if file should be overwritten, false if appending.</param>
        public static void Write(Character character, bool overwrite)
        {
            bool overwriting = overwrite;               // True if we are overwriting file, false if appending
            string jsonString = JsonSerializer.Serialize(character);

            if (overwriting)
            {
                File.WriteAllText(PATH, jsonString);
            }
            else
            {
                string appendText = jsonString + Environment.NewLine;
                File.AppendAllText(PATH, appendText);
            }
        }

        /// <summary>
        /// Reads the characters JSON file and returns the list of Characters.
        /// </summary>
        /// <returns>The list of Characters in the characters file.</returns>
        public static List<Character> Read()
        {
            Character newCharacter;                             // Catches character from deserialized JSON
            List<Character> characters = new List<Character>(); // List of characters to return from the file
            string[] jsonContents = File.ReadAllLines(PATH);

            foreach (string jsonString in jsonContents)
            {
                newCharacter = JsonSerializer.Deserialize<Character>(jsonString);
                characters.Add(newCharacter);
            }

            return characters;
        }

        /// <summary>
        /// Empties the characters file.
        /// </summary>
        public static void Clear()
        {
            File.WriteAllText(PATH, string.Empty);
        }
    }
}
