namespace LabC22._11.Pages.Search;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

public class SearchModel : PageModel
{
    private readonly ILogger<SearchModel> _logger;

    public SearchModel(ILogger<SearchModel> logger)
    {
        _logger = logger;
    }

    [BindProperty(SupportsGet = true)]
    public string ActivityType { get; set; } = "recreational";

    public ActivityResult ActivityResult { get; set; }

    public async Task OnGet()
    {
        using (HttpClient client = new HttpClient())
        {
            string apiUrl = $"http://www.boredapi.com/api/activity?type={ActivityType.ToLower()}";
            string apiResponse = await client.GetStringAsync(apiUrl);

            ActivityResult = JsonConvert.DeserializeObject<ActivityResult>(apiResponse);
        }
    }
}

public class ActivityResult
{
    public string Activity { get; set; }
    public string Type { get; set; }
    public int Participants { get; set; }
}
