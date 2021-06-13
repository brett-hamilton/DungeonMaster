using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMaster.Pages.Models
{
    public class GameManager
    {

        public PlayerModel Player { get; set; }

        public bool IsRunning { get; set; } = false;

        public GameManager()
        {
            Player = new PlayerModel();
        }

        public async void MainLoop()
        {
            IsRunning = true;
            while(IsRunning)
            {



            }
        }  
    }
}
