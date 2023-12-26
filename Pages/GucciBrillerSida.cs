using System.Threading.Tasks;
using Microsoft.Playwright;
using SynsamAutomatedTests.Pagebase;

namespace Pages;

public class GucciBrillerSida(IPage page) : Pagebase(page)
{
    private  IPage Page => page;
    private readonly ILocator _gucciGG0027O001 = page.GetByRole(AriaRole.Link, new() { Name = "Gucci GG 0027O 001 5020 Gucci" });
    
    public ILocator GucciGG0027O001 => _gucciGG0027O001;
    
    public async Task ClickGucciGG1()
    {
        GucciGG0027O001.ClickAsync();
    }

}