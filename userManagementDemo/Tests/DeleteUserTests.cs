using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using userManagementDemo.Base;
using userManagementDemo.Pages;

namespace userManagementDemo.Tests;

[Parallelizable]
public class DeleteUserTests 
{
    string _genericPassword;
    string _standardUser;
    private string _baseAddress = Initialize.BaseAddress;
    private IPage _page;
    private IBrowserContext _context;
    protected LoginPage loginPage;

    [SetUp]
    public async Task Setup()
    {            
        PlaywrightDriver playwrightDriver = new PlaywrightDriver();
        _page = await playwrightDriver.InitalizePlaywrightTracingAsync();
        _context = playwrightDriver.Context;
        loginPage = new LoginPage(_page);
        loginPage.AddName(TestContext.CurrentContext.Test.Name);
        await loginPage.GotoAsync();

    }

    [Test, Category("Delete User")]
    [TestCase(TestName = "Verify user can able to delete")]
    public async Task DeleteUser_Test()
    {
        //Arrange
        _genericPassword = Environment.GetEnvironmentVariable("PASSWORD");
        _standardUser = Environment.GetEnvironmentVariable("USER");
        //Act
        await loginPage.LoginAsync("kavithasub", "Welcome123");

        //await _page.WaitForLoadStateAsync();

        await Task.Delay(100000);

        Assert.That(await loginPage.HasWelcome(), Is.True);

        //Assert
        string expectedPage = _baseAddress + Constants.OVERVIEW_PAGE;
        
        loginPage.AssertEqual(expectedPage, _page.Url, "Check URL Page equal to: '" + expectedPage + "'");
    
        HomePage homePage = new HomePage(_page);

        await homePage.TeamMembersAsync();

        AddUserPage addUserPage = new AddUserPage(_page);

        await addUserPage.SaveTeamTembersAsync(Constants.ASSIGNROLE, Constants.UPDATED_FIRSTNAME, Constants.LASTNAME, Constants.EMAIL, Constants.USERNAME, Constants.PASSWORD, Constants.CONFIRMPASSWORD);

        await homePage.TeamMembersAsync();

        await addUserPage.searchUser(Constants.UPDATED_FIRSTNAME);

        DeleteUserPage deleteUserPage = new DeleteUserPage(_page);

        await deleteUserPage.deleteUser();

        await Task.Delay(10000);

        await homePage.TeamMembersAsync();

        await addUserPage.searchUser(Constants.UPDATED_FIRSTNAME);

        Assert.That(await addUserPage.HasUserVisible(), Is.False);
    }
        
    [TearDown]
    public async Task BaseTearDownAsync()
    {
        string tracePath = System.IO.Path.Combine(TestContext.CurrentContext.TestDirectory, "trace.zip");
        // Stop tracing and export it into a zip archive.
        await _context.Tracing.StopAsync(new TracingStopOptions
        {
            Path = tracePath
        });
        TestContext.AddTestAttachment(tracePath);
        //To open the tracing
        //playwright show-trace trace.zip
    }
}