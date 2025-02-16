namespace ArtifactsScraper.Responses;

public class CommonArtifactVersionsResponse
{
    public string critical { get; set; } = String.Empty;
    public string recommended { get; set; } = String.Empty;
    public string latest { get; set; } = String.Empty;
    public string optional { get; set; } = String.Empty;
}