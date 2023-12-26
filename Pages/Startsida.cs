using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using SynsamAutomatedTests.Pagebase;


namespace Pages;

public class Startsida(IPage page) : Pagebase(page)
{
    private readonly IPage Page = page;
    private readonly ILocator _brilleAbonnementNav = page.Locator("div")
        .Filter(new() { HasTextRegex = new Regex ("^Brilleabonnement$") }).GetByRole(AriaRole.Link);
    
    private readonly ILocator _cookiesButton = page.GetByRole(AriaRole.Button, new() { Name = "Godta alle cookier" });
    private readonly ILocator _cookiesPopup = page.Locator("#onetrust-group-container");
    private readonly ILocator _mineSiderNav = page.GetByText("mine sider");
    private readonly ILocator _brillerNav =
        page.Locator("button").Filter(new() { HasTextRegex = new Regex("^Briller$") });
    
    private readonly ILocator _gåTIllbakeNavPopup = page.GetByRole(AriaRole.Button, new() { Name = "Gå tilbake" });
    private readonly ILocator _stängMenyNavPopup = page.GetByRole(AriaRole.Button, new() { Name = "Close the menu" });
    private readonly ILocator _solbrillerNav =
        page.Locator("button").Filter(new() { HasTextRegex = new Regex("^Solbriller$") });
    private readonly ILocator _sportsbrillerNav =
        page.Locator("button").Filter(new() { HasTextRegex = new Regex("^Sportsbriller$") });
    private readonly ILocator _kontaktlinserNav =
        page.Locator("button").Filter(new() { HasTextRegex = new Regex("^Kontaktlinser$") });
    private readonly ILocator _sökfält = page.GetByRole(AriaRole.Button, new() { Name = "Søk" });
    private readonly ILocator _sökfältSÖK = page.GetByPlaceholder("Søk etter produkter, butikker");
    private readonly ILocator _sökButton = page.GetByRole(AriaRole.Search).GetByRole(AriaRole.Button);
    private readonly ILocator _finnButikk = page.GetByRole(AriaRole.Link, new() { Name = "Finn butikk" }).Nth(1);
    private readonly ILocator _hemKnappen = page.GetByLabel("Tilbake til startsiden");
    private readonly ILocator _menyFönster = page.GetByRole(AriaRole.Button, new() { Name = "Meny" });
    private readonly ILocator _closeMenyFönster = page.GetByRole(AriaRole.Button, new() { Name = "Close the menu" });
    private readonly ILocator _gucciInPopup = page.GetByRole(AriaRole.Link, new() { Name = "Gucci", Exact = true });
    private readonly ILocator _oyehelseInPopup = page.GetByRole(AriaRole.Banner).GetByRole(AriaRole.Link, new() { Name = "Øyehelse" });
    private readonly ILocator _varukorg = page.GetByLabel("Toggle cart button");
    
    public ILocator _BrilleAbonnementNav => _brilleAbonnementNav;
    public ILocator _CookiesPopup => _cookiesPopup;
    public ILocator _CookiesButton => _cookiesButton;
    public ILocator MineSiderNav => _mineSiderNav;
    public ILocator BrillerNav => _brillerNav;
    public ILocator GåTillbakeNavPopup => _gåTIllbakeNavPopup;
    public ILocator StängMenyNavPopup => _stängMenyNavPopup;
    public ILocator SolbrillerNav => _solbrillerNav;
    public ILocator SportsbrillerNav => _sportsbrillerNav;
    public ILocator KontaktlinserNav => _kontaktlinserNav;
    public ILocator Sökfält => _sökfält;
    public ILocator SökfältSök => _sökfältSÖK;
    public ILocator SökButton => _sökButton;
    public ILocator FinnButikk => _finnButikk;
    public ILocator HemKnappen => _hemKnappen;
    public ILocator MenyFönster => _menyFönster;
    public ILocator CloseMenyFönster => _closeMenyFönster;
    public ILocator GucciInPopup => _gucciInPopup;
    public ILocator OyehelseInPopup => _oyehelseInPopup;
    public ILocator Varukorg => _varukorg;
    

    public async Task OpenStartsida()
    {
        var StartsidaUrl = "https://www.synsam.no/";
        await page.GotoAsync(StartsidaUrl);
    }
    public async Task acceptCookies()
    {
        await _CookiesButton.ClickAsync();
    }
    public async Task ClickBrilleAbonnementNav()
    {
       await _BrilleAbonnementNav.ClickAsync();
    } 
    public async Task ClickMineSider()
    {
        await MineSiderNav.ClickAsync();
    }
    public async Task ClickBrillerNav()
    {
        await BrillerNav.ClickAsync();
    }
    public async Task ClickSolbrillerNav()
    {
        await SolbrillerNav.ClickAsync();
    }
    public async Task ClickSportsbrillerNav()
    {
        SportsbrillerNav.ClickAsync();
    }
    public async Task ClickKontaktlinserNav()
    {
        KontaktlinserNav.ClickAsync();
    }
    public async Task StängMenyPopup()
    {
        await GåTillbakeNavPopup.ClickAsync();
        await StängMenyNavPopup.ClickAsync();
    }
    public async Task ClickSökfält()
    {
        await Sökfält.ClickAsync();
    }
    public async Task SkrivLäsglasögon()
    {
        await SökfältSök.ClickAsync();
        await SökfältSök.FillAsync("lesebriller");
    }
    public async Task SkrivTomFord()
    {
        await SökfältSök.ClickAsync();
        await SökfältSök.FillAsync("Tom Ford");
    }
    public async Task ClickSökButton()
    {
        await SökButton.ClickAsync();
    }
    public async Task ClickFinnButikk()
    {
        await FinnButikk.ClickAsync();
    }
    public async Task ClickHemKnappen()
    {
        await HemKnappen.ClickAsync();
    }
    public async Task ClickMenyFönster()
    {
       await MenyFönster.ClickAsync();
    }
    public async Task ClickCloseMenyFönster()
    {
       await CloseMenyFönster.ClickAsync();
    }
    public async Task ClickGucciInPopup()
    {
        await GucciInPopup.ClickAsync();
    }
    public async Task ClickOyehelseInPopup()
    {
        await OyehelseInPopup.ClickAsync();
    }

    public async Task ToggleVarukorg()
    {
        await Varukorg.ClickAsync();
    }

}