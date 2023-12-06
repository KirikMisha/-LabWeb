using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LabC22._11.Pages.Profile;

public class ProfileModel : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;

    public ProfileModel(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public string UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }

    public async Task OnGet()
    {
        var user = await _userManager.GetUserAsync(User);

        if (user != null)
        {
            UserId = user.Id;
            Username = user.UserName;
            Email = user.Email;
        }
    }
}