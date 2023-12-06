using LabC22._11.Pages.Search;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace LabC22._11.Pages.FriendSearch;

public class FriendSearchModel : PageModel
{
    private readonly ILogger<FriendSearchModel> _logger;

    public FriendSearchModel(ILogger<FriendSearchModel> logger)
    {
        _logger = logger;
    }

    [BindProperty(SupportsGet = true)]
    public int Participants { get; set; } = 1;

    public ActivityResult ActivityResult { get; set; }

    public async Task OnGet()
    {
        using (HttpClient client = new HttpClient())
        {
            string apiUrl = $"http://www.boredapi.com/api/activity?participants={Participants}";
            string apiResponse = await client.GetStringAsync(apiUrl);

            ActivityResult = JsonConvert.DeserializeObject<ActivityResult>(apiResponse);
        }
    }
}