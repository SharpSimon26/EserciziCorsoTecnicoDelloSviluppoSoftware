namespace JsonPlaceholder.DataAccess.Models.ViewModels;

public class PhotoWithLikesViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ThumbnailUrl { get; set; } = string.Empty;
    public int NumLikes { get; set; }
}
