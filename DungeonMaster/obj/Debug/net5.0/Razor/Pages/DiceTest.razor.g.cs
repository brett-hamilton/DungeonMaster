#pragma checksum "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\DiceTest.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fbf8341160624844194bcc769dfc71efa49b53cb"
// <auto-generated/>
#pragma warning disable 1591
namespace DungeonMaster.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
#nullable restore
#line 1 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\_Imports.razor"
using DungeonMaster;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\_Imports.razor"
using DungeonMaster.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\DiceTest.razor"
using DungeonMaster.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\DiceTest.razor"
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
            __builder.AddMarkupContent(0, "<hr>\r\n<br>\r\n\r\n");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "row");
            __builder.AddAttribute(3, "id", "DiceDisplay");
            __builder.AddMarkupContent(4, "<label class=\"col-2\">Dice Total: </label>\r\n    ");
            __builder.OpenElement(5, "input");
            __builder.AddAttribute(6, "class", "col-1");
            __builder.AddAttribute(7, "readonly");
            __builder.AddAttribute(8, "value", 
#nullable restore
#line 11 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\DiceTest.razor"
                                          diceTotal

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n\r\n<hr>\r\n<br>\r\n");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "id", "MultiDiceRoller");
            __builder.AddMarkupContent(12, "<label for=\"dieSides\">Sides on Die: </label>\r\n    ");
            __builder.OpenElement(13, "select");
            __builder.AddAttribute(14, "name", "dieSides");
            __builder.AddAttribute(15, "id", "dieSides");
            __builder.AddAttribute(16, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 18 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\DiceTest.razor"
                   dieSides

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(17, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => dieSides = __value, dieSides));
            __builder.SetUpdatesAttributeName("value");
            __builder.OpenElement(18, "option");
            __builder.AddAttribute(19, "value", "4");
            __builder.AddContent(20, "4");
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n        ");
            __builder.OpenElement(22, "option");
            __builder.AddAttribute(23, "value", "6");
            __builder.AddContent(24, "6");
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n        ");
            __builder.OpenElement(26, "option");
            __builder.AddAttribute(27, "value", "8");
            __builder.AddContent(28, "8");
            __builder.CloseElement();
            __builder.AddMarkupContent(29, "\r\n        ");
            __builder.OpenElement(30, "option");
            __builder.AddAttribute(31, "value", "12");
            __builder.AddContent(32, "12");
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\r\n        ");
            __builder.OpenElement(34, "option");
            __builder.AddAttribute(35, "value", "20");
            __builder.AddContent(36, "20");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\r\n    ");
            __builder.AddMarkupContent(38, "<label for=\"dieToRoll\">Number of Die: </label>\r\n    ");
            __builder.OpenElement(39, "select");
            __builder.AddAttribute(40, "name", "dieToRoll");
            __builder.AddAttribute(41, "id", "dieToRoll");
            __builder.AddAttribute(42, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 26 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\DiceTest.razor"
                   dieToRoll

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(43, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => dieToRoll = __value, dieToRoll));
            __builder.SetUpdatesAttributeName("value");
            __builder.OpenElement(44, "option");
            __builder.AddAttribute(45, "value", "1");
            __builder.AddContent(46, "1");
            __builder.CloseElement();
            __builder.AddMarkupContent(47, "\r\n        ");
            __builder.OpenElement(48, "option");
            __builder.AddAttribute(49, "value", "2");
            __builder.AddContent(50, "2");
            __builder.CloseElement();
            __builder.AddMarkupContent(51, "\r\n        ");
            __builder.OpenElement(52, "option");
            __builder.AddAttribute(53, "value", "3");
            __builder.AddContent(54, "3");
            __builder.CloseElement();
            __builder.AddMarkupContent(55, "\r\n        ");
            __builder.OpenElement(56, "option");
            __builder.AddAttribute(57, "value", "4");
            __builder.AddContent(58, "4");
            __builder.CloseElement();
            __builder.AddMarkupContent(59, "\r\n        ");
            __builder.OpenElement(60, "option");
            __builder.AddAttribute(61, "value", "5");
            __builder.AddContent(62, "5");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(63, "\r\n    ");
            __builder.OpenElement(64, "div");
            __builder.OpenElement(65, "button");
            __builder.AddAttribute(66, "class", "btn btn-primary");
            __builder.AddAttribute(67, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 34 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\DiceTest.razor"
                                                   RollMultipleDice

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(68, "ROLL!");
            __builder.CloseElement();
            __builder.AddMarkupContent(69, "\r\n        ");
            __builder.OpenElement(70, "button");
            __builder.AddAttribute(71, "class", "btn btn-primary");
            __builder.AddAttribute(72, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 35 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\DiceTest.razor"
                                                  Roll

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(73, "QUICK D20 ROLL!");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(74, "\r\n<hr>\r\n<br>\r\n");
            __builder.AddMarkupContent(75, "<h5>Single D20 With Modifier Test:</h5>\r\n");
            __builder.OpenElement(76, "div");
            __builder.AddAttribute(77, "id", "rollDieWithModifier");
            __builder.AddMarkupContent(78, "<label for=\"modifier\">Modifier: </label>\r\n    ");
            __builder.OpenElement(79, "select");
            __builder.AddAttribute(80, "name", "modifier");
            __builder.AddAttribute(81, "id", "modifier");
            __builder.AddAttribute(82, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 43 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\DiceTest.razor"
                   modifier

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(83, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => modifier = __value, modifier));
            __builder.SetUpdatesAttributeName("value");
            __builder.OpenElement(84, "option");
            __builder.AddAttribute(85, "value");
            __builder.AddContent(86, "No Modifier");
            __builder.CloseElement();
            __builder.AddMarkupContent(87, "\r\n        ");
            __builder.OpenElement(88, "option");
            __builder.AddAttribute(89, "value", "a");
            __builder.AddContent(90, "Advantage");
            __builder.CloseElement();
            __builder.AddMarkupContent(91, "\r\n        ");
            __builder.OpenElement(92, "option");
            __builder.AddAttribute(93, "value", "d");
            __builder.AddContent(94, "Disadvantage");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(95, "\r\n");
            __builder.OpenElement(96, "div");
            __builder.OpenElement(97, "button");
            __builder.AddAttribute(98, "class", "btn btn-primary");
            __builder.AddAttribute(99, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 50 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\DiceTest.razor"
                                              RollModifier

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(100, "ROLL D20 WITH MODIFIER!");
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 54 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\DiceTest.razor"
       
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
    /// Method to roll a single D20 die without modifiers.
    /// </summary>
    private void Roll()
    {
        diceTotal = Die.RollD20();
    }

    /// <summary>
    /// Method to roll multiple multi-sided dice. The player chooses the number of dice and
    /// sides of dice via a dropdown menu.
    /// </summary>
    private void RollMultipleDice()
    {
        try
        {
            diceTotal = Die.Roll(dieSides, dieToRoll);
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
        }

        else if (modifier == "d")
        {
            diceTotal = Die.RollD20Disadvantage();
        }

        else
        {
            diceTotal = Die.RollD20();
        }
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
