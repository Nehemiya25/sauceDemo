## Setup Playwright

Install Playwright for C#

1. Install the Playwright tool with the next command 
```console
  dotnet tool install --global Microsoft.Playwright.CLI 
```
 
 2. Install Playwright (this includes the browsers Chromium, Firefox, Webkit). Execute this command inside the project path. Sample path c:\Projects\userManagementDemo
 ```console
   playwright install
 ```

## Run tests

You can run the test from Windows, MacOS or with Azure Devops Pipeline

You can run with different browsers

```console
    dotnet test -s chromium.runsettings
    dotnet test -s webkit.runsettings
    dotnet test -s firefox.runsettings
```

For run only some test, for example run the test that contains Add User in the name

```console
    dotnet test --filter "Name~Add User"
```

