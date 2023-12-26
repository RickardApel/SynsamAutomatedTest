using System.Threading.Tasks;
using Microsoft.Playwright;
using SynsamAutomatedTests.Pagebase;

namespace Pages;

public class AbonnemangSida(IPage page) : Pagebase(page)
{
    private readonly IPage Page = page;
    private readonly ILocator _komIGang = page.GetByRole(AriaRole.Link, new() { Name = "Kom i gang" });

    public ILocator _KomIGang => _komIGang;

    public async Task clickKomIGang()
    {
        await _komIGang.ClickAsync();
    }

}