using System.ComponentModel;
using System.Threading.Tasks;

namespace DungeonMaster.Pages.Models
{
    public class GameManager : INotifyPropertyChanged
    {
        private readonly int moveSpeed = 1;

        public event PropertyChangedEventHandler PropertyChanged;

        public PlayerModel Player { get; set; }

        public bool IsRunning { get; set; } = false;

        public GameManager()
        {
            Player = new PlayerModel();
        }

        public async void MainLoop()
        {
            IsRunning = true;
            while (IsRunning)
            {

                // Player.Move(2);

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Player)));

                await Task.Delay(20);
            }
        }
    }
}
