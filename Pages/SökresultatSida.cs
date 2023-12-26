using System.Threading.Tasks;
using Microsoft.Playwright;
using SynsamAutomatedTests.Pagebase;

namespace Pages;

public class SökresultatSida (IPage page) : Pagebase (page)
{
    private readonly IPage Page = page;
    private readonly ILocator _TomFordBrillerNav = page.GetByRole(AriaRole.Link, new() { Name = "Tom Ford - Briller" });

    public ILocator TomFordBrillerNav => _TomFordBrillerNav;

    public async Task ClickTomFordBrillerNav()
    {
        await TomFordBrillerNav.ClickAsync();
    }
}