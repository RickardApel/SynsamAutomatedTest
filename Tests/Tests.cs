
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Pages;


namespace Tests;


public class Tests : PageTest
{
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public async Task FlowTest1()
    {
        Startsida startsida = new Startsida(Page);
        await startsida.OpenStartsida();
        await startsida.acceptCookies();
        await startsida.ClickBrillerNav();
        await startsida.ClickGucciInPopup();
        GucciBrillerSida gucciBrillerSida = new GucciBrillerSida(Page);
        await gucciBrillerSida.ClickGucciGG1();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Finn butikk" }).Nth(2).ClickAsync();
        FinnButikkSida finnButikkSida = new FinnButikkSida(Page);
        //await finnButikkSida.ClickFinnButikkSökfält();
        //await finnButikkSida.SkrivOsloISökfältet();
        //await finnButikkSida.ClickSökBtn();
        //await finnButikkSida.ClickSynsamAkerBrygge();
        await Page.GetByRole(AriaRole.Button, new PageGetByRoleOptions() { Name = "Synsam Alta Amfi" }).ClickAsync();
        //await finnButikkSida.ClickLesmer();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Les mer" }).Nth(1).ClickAsync();
        //await finnButikkSida.ClickVisAlleOpningstider();
        await Page.GetByRole(AriaRole.Button, new() { Name = "Vis alle åpningstider" }).ClickAsync();
        //await finnButikkSida.ClickSkjulOpningstider();
        await Page.GetByRole(AriaRole.Button, new() { Name = "Skjul åpningstider" }).ClickAsync();
        await Expect(Page.Locator("[id=\"__next\"]")).ToContainTextAsync("Vis alle åpningstider");

    }

    [Test]
    public async Task SearchTestTomFord()
    {
        Startsida startsida = new Startsida(Page);
        await startsida.OpenStartsida();
        await startsida.acceptCookies();
        await startsida.ClickSökfält();
        await startsida.SkrivTomFord();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Tom Ford - Briller Vis alle" }).ClickAsync();
        TomFordBrillerSida tomFordBrillerSida = new TomFordBrillerSida(Page);
        await tomFordBrillerSida.ClickTomFordBriller();
    }

    [Test]
    public async Task SearchTestLeseBriller()
    { 
        Startsida startsida = new Startsida(Page);
        await startsida.OpenStartsida();
        await startsida.acceptCookies();
        await startsida.ClickSökfält();
        await startsida.SkrivLäsglasögon();
        await startsida.ClickSökButton();
        SökresultatSida sökresultatSida = new SökresultatSida(Page);
        await Expect(Page.Locator("[id=\"__next\"]")).ToContainTextAsync("Lesebriller - Readers");   
    }

    [Test]
    public async Task RandomNavigationTest1()
    {
        Startsida startsida = new Startsida(Page);
        await startsida.OpenStartsida();
        await startsida.acceptCookies();
        await startsida.ClickMineSider();
        MineSiderSida mineSiderSida = new MineSiderSida(Page);
        await mineSiderSida.SkrivEpost();
        await mineSiderSida.GåTillbakeTillStartsida();
        await startsida.ClickFinnButikk();
        await startsida.ClickHemKnappen();
        await startsida.ClickMenyFönster();
        await startsida.ClickCloseMenyFönster();
        await startsida.ClickMineSider();
        await Expect(Page.GetByRole(AriaRole.Button, new() { Name = "Logg inn" })).ToBeVisibleAsync();
    }

    [Test]
    public async Task BrilleAbonnementTest()
    {
    
        Startsida startsida = new Startsida(Page);
        await startsida.OpenStartsida();
        await startsida.acceptCookies();
        await startsida.ClickBrilleAbonnementNav();
        AbonnemangSida abonnemangSida = new AbonnemangSida(Page);
        await abonnemangSida.clickKomIGang();
    }

    [Test]
    public async Task OyeHelseTest()
    {
        Startsida startsida = new Startsida(Page);
        await startsida.OpenStartsida();
        await startsida.acceptCookies();
        await startsida.ClickKontaktlinserNav();
        await startsida.ClickOyehelseInPopup();
        OyehelseSida oyehelseSida = new OyehelseSida(Page);
        await oyehelseSida.SorteraEfterPrisLågtTillHögt();
        await oyehelseSida.ClickBlinkContactOyedråper();
        BlinkContactOyedråperSida blinkContactOyedråperSida = new BlinkContactOyedråperSida(Page);
        await blinkContactOyedråperSida.ClickLeggIVarukorg();
    }

    [Test]
    public async Task FailedLoginTest()
    {
        Startsida startsida = new Startsida(Page);
        await startsida.OpenStartsida();
        await startsida.acceptCookies();
        await startsida.ClickMineSider();
        MineSiderSida mineSiderSida = new MineSiderSida(Page);
        await mineSiderSida.SkrivEpost();
        await mineSiderSida.SkrivLösenord();
        await mineSiderSida.ClickLogin();
        await Expect(Page.GetByText("Innloggingen mislyktes, prøv")).ToBeVisibleAsync();
        await mineSiderSida.ClickGlömtLösenord();
        await Expect(Page.GetByText("Vennligst oppgi e-")).ToBeVisibleAsync();
    }

    [Test]
    public async Task SportbrillerTest()
    {
        Startsida startsida = new Startsida(Page);
        await startsida.OpenStartsida();
        await startsida.acceptCookies();
        await startsida.ClickSportsbrillerNav();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Alpin" }).ClickAsync();
        await Page.GetByLabel("Filtrer produkter").ClickAsync();
        await Page.GetByRole(AriaRole.Button, new() { Name = "Sports", Exact = true }).ClickAsync();
        await Page.GetByLabel("Close filter menu").ClickAsync();
        await Page.GetByRole(AriaRole.Button, new() { Name = "Varemerke" }).ClickAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Gucci (4)" }).ClickAsync();
        await Page.GetByRole(AriaRole.Button, new() { Name = "Vis 4 Produkter" }).ClickAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Gucci GG1210S 001 Gucci" }).ClickAsync();
        await Page.GetByRole(AriaRole.Button, new() { Name = "Legg til i handlekurven" }).ClickAsync();
        //await Expect(Page.Locator("[id=\"__next\"]")).ToContainTextAsync("kr 7735");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Tøm handlekurven" }).ClickAsync();
        await Expect(Page.Locator("[id=\"__next\"]")).ToContainTextAsync("Handlekurven din er tom!");
    }

    [Test]
    public async Task KundserviceNavTest()
    {
        Startsida startsida = new Startsida(Page);
        await startsida.OpenStartsida();
        await startsida.acceptCookies();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Kundeservice" }).ClickAsync();
        await Page.GetByLabel("Kjøps og leveransevilkår").ClickAsync();
        await Expect(Page.GetByText("SynsamKjøps- og leveransevilk")).ToBeVisibleAsync();
    }

    [Test]
    public async Task FinnButikkTest()
    {
        Startsida startsida = new Startsida(Page);
        await startsida.OpenStartsida();
        await startsida.acceptCookies();
        await startsida.ClickFinnButikk();
        FinnButikkSida finnButikkSida = new FinnButikkSida(Page);
        await Page.GetByRole(AriaRole.Button, new PageGetByRoleOptions() { Name = "Synsam Alta Amfi" }).ClickAsync();
        await Expect(Page.Locator("#store-locator-store-12843").GetByText("Markedsgata 21-")).ToBeVisibleAsync();
    }

    [Test]
    public async Task EmptyCartTest()
    {
        Startsida startsida = new Startsida(Page);
        await startsida.OpenStartsida();
        await startsida.acceptCookies();
        await startsida.ToggleVarukorg();
        await Expect(Page.Locator("[id=\"__next\"]")).ToContainTextAsync("Handlekurven din er tom!");
    }
    
    
    
}

