// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace DungeonMaster.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
#nullable restore
#line 1 "C:\Users\hunte\source\repos\su21-4250-skynet-dungeonmaster\DungeonMasterV2\DungeonMaster\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hunte\source\repos\su21-4250-skynet-dungeonmaster\DungeonMasterV2\DungeonMaster\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\hunte\source\repos\su21-4250-skynet-dungeonmaster\DungeonMasterV2\DungeonMaster\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\hunte\source\repos\su21-4250-skynet-dungeonmaster\DungeonMasterV2\DungeonMaster\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\hunte\source\repos\su21-4250-skynet-dungeonmaster\DungeonMasterV2\DungeonMaster\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\hunte\source\repos\su21-4250-skynet-dungeonmaster\DungeonMasterV2\DungeonMaster\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\hunte\source\repos\su21-4250-skynet-dungeonmaster\DungeonMasterV2\DungeonMaster\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\hunte\source\repos\su21-4250-skynet-dungeonmaster\DungeonMasterV2\DungeonMaster\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\hunte\source\repos\su21-4250-skynet-dungeonmaster\DungeonMasterV2\DungeonMaster\_Imports.razor"
using DungeonMaster;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\hunte\source\repos\su21-4250-skynet-dungeonmaster\DungeonMasterV2\DungeonMaster\_Imports.razor"
using DungeonMaster.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\hunte\source\repos\su21-4250-skynet-dungeonmaster\DungeonMasterV2\DungeonMaster\_Imports.razor"
using DungeonMaster.Pages.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\hunte\source\repos\su21-4250-skynet-dungeonmaster\DungeonMasterV2\DungeonMaster\_Imports.razor"
using DungeonMaster.Pages.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\hunte\source\repos\su21-4250-skynet-dungeonmaster\DungeonMasterV2\DungeonMaster\Pages\DiceTest.razor"
using DungeonMaster.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\hunte\source\repos\su21-4250-skynet-dungeonmaster\DungeonMasterV2\DungeonMaster\Pages\DiceTest.razor"
using Microsoft.AspNetCore.Components;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/DiceTest")]
    public partial class DiceTest : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 86 "C:\Users\hunte\source\repos\su21-4250-skynet-dungeonmaster\DungeonMasterV2\DungeonMaster\Pages\DiceTest.razor"
       
    /// <summary>
    /// Total from dice roll, displayed to user.
    /// </summary>
    private int? diceTotal = null;

    /// <summary>
    /// dieSides and dieToRoll chosen from dropdoby box by user.
    /// </summary>
    protected int dieSides = 4;
    protected int dieToRoll = 1;

    /// <summary>
    /// Modifier chosen from drop down box, to adjust D20 roll.
    /// </summary>
    private string modifier = "";

    /// <summary>
    /// List of previous actions taken.
    /// </summary>
    public List<string> GameLog { get; set; } = new List<string>();

    /// <summary>
    /// Method to roll a single D20 die without modifiers.
    /// </summary>
    private void Roll()
    {
        diceTotal = Die.RollD20();
        GameLog.Add($"Player rolled 1 D20 for {diceTotal}");
    }

    /// <summary>
    /// Method to roll multiple multi-sided dice. The player chooses the number of dice and
    /// sides of dice via a dropdown menu.
    /// </summary>
    private void RollMultipleDice()
    {
        try
        {
            var rollReport = Die.Roll(dieSides, dieToRoll);
            diceTotal = rollReport.GetDiceTotal();
            GameLog.Add($"Player rolled {rollReport.GetDiceReport()}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            diceTotal = null;
        }
    }

    /// <summary>
    /// Method to roll a 20 sided die with advantage, disadvantage, or with no modifier.
    /// Method will update the dice total value.
    /// </summary>
    private void RollModifier()
    {
        if (modifier == "a")
        {
            diceTotal = Die.RollD20Advantage();
            GameLog.Add($"Player rolled 1 D20 for {diceTotal}");
        }

        else if (modifier == "d")
        {
            diceTotal = Die.RollD20Disadvantage();
            GameLog.Add($"Player rolled 1 D20 for {diceTotal}");
        }

        else
        {
            diceTotal = Die.RollD20();
            GameLog.Add($"Player rolled 1 D20 for {diceTotal}");
        }
    }

    private void ClearLog()
    {
        GameLog = new List<string>();
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
