using JsonPlaceholder.ApiClient;
using JsonPlaceholder.DataAccess.Repositories;
using Microsoft.Extensions.Logging;

namespace JsonPlaceholder.Console;

public class ImportEngine
{
    private IPhotosApiClient _photosApiClient;
    private IPhotosRepository _photosRepository;
    private ILogger<ImportEngine> _logger;

    public ImportEngine(IPhotosApiClient photosApiClient, IPhotosRepository photosRepository, ILogger<ImportEngine> logger)
    {
        _photosApiClient = photosApiClient;
        _photosRepository = photosRepository;
        _logger = logger;
    }

    public async Task RunAsync()
    {
        // Scarica le foto dall' API
        var photosFromApi = await _photosApiClient.GetAllAsync();

        // Prende l'elenco delle foto già presenti sul database
        var oldPhotosFromDb = await _photosRepository.GetAllAsync();

        foreach (var photo in photosFromApi)
        {
            // Verifica se l'id è presente sul database -> se non c'è lo inserisce
            if (!oldPhotosFromDb.Any(x => x.Id == photo.Id))
            {
                var affectedRows = await _photosRepository.AddPhoto(photo.Id, photo.AlbumId, photo.Title, photo.Url, photo.ThumbnailUrl);

                _logger.LogInformation($"Inserimento Id: {photo.Id} - Title: {photo.Title}");
            }
            else
            {
                _logger.LogInformation($"Record duplicato Id: {photo.Id} - Title: {photo.Title}");
            }
        }
    }
}
