using System;
using Microsoft.Playwright;
using NUnit.Framework;

namespace userManagementDemo;

[SetUpFixture]
public class Initialize
{

    public static IPage Page;
    public static string BaseAddress;

    [OneTimeSetUp]
    public static void  Setup()
    {
       BaseAddress = Environment.GetEnvironmentVariable(Constants.BASE_ADDRESS) ?? "https://rta-edu-stg-web-03.azurewebsites.net/core";
    }

    [OneTimeTearDown]
    public static void AssemblyCleanup()
    {
        
    }
}
