using System.Threading.Tasks;
using Microsoft.Playwright;
using userManagementDemo.Base;
using userManagementDemo.Components;

namespace userManagementDemo.Pages;

public class EditUserPage : BasePage
{
    private Button _editUser;
    private InputText _firstName;
    private Button _close;
    private ILocator _alertSaved;

    public EditUserPage(IPage page) : base(page)
    {
       _editUser = new Button(page,"//a[text()='Edit']", this.annotationHelper);
       _firstName = new InputText(page, "#firstName", this.annotationHelper);
       _close = new Button(page, "//span[text()=' Close ']", this.annotationHelper);
       _alertSaved = page.Locator("//ngb-alert[text()=' Saved ']");
    }

    public async Task<bool> HasSaved() =>  await _alertSaved.IsVisibleAsync();

    public async Task editUser(string firstName)
    {
        await this._editUser.ClickAsync();
        await Task.Delay(10000);
        await this._firstName.FillAsync(firstName);
        await Task.Delay(5000);
        await this._close.ClickAsync();
        await Task.Delay(2000);
    }
}
