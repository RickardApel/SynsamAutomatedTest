using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using SynsamAutomatedTests.Pagebase;

namespace Pages;

public class BlinkContactOyedråperSida(IPage page) : Pagebase(page)
{
    private readonly IPage Page = page;
    private readonly ILocator _leggIVarukorg = page.GetByRole(AriaRole.Button, new() { Name = "Legg til i handlekurven" });
    private readonly ILocator _varukorgTotal = page.GetByText("Totaltkr");


    public ILocator LeggIVarukorg => _leggIVarukorg;
    public ILocator VarukorgTotal => _varukorgTotal;

    public async Task ClickLeggIVarukorg()
    {
        await LeggIVarukorg.ClickAsync();
    }
    
}