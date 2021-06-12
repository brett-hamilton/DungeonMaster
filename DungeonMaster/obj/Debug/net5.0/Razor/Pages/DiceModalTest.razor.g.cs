#pragma checksum "C:\Users\pokel\Source\Repos\DungeonMaster\DungeonMaster\Pages\DiceModalTest.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "92b0bb6eb616ce640e2f29ce739fe22908ed01fb"
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
#line 1 "C:\Users\pokel\Source\Repos\DungeonMaster\DungeonMaster\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\pokel\Source\Repos\DungeonMaster\DungeonMaster\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\pokel\Source\Repos\DungeonMaster\DungeonMaster\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\pokel\Source\Repos\DungeonMaster\DungeonMaster\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\pokel\Source\Repos\DungeonMaster\DungeonMaster\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\pokel\Source\Repos\DungeonMaster\DungeonMaster\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\pokel\Source\Repos\DungeonMaster\DungeonMaster\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\pokel\Source\Repos\DungeonMaster\DungeonMaster\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\pokel\Source\Repos\DungeonMaster\DungeonMaster\_Imports.razor"
using DungeonMaster;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\pokel\Source\Repos\DungeonMaster\DungeonMaster\_Imports.razor"
using DungeonMaster.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\pokel\Source\Repos\DungeonMaster\DungeonMaster\_Imports.razor"
using DungeonMaster.Pages.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\pokel\Source\Repos\DungeonMaster\DungeonMaster\_Imports.razor"
using DungeonMaster.Pages.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\pokel\Source\Repos\DungeonMaster\DungeonMaster\Pages\DiceModalTest.razor"
using DungeonMaster.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/DiceModalTest")]
    public partial class DiceModalTest : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Dice Modal Test</h3>\r\n<hr>\r\n<br>\r\n");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "row");
            __builder.AddMarkupContent(3, "<label class=\"col-2\">Dice Total: </label>\r\n    ");
            __builder.OpenElement(4, "input");
            __builder.AddAttribute(5, "class", "col-1");
            __builder.AddAttribute(6, "readonly");
            __builder.AddAttribute(7, "value", 
#nullable restore
#line 11 "C:\Users\pokel\Source\Repos\DungeonMaster\DungeonMaster\Pages\DiceModalTest.razor"
                                          diceTotal

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\r\n\r\n");
            __builder.OpenComponent<DungeonMaster.Pages.Components.DiceModal>(9);
            __builder.AddComponentReferenceCapture(10, (__value) => {
#nullable restore
#line 14 "C:\Users\pokel\Source\Repos\DungeonMaster\DungeonMaster\Pages\DiceModalTest.razor"
                                                DiceModal = (DungeonMaster.Pages.Components.DiceModal)__value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseComponent();
            __builder.AddMarkupContent(11, "\r\n");
            __builder.OpenElement(12, "button");
            __builder.AddAttribute(13, "class", "btn btn-primary");
            __builder.AddAttribute(14, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 15 "C:\Users\pokel\Source\Repos\DungeonMaster\DungeonMaster\Pages\DiceModalTest.razor"
                                          () => DiceModal.OpenModal()

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(15, " Roll Dice");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 17 "C:\Users\pokel\Source\Repos\DungeonMaster\DungeonMaster\Pages\DiceModalTest.razor"
       
    /// <summary>
    /// Modal that is to be displayed on the page.
    /// </summary>
    private DungeonMaster.Pages.Components.DiceModal DiceModal { get; set; }

    /// <summary>
    /// Int representing the result of the dice roll.
    /// </summary>
    private int diceTotal;

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
