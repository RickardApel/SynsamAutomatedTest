using System.Threading.Tasks;
using Microsoft.Playwright;
using SynsamAutomatedTests.Pagebase;

namespace Pages;

public class FinnButikkSida(IPage page) : Pagebase(page)
{               
    private readonly IPage Page = page;
    private readonly ILocator _finnButikkSökfält = page.GetByPlaceholder("Søk etter by, navn eller sted.");
    private readonly ILocator _finnButikkSökBtn = page.GetByText("Søk", new() { Exact = true });
    private readonly ILocator _synsamAkerBrygge = page.GetByRole(AriaRole.Button, new() { Name = "Synsam Aker Brygge" });
    private readonly ILocator _lesMer = page.GetByRole(AriaRole.Link, new() { Name = "Les mer" }).Nth(1);
    private readonly ILocator _visAlleOpningstider = page.GetByRole(AriaRole.Button, new() { Name = "Vis alle åpningstider" });
    private readonly ILocator _skjulOpningstider = page.GetByRole(AriaRole.Button, new() { Name = "Skjul åpningstider" });
    
    public ILocator FinnButikkSökfält => _finnButikkSökfält;
    public ILocator FinnButikkSökBtn => _finnButikkSökBtn;
    public ILocator SynsamAkerBrygge => _synsamAkerBrygge;
    public ILocator LesMer => _lesMer;
    public ILocator VisAlleOpningstider => _visAlleOpningstider;
    public ILocator SkjulOpningstider => _skjulOpningstider;

    public async Task ClickFinnButikkSökfält()
    {
       await FinnButikkSökfält.ClickAsync();
    }

    public async Task SkrivOsloISökfältet()
    {
        await FinnButikkSökfält.FillAsync("Oslo");
    }

    public async Task ClickSökBtn()
    {
       await FinnButikkSökBtn.ClickAsync();
    }

    public async Task ClickSynsamAkerBrygge()
    {
        await SynsamAkerBrygge.ClickAsync();
    }

    public async Task ClickLesmer()
    {
       await LesMer.ClickAsync();
    }

    public async Task ClickVisAlleOpningstider()
    {
        await VisAlleOpningstider.ClickAsync();
    }

    public async Task ClickSkjulOpningstider()
    {
        SkjulOpningstider.ClickAsync();
    }
}