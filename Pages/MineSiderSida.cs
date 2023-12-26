using System.Threading.Tasks;
using Microsoft.Playwright;
using SynsamAutomatedTests.Pagebase;

namespace Pages;

public class MineSiderSida(IPage page) : Pagebase(page)
{
    private readonly IPage Page = page;
    private readonly ILocator _tillbakeTillStartsida = page.GetByLabel("Tilbake til startsiden");
    private readonly ILocator _epostFält = page.GetByPlaceholder("E-postadresse");
    private readonly ILocator _lösenordFält = page.GetByPlaceholder("Passord");
    private readonly ILocator _loginButton =
        page.GetByRole(AriaRole.Button, new PageGetByRoleOptions() { Name = "Logg Inn" });
    private readonly ILocator _glömtLösenord = page.GetByRole(AriaRole.Link, new() { Name = "Jeg har glemt passordet mitt" });

    public ILocator TillbakeTillStartsida => _tillbakeTillStartsida;
    public ILocator EpostFält => _epostFält;
    public ILocator LösenordFält => _lösenordFält;
    public ILocator LoginButton => _loginButton;
    public ILocator GlömtLösenord => _glömtLösenord;

    public async Task GåTillbakeTillStartsida()
    {
        await TillbakeTillStartsida.ClickAsync();
    }
    public async Task SkrivEpost()
    {
       await EpostFält.FillAsync("prod.apel@gmail.com");
    }
    public async Task SkrivLösenord()
    {
        await LösenordFält.FillAsync("FailedLogin");
    }
    public async Task ClickLogin()
    {
        await LoginButton.ClickAsync();
    }

    public async Task ClickGlömtLösenord()
    {
        await GlömtLösenord.ClickAsync();
    }

}