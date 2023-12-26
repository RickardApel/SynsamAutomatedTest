using System.Threading.Tasks;
using Microsoft.Playwright;
using SynsamAutomatedTests.Pagebase;

namespace Pages;

public class OyehelseSida(IPage page) : Pagebase(page)
{
    private readonly IPage Page = page;
    private readonly ILocator _blinkContactsOyedråper = page.GetByRole(AriaRole.Link, new() { Name = "Blink contacts Øyedråper 10" });
    private readonly ILocator _oxyalCareOyegele = page.GetByRole(AriaRole.Link, new() { Name = "Oxyal Care Øyegelé 10 g Oxyal" });
    private readonly ILocator _sorteraButton = page.GetByLabel("Sorter");
    private readonly ILocator _prisHögtTillLågt = page.GetByRole(AriaRole.Button, new() { Name = "Pris (høyt til lavt)" });
    private readonly ILocator _prisLågTillHögt = page.GetByRole(AriaRole.Button, new() { Name = "Pris (lavt til høyt)" });

    public ILocator BlinkContactsOyedråper => _blinkContactsOyedråper;
    public ILocator OxyalCareOyeGele => _oxyalCareOyegele;
    public ILocator SorteraButton => _sorteraButton;
    public ILocator PrisHögtTillLågt => _prisHögtTillLågt;
    public ILocator PrisLågtTillHögt => _prisLågTillHögt;
    
    public async Task SorteraEfterPrisHögtTillLågt()
    {
        await SorteraButton.ClickAsync();
        await PrisHögtTillLågt.ClickAsync();
    }

    public async Task SorteraEfterPrisLågtTillHögt()
    {
        await SorteraButton.ClickAsync();
        await PrisLågtTillHögt.ClickAsync();
    }

    public async Task ClickBlinkContactOyedråper()
    {
        await BlinkContactsOyedråper.ClickAsync();
    }
}