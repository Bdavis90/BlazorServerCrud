namespace BlazorServerCrud.Data
{
    public interface IGameService
    {
        List<Game> Games { get; set; }
        Task LoadGamesAsync();
        Task<Game> GetSingleGameAsync(int id);
        Task CreateGameAsync(Game game);
        Task UpdateGameAsync(Game game, int id);
        Task DeleteGameAsync(int id);
    }
}
