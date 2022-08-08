
using BlazorServerCrud.Data;
using Microsoft.AspNetCore.Components;

namespace BlazorServerCrud.Pages
{
    public partial class VideoGames
    {
        [Inject]
        public IGameService GameService{ get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await GameService.LoadGamesAsync();
        }

        private void ShowGame(int id)
        {
            NavigationManager.NavigateTo($"videogame/{id}");
        }

        private void CreateNewGame()
        {
            NavigationManager.NavigateTo("videogame");
        }
    }
}
