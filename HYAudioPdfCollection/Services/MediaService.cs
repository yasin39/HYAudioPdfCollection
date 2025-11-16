using HYAudioPdfCollection.Client.Models;
using System.Net.Http.Json;

namespace HYAudioPdfCollection.Client.Services
{
    public class MediaService
    {
        private readonly HttpClient _http;



        // Veriyi sadece bir kez yüklemek için bir önbellek (cache) oluşturalım
        private List<MediaFile>? _allFilesCache;
        public MediaService(HttpClient http)
        {
            _http = http;
        }

        // 1. Tüm dosyaları asenkron olarak yükleyen ana metot
        private async Task<List<MediaFile>> GetAllFilesAsync()
        {
            if (_allFilesCache == null)
            {
                // wwwroot/data/media.json adresine bir web isteği yap
                var response = await _http.GetFromJsonAsync<List<MediaFile>>("data/media.json");
                _allFilesCache = response ?? new List<MediaFile>();
            }
            return _allFilesCache;
        }

        // 2. Dile ve tipe göre filtreleyen metot
        public async Task<List<MediaFile>> GetFilesByLanguageAndType(string language, string type)
        {
            var allFiles = await GetAllFilesAsync();
            return allFiles
                .Where(f => f.Language == language && f.Type == type)
                .ToList();
        }

        // 3. Arama metodu
        public async Task<List<MediaFile>> SearchFiles(string searchText)
        {
            var allFiles = await GetAllFilesAsync();

            if (string.IsNullOrWhiteSpace(searchText))
                return allFiles; // Arama boşsa tümünü dön (ya da boş bir liste, tercihe bağlı)

            return allFiles.Where(f =>
                f.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

      
    }
}
