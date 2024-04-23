namespace IssueTrackerApi.Services;

public class SupportHttpClient
{
    private readonly HttpClient _httpClient;

    public SupportHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CurrentSupportResponse?> GetCurrentSupportInformationAsync()
    {
        var response = await _httpClient.GetAsync("/");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadFromJsonAsync<CurrentSupportResponse>();
        return content;
    }
}

public record CurrentSupportResponse
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}
