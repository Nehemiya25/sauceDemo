﻿using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using userManagementDemo.Pages;

namespace userManagementDemo.Base;

public class BaseTest
{
    protected IPage page;
    protected AddUserPage addUserPage;

    [SetUp]
    public async Task Setup()
    {
        PlaywrightDriver playwrightDriver = new PlaywrightDriver();
        page = await playwrightDriver.InitalizePlaywright();
        var loginPage = new LoginPage(page);
        var _genericPassword = Environment.GetEnvironmentVariable("PASSWORD");
        var _standardUser = Environment.GetEnvironmentVariable("USER");
        await loginPage.GotoAsync(AnnotationType.Precondition);
        await loginPage.LoginAsync(_standardUser, _genericPassword );
        addUserPage = new AddUserPage(page);
    }
}
