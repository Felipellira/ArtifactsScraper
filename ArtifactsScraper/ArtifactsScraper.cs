using System.Text.Json;
using ArtifactsScraper.Responses;
using HtmlAgilityPack;
using Environment = ArtifactsScraper.Enums.Environment;

namespace ArtifactsScraper;
    
public class ArtifactsScraper
{
    
    private string _apiUrl;
    private string _downloadPage;

    public ArtifactsScraper(Environment environment)
    {
        if (environment == Environment.Linux)
        {
            this._apiUrl = "https://changelogs-live.fivem.net/api/changelog/versions/linux/server";
            this._downloadPage = "https://runtime.fivem.net/artifacts/fivem/build_proot_linux/master/";
        }
        else
        {
            this._apiUrl = "https://changelogs-live.fivem.net/api/changelog/versions/win32/server";
            this._downloadPage = "https://runtime.fivem.net/artifacts/fivem/build_server_windows/master/";
        }
    }

    public async Task<CommonArtifactVersionsResponse> GetCommonArtifactsVersions()
    {
        using var httpClient = new HttpClient();
        
        var response = await httpClient.GetAsync(_apiUrl);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException("Failed to get common artifacts versions.");
        }
        
        var responseContent = await response.Content.ReadAsStringAsync();

        var serializedResponse = JsonSerializer.Deserialize<CommonArtifactVersionsResponse>(responseContent);

        if (serializedResponse is null)
        {
            throw new JsonException("Failed to deserialize common artifacts versions.");
        }
        
        return serializedResponse;
    }

    public async Task<List<ArtifactVersionData>> GetArtifactsVersions()
    {
        List<ArtifactVersionData> versions = [];
        
        var httpClient = new HttpClient();
        
        var response = await httpClient.GetAsync(_downloadPage);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException("Failed to get download page.");
        }
        
        var responseContent = await response.Content.ReadAsStringAsync();
        
        var document = new HtmlDocument();
        
        document.LoadHtml(responseContent);
        
        var versionNode = document.DocumentNode.SelectNodes("//a[contains(@class, 'panel-block')]");

        if (versionNode is null)
        {
            throw new NullReferenceException("Failed to get version nodes.");
        }
        
        foreach (var htmlNode in versionNode)
        {
            var versionWrapper = htmlNode.SelectSingleNode(".//div[@class='level-left']");

            if (versionWrapper is null || versionWrapper.InnerText is null)
            {
                continue;
            }
            
            var version = versionWrapper.InnerText.Trim();

            var href = htmlNode.GetAttributeValue("href", null);
            if (href is null)
            {
                continue;
            }

            var downloadUrl = href;

            versions.Add(new ArtifactVersionData
            {
                Version = version,
                DownloadUrl = downloadUrl.Replace("./", _downloadPage)
            });

        }
        return versions;
    }
}
