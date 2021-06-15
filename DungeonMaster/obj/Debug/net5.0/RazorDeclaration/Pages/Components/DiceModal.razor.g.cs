// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace DungeonMaster.Pages.Components
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
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
#line 1 "C:\Users\hunte\source\repos\su21-4250-skynet-dungeonmaster\DungeonMasterV2\DungeonMaster\Pages\Components\DiceModal.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hunte\source\repos\su21-4250-skynet-dungeonmaster\DungeonMasterV2\DungeonMaster\Pages\Components\DiceModal.razor"
using DungeonMaster.Data;

#line default
#line hidden
#nullable disable
    public partial class DiceModal : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 56 "C:\Users\hunte\source\repos\su21-4250-skynet-dungeonmaster\DungeonMasterV2\DungeonMaster\Pages\Components\DiceModal.razor"
      

    /// <summary>
    /// DieSides and DieToRoll will eventually be communicated to the page the modal is on using SignalR.
    /// </summary>
    public int DieSides { get; set; }
    public int DieToRoll { get; set; }

    /// <summary>
    /// Result to be displayed showing the result of the dice roll.
    /// </summary>
    private string diceResult;

    /// <summary>
    /// String that represents whether the modal should be displayed or not. Modified by the open and close
    /// modal buttons.
    /// </summary>
    public string modalShowStyling { get; set; } = "display:none";

    /// <summary>
    /// Hub connection used to send and receive messages.
    /// </summary>
    private HubConnection hubConnection;

    /// <summary>
    /// Method to initialize our hub connection used to send and receive messages.
    /// When a message is received, it is added to the game log.
    /// This is modified from the Microsoft SignalR tutorial.
    /// </summary>
    /// <returns></returns>
    protected override async Task OnInitializedAsync()
    {
        hubConnection = new HubConnectionBuilder()
                .WithUrl(NavigationManager.ToAbsoluteUri("/dungeonmasterhub"))
                .Build();

        // As the modal doesn't need to listen, we only start it to send messages.
        await hubConnection.StartAsync();
    }

    /// <summary>
    /// Method to report the result to the page holding the modal to display.
    /// This is based on the Microsoft SignalR tutorial.
    /// </summary>
    /// <returns></returns>
    async Task Send() =>
        await hubConnection.SendAsync("SendMessage", diceResult, "DiceModalTest");

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

    /// <summary>
    /// Method to roll multiple dice and report the result to the user.
    /// </summary>
    /// <returns></returns>
    public async Task RollMultipleDice()
    {
        // If the roll is successful, report it to the main page.
        try
        {
            var rollReport = Die.Roll(DieSides, DieToRoll);
            diceResult = $"Player rolled {rollReport.GetDiceReport()}";
            CloseModal();
            await Send();
        }
        // If not, null out the result, and output the error to the console.
        catch (Exception e)
        {
            Console.WriteLine(e);
            diceResult = null;
        }
    }

    /// <summary>
    /// Method to roll a single D20, and report the result to the page holding the modal.
    /// </summary>
    /// <returns></returns>
    public async Task Roll()
    {
        var diceTotal = Die.RollD20();
        diceResult = $"Player rolled 1 D20 for {diceTotal}";
        CloseModal();
        await Send();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
