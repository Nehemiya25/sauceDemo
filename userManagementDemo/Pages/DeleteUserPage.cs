using System.Threading.Tasks;
using Microsoft.Playwright;
using userManagementDemo.Base;
using userManagementDemo.Components;

namespace userManagementDemo.Pages;

public class DeleteUserPage : BasePage
{
    private Button _editUser;
    private Button _deleteUser;
    private Button _popupDeleteUser;
    private Button _close;

    public DeleteUserPage(IPage page) : base(page)
    {
        _editUser = new Button(page,"//a[text()='Edit']", this.annotationHelper);
        _deleteUser = new Button(page, "//button[text()=' Delete ']", this.annotationHelper);
        _popupDeleteUser = new Button(page, "(//button[text()=' Delete '])[2]", this.annotationHelper);
        _close = new Button(page, "//span[text()=' Close ']", this.annotationHelper);
    }

    public async Task deleteUser()
    {
        await this._editUser.ClickAsync();
        await Task.Delay(10000);
        await this._deleteUser.ClickAsync();
        await Task.Delay(10000);
        await this._popupDeleteUser.ClickAsync();
        await Task.Delay(2000);
        await  this._close.ClickAsync();
        await Task.Delay(2000);
    }
}
