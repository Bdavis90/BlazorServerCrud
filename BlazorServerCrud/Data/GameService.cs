using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerCrud.Data
{
    public class GameService : IGameService
    {
        private readonly DataContext _context;
        private readonly NavigationManager _navigationManager;

        public List<Game> Games { get; set; } = new List<Game>();
        public GameService(DataContext context, NavigationManager navigationManager)
        {
            _context = context;
            _navigationManager = navigationManager;
            _context.Database.EnsureCreated();
        }

        public async Task LoadGamesAsync()
        {
            Games = await _context.Games.ToListAsync();
        }

        public async Task<Game> GetSingleGameAsync(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game is null)
                throw new Exception("No game here.");

            return game;
        }

        public async Task CreateGameAsync(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("videogames");
        }

        public async Task UpdateGameAsync(Game game, int id)
        {
            var dbGame = await _context.Games.FindAsync(id);
            if(dbGame is null)
                throw new Exception("No game here.");

            dbGame.Name = game.Name;
            dbGame.Developer = game.Developer;
            dbGame.Release = game.Release;

            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("videogames");
        }

        public async Task DeleteGameAsync(int id)
        {
            var dbGame = await _context.Games.FindAsync(id);
            if (dbGame is null)
                throw new Exception("No game here.");

            _context.Games.Remove(dbGame);
            _context.SaveChangesAsync();
            _navigationManager.NavigateTo("videogames");
        }
    }
}
