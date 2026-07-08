namespace PokeApi.Client.Dtos;

public class PokeListDto
{
    public int Count { get; set; } = 0;
    public string? Next { get; set; }
    public string? Previous { get; set; }
    public ResultDto[] Results { get; set; } = [];
}
