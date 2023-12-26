using Microsoft.Playwright;

namespace SynsamAutomatedTests.Pagebase;

public class Pagebase
{
    private IPage page;

    public void PageBase()
    {
    }

    public Pagebase(IPage page)
    {
        this.page = page;
    }
}