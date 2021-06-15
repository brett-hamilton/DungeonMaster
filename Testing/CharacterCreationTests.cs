using Bunit;
using Bunit.TestDoubles;
using System;
using Xunit;
using DungeonMaster.Pages;

namespace Testing
{
	/// <summary>
	/// Testing class for the process of creating a character.
	/// </summary>
	public class CharacterCreationTests : TestContext
	{
		/// <summary>
		/// Unit test that the character name starts as an empty string.
		/// 
		/// Created by: Brett Hamilton
		/// Created on: 6/9/2021
		/// </summary>
		[Fact]
		public void CharacterNameStartsEmpty ( )
		{
			// Arrange test
			var cut = RenderComponent<CharacterCreationTest> ( );

			// Assert character name is empty
			cut.Find ("p").MarkupMatches ("<p>Current Name: ");
		}

	}
}
