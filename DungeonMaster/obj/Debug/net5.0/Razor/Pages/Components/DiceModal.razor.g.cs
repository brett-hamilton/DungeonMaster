#pragma checksum "C:\Users\ZJAD35\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\Components\DiceModal.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d5b89886c45164f3cc7efd221b4aeadb071c4ab1"
// <auto-generated/>
#pragma warning disable 1591
namespace DungeonMaster.Pages.Components
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\ZJAD35\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ZJAD35\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ZJAD35\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ZJAD35\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ZJAD35\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ZJAD35\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\ZJAD35\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\ZJAD35\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\ZJAD35\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\_Imports.razor"
using DungeonMaster;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\ZJAD35\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\_Imports.razor"
using DungeonMaster.Shared;

#line default
#line hidden
#nullable disable
    public partial class DiceModal : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "modal");
            __builder.AddAttribute(2, "id", "rollDiceModal");
            __builder.AddAttribute(3, "tabindex", "-1");
            __builder.AddAttribute(4, "role", "dialog");
            __builder.AddAttribute(5, "aria-labelledby", "modalTitle");
            __builder.AddAttribute(6, "aria-hidden", "true");
            __builder.AddAttribute(7, "style", 
#nullable restore
#line 6 "C:\Users\ZJAD35\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\Components\DiceModal.razor"
                                                                                                                          modalShowStyling

#line default
#line hidden
#nullable disable
            );
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "modal-dialog modal-dialog-centered modal");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "id", "mainContent");
            __builder.AddAttribute(12, "class", "modal-content");
            __builder.AddMarkupContent(13, "<div class=\"modal-header\"><h5 class=\"modalTitle\" id=\"rollDiceModalTitle\">Dice Roller</h5></div>\r\n\r\n            ");
            __builder.OpenElement(14, "div");
            __builder.AddAttribute(15, "class", "modal-body");
            __builder.OpenElement(16, "div");
            __builder.AddAttribute(17, "class", "row");
            __builder.AddMarkupContent(18, "<label for=\"dieSides\" class=\"col-4\">Sides on Die: </label>\r\n                    ");
            __builder.OpenElement(19, "select");
            __builder.AddAttribute(20, "name", "dieSides");
            __builder.AddAttribute(21, "id", "dieSides");
            __builder.AddAttribute(22, "class", "col-3");
            __builder.AddAttribute(23, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 17 "C:\Users\ZJAD35\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\Components\DiceModal.razor"
                                   DieSides

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(24, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => DieSides = __value, DieSides));
            __builder.SetUpdatesAttributeName("value");
            __builder.OpenElement(25, "option");
            __builder.AddAttribute(26, "value", "4");
            __builder.AddContent(27, "4");
            __builder.CloseElement();
            __builder.AddMarkupContent(28, "\r\n                        ");
            __builder.OpenElement(29, "option");
            __builder.AddAttribute(30, "value", "6");
            __builder.AddContent(31, "6");
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\r\n                        ");
            __builder.OpenElement(33, "option");
            __builder.AddAttribute(34, "value", "8");
            __builder.AddContent(35, "8");
            __builder.CloseElement();
            __builder.AddMarkupContent(36, "\r\n                        ");
            __builder.OpenElement(37, "option");
            __builder.AddAttribute(38, "value", "12");
            __builder.AddContent(39, "12");
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\r\n                        ");
            __builder.OpenElement(41, "option");
            __builder.AddAttribute(42, "value", "20");
            __builder.AddAttribute(43, "selected");
            __builder.AddContent(44, "20");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(45, "\r\n                ");
            __builder.OpenElement(46, "div");
            __builder.AddAttribute(47, "class", "row");
            __builder.AddMarkupContent(48, "<label for=\"dieToRoll\" class=\"col-4\">Number of Die: </label>\r\n                    ");
            __builder.OpenElement(49, "select");
            __builder.AddAttribute(50, "name", "dieToRoll");
            __builder.AddAttribute(51, "id", "dieToRoll");
            __builder.AddAttribute(52, "class", "col-3");
            __builder.AddAttribute(53, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 27 "C:\Users\ZJAD35\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\Components\DiceModal.razor"
                                   DieToRoll

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(54, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => DieToRoll = __value, DieToRoll));
            __builder.SetUpdatesAttributeName("value");
            __builder.OpenElement(55, "option");
            __builder.AddAttribute(56, "value", "1");
            __builder.AddAttribute(57, "selected");
            __builder.AddContent(58, "1");
            __builder.CloseElement();
            __builder.AddMarkupContent(59, "\r\n                        ");
            __builder.OpenElement(60, "option");
            __builder.AddAttribute(61, "value", "2");
            __builder.AddContent(62, "2");
            __builder.CloseElement();
            __builder.AddMarkupContent(63, "\r\n                        ");
            __builder.OpenElement(64, "option");
            __builder.AddAttribute(65, "value", "3");
            __builder.AddContent(66, "3");
            __builder.CloseElement();
            __builder.AddMarkupContent(67, "\r\n                        ");
            __builder.OpenElement(68, "option");
            __builder.AddAttribute(69, "value", "4");
            __builder.AddContent(70, "4");
            __builder.CloseElement();
            __builder.AddMarkupContent(71, "\r\n                        ");
            __builder.OpenElement(72, "option");
            __builder.AddAttribute(73, "value", "5");
            __builder.AddContent(74, "5");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(75, "\r\n\r\n            ");
            __builder.OpenElement(76, "div");
            __builder.AddAttribute(77, "class", "modal-footer");
            __builder.AddMarkupContent(78, "<button class=\"btn btn-primary\">Roll!</button>\r\n                ");
            __builder.OpenElement(79, "button");
            __builder.AddAttribute(80, "class", "btn btn-secondary");
            __builder.AddAttribute(81, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 39 "C:\Users\ZJAD35\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\Components\DiceModal.razor"
                                                            CloseModal

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(82, "data-dismiss", "modal");
            __builder.AddContent(83, "Cancel");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 45 "C:\Users\ZJAD35\Source\Repos\su21-4250-skynet-dungeonmaster\DungeonMaster\Pages\Components\DiceModal.razor"
      

    /// <summary>
    /// DieSides and DieToRoll will eventually be communicated to the page the modal is on using SignalR.
    /// </summary>
    public int DieSides { get; set; }
    public int DieToRoll { get; set; }

    /// <summary>
    /// String that represents whether the modal should be displayed or not. Modified by the open and close
    /// modal buttons.
    /// </summary>
    public string modalShowStyling { get; set; } = "display:none";

    /// <summary>
    /// Method to change styling to display the Modal.
    /// </summary>
    public void OpenModal()
    {
        modalShowStyling = "display:block";
        StateHasChanged();
    }

    /// <summary>
    /// Method to change the styling to hide the Modal.
    /// </summary>
    public void CloseModal()
    {
        modalShowStyling = "display:none";
        StateHasChanged();
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
