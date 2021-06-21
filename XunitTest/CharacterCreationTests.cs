using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DungeonMaster.Data;
using System.Text.Json;
using System.IO;

namespace XunitTest
{
	/// <summary>
	/// Unit testing class to test the functionality of creating and saving game characters.
	/// 
	/// Created by: Brett Hamilton
	/// Created on: 6/21/2021
	/// </summary>
	public class CharacterCreationTests
	{
		/// <summary>
		/// Path to the characters JSON file.
		/// </summary>
		private const string PATH = "Saves/characters.json";

		private Character char1 = new Character ("Hank Hill", 50, 1);

		/// <summary>
		/// Tests that the correct path is set up for the characters file.
		/// </summary>
		[Fact]
		public void PathNameTest()
		{
			Assert.Equal (PATH, CharacterFile.GetPath());
		}

		/// <summary>
		/// Tests that the writing method writes the correct text to the character file.
		/// </summary>
		[Fact]
		public void WritingTest()
		{
			CharacterFile.Write(char1, true);
			string writeJson = JsonSerializer.Serialize(char1);
			string readJson = File.ReadAllLines(PATH).Skip(0).Take(1).First();
			Assert.Equal(writeJson, readJson);
		}

		/// <summary>
		/// Tests the reading method to check if we are reading the correct characters from the file.
		/// </summary>
		[Fact]
		public void ReadingTest()
		{
			string writeJson = JsonSerializer.Serialize(char1);
			File.WriteAllText(PATH, writeJson);
			List<Character> characters = CharacterFile.Read();
			Assert.True(characters.Count == 1);
			Assert.Equal(char1.Name, characters[0].Name);
		}
	}
}
