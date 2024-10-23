using System.Threading.Tasks;
using Microsoft.Playwright;
using userManagementDemo.Base;
using userManagementDemo.Components;

namespace userManagementDemo.Pages;

public class LoginPage : BasePage
{
    private InputText _userName;
    private Password _password;
    private Button _login;
    private ILocator _welcomeMessage;
    
    public LoginPage(IPage page) : base(page)
    {
        _userName = new InputText(page,"#signInName", this.annotationHelper);
        _password = new Password(page, "#password", this.annotationHelper);
        _login = new Button(page, "#next", this.annotationHelper);
        _welcomeMessage = page.Locator("//h2[text()=' Welcome']");
    }

    /// <summary>
    /// Go to Login page
    /// </summary>
    /// <returns></returns>
    public async Task GotoAsync(AnnotationType annotationType = AnnotationType.Step) => await this.GotoPageAsync(Initialize.BaseAddress);

    /// <summary>
    /// Get welcome messsage
    /// </summary>
    /// <returns></returns>
    public async Task<string> GetErrorAsync()
    {
        return await _welcomeMessage.TextContentAsync();
    }

    /// <summary>
    /// Returns true if the page has an welocme messsage
    /// </summary>
    /// <returns></returns>
    public async Task<bool> HasWelcome() =>  await _welcomeMessage.IsVisibleAsync();

    /// <summary>
    /// Login with the user and password
    /// </summary>
    /// <param name="user">User login</param>
    /// <param name="password">User password</param>
    /// <returns></returns>
    public async Task LoginAsync(string user, string password)
    {
        await this._userName.FillAsync(user);
        await this._password.FillAsync(password);
        await this._login.ClickAsync();
    }

   
}
