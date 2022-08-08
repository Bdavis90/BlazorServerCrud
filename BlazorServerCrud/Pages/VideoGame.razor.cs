using BlazorServerCrud.Data;
using Microsoft.AspNetCore.Components;

namespace BlazorServerCrud.Pages
{
    public partial class VideoGame
    {
        [Inject]
        public IGameService GameService{ get; set; }
        [Parameter]
        public int? Id { get; set; }
        private Game game = new Game();
        string btnText = string.Empty;
        
        protected async override Task OnParametersSetAsync()
        {
            if(Id is not null)
                game = await GameService.GetSingleGameAsync((int)Id);
        }

        protected override void OnInitialized()
        {
            btnText = Id is null ? "Save New Game" : "Update Game";
        }

        private async Task HandleSubmitAsync()
        {
            if (Id is null)
            {
                await GameService.CreateGameAsync(game);
            }
            else
            {
                await GameService.UpdateGameAsync(game, (int)Id);
            }
        }

        private async Task DeleteGame()
        {
            await GameService.DeleteGameAsync(game.Id);
        }
    }
}
