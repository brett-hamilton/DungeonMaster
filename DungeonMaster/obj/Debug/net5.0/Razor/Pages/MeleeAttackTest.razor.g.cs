#pragma checksum "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\MeleeAttackTest.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2b4de1f412a72bbc5553b1ebc9af9e59f4e7241d"
// <auto-generated/>
#pragma warning disable 1591
namespace DungeonMaster.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
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
#line 3 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\MeleeAttackTest.razor"
using DungeonMaster.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/MeleeAttackTest")]
    public partial class MeleeAttackTest : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Testing Melee Attacks</h3>\r\n<hr>\r\n<br>\r\n\r\n");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "row");
            __builder.OpenElement(3, "button");
            __builder.AddAttribute(4, "class", "btn btn-primary");
            __builder.AddAttribute(5, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 9 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\MeleeAttackTest.razor"
                                              SetupGame

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(6, "Start or Restart Game");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(7, "\r\n<br>\r\n");
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "row");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "col-3");
            __builder.OpenElement(12, "ul");
            __builder.OpenElement(13, "li");
            __builder.AddMarkupContent(14, "\r\n                Character Name: ");
            __builder.AddContent(15, 
#nullable restore
#line 17 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\MeleeAttackTest.razor"
                                 player1.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\r\n            ");
            __builder.OpenElement(17, "li");
            __builder.AddMarkupContent(18, "\r\n                Weapon: ");
            __builder.AddContent(19, 
#nullable restore
#line 20 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\MeleeAttackTest.razor"
                         player1.MeleeWeapon.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n            ");
            __builder.OpenElement(21, "li");
            __builder.AddMarkupContent(22, "\r\n                Health: ");
            __builder.AddContent(23, 
#nullable restore
#line 23 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\MeleeAttackTest.razor"
                         player1.Health

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n    ");
            __builder.OpenElement(25, "div");
            __builder.AddAttribute(26, "class", "col-3");
            __builder.AddContent(27, 
#nullable restore
#line 30 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\MeleeAttackTest.razor"
         attackResult

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(28, "\r\n    ");
            __builder.OpenElement(29, "div");
            __builder.AddAttribute(30, "class", "col-3");
            __builder.OpenElement(31, "ul");
            __builder.OpenElement(32, "li");
            __builder.AddMarkupContent(33, "\r\n                Character Name: ");
            __builder.AddContent(34, 
#nullable restore
#line 36 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\MeleeAttackTest.razor"
                                 player2.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\r\n            ");
            __builder.OpenElement(36, "li");
            __builder.AddMarkupContent(37, "\r\n                Weapon: ");
            __builder.AddContent(38, 
#nullable restore
#line 39 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\MeleeAttackTest.razor"
                         player2.MeleeWeapon.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\r\n            ");
            __builder.OpenElement(40, "li");
            __builder.AddMarkupContent(41, "\r\n                Health: ");
            __builder.AddContent(42, 
#nullable restore
#line 42 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\MeleeAttackTest.razor"
                         player2.Health

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(43, "\r\n");
            __builder.OpenElement(44, "div");
            __builder.AddAttribute(45, "class", "row");
            __builder.OpenElement(46, "button");
            __builder.AddAttribute(47, "class", "btn btn-danger");
            __builder.AddAttribute(48, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 48 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\MeleeAttackTest.razor"
                                             AttackExample

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(49, "Attack the Enemy!");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(50, "\r\n<br>\r\n<br>\r\n");
            __builder.OpenElement(51, "div");
            __builder.OpenElement(52, "div");
            __builder.OpenElement(53, "button");
            __builder.AddAttribute(54, "class", "btn btn-secondary");
            __builder.AddAttribute(55, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 54 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\MeleeAttackTest.razor"
                                                    ClearLog

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(56, "Clear Log");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(57, "\r\n    ");
            __builder.OpenElement(58, "div");
            __builder.OpenElement(59, "ul");
            __builder.AddAttribute(60, "id", "gameLog");
#nullable restore
#line 58 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\MeleeAttackTest.razor"
             foreach (string logMessage in GameLog)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(61, "li");
            __builder.AddContent(62, 
#nullable restore
#line 60 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\MeleeAttackTest.razor"
                     logMessage

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 61 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\MeleeAttackTest.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 66 "C:\Users\JD\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\MeleeAttackTest.razor"
       
    /// <summary>
    /// Two players and game board, to simulate the combat section of our game.
    /// </summary>
    public Character player1 { get; set; } = new Character("Player 1", 50, 1);
    public Character player2 { get; set; } = new Character("Player 2", 50, 1);

    public List<string> GameLog { get; set; } = new List<string>();

    public Game testGame { get; set; } = new Game();

    /// <summary>
    /// String message with the result of the attack.
    /// </summary>
    private string attackResult = "";

    /// <summary>
    /// Method to restart or setup the game.
    /// </summary>
    public void SetupGame()
    {
        player1 = new Character("Player 1", 50, 1);
        player2 = new Character("Player 2", 50, 1);
        testGame = new Game(player1, player2);
        attackResult = "";
        GameLog = new List<string>();


        StateHasChanged();
    }

    /// <summary>
    /// Method to show that our attack method works.
    /// </summary>
    public void AttackExample()
    {
        attackResult = testGame.MeleeAttackAttempt(player1, player2);
        GameLog.Add(attackResult);

    }

    /// <summary>
    /// Method to clear the game log.
    /// </summary>
    public void ClearLog()
    {
        GameLog = new List<string>();
    }


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
