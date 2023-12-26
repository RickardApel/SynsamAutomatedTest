using System.Threading.Tasks;
using Microsoft.Playwright;
using SynsamAutomatedTests.Pagebase;

namespace Pages;

public class TomFordBrillerSida (IPage page) : Pagebase(page)
{
    private readonly IPage Page = page;

    private readonly ILocator _TomFordBriller =
        page.GetByRole(AriaRole.Link, new() { Name = "Tom Ford FT5294 001 48" });
    private readonly ILocator _sorteraButton = page.GetByRole(AriaRole.Button, new PageGetByRoleOptions(){Name = "Bestselger" });
    private readonly ILocator _prisHögtTillLågt = page.GetByRole(AriaRole.Button, new() { Name = "Pris (høyt til lavt)" });

    public ILocator TomFordBriller => _TomFordBriller;
    public ILocator SorteraButton => _sorteraButton;
    public ILocator PrisHögtTillLågt => _prisHögtTillLågt;

    public async Task ClickTomFordBriller()
    {
        await TomFordBriller.ClickAsync();
    }

    public async Task SorteraEfterPrisHögtTillLågt()
    {
        await SorteraButton.ClickAsync();
        await PrisHögtTillLågt.ClickAsync();
    }


}