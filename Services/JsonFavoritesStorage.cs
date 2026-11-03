using Newtonsoft.Json;
using TodoExplorer.Models;

namespace TodoExplorer.Services;

public class JsonFavoritesStorage : IFavoritesStorage
{
    private string filePath;
    
    public JsonFavoritesStorage(string directory, string filePath)
    {
        this.filePath = Path.Combine(directory, filePath);
    }
    public async Task<List<int>> LoadFavorites()
    {
        if (!File.Exists(filePath))
        {
            return new List<int>();
        }
        StreamReader reader = new StreamReader(filePath);
        string json = await reader.ReadToEndAsync();
        List<int> favID = JsonConvert.DeserializeObject<List<int>>(json);
        return favID;
    }

    public async Task SaveFavorites(List<int> favoriteIds)
    {
        StreamWriter writer = new StreamWriter(filePath);
        string json = JsonConvert.SerializeObject(favoriteIds);
        await writer.WriteAsync(json);
        writer.Close();
    }
}