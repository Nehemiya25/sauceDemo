using System.Threading.Tasks;
using Microsoft.Playwright;
using userManagementDemo.Base;
using userManagementDemo.Components;

namespace userManagementDemo.Pages;

public class AddUserPage : BasePage
{
    private InputText _userName;
    private Password _password;
    private Password _confirmPassword;
    private Button _addTeamMember;
    private SelectCombo _assignedRole;
    private InputText _firstName;
    private InputText _lastName;
    private InputText _email;
    private Button _saveClose;
    private InputText _searchTeamMember;
    private ILocator _searchUserName;

    public AddUserPage(IPage page) : base(page)
    {
        _addTeamMember = new Button(page,"//a[@title='Add Team Member']/em", this.annotationHelper);
        _assignedRole = new SelectCombo(page,"#memberRoleSelection", this.annotationHelper);
        _firstName = new InputText(page,"#firstName", this.annotationHelper);
        _lastName = new InputText(page,"#lastName", this.annotationHelper);
        _email = new InputText(page,"#email", this.annotationHelper);
        _userName = new InputText(page,"#username", this.annotationHelper);
        _password = new Password(page, "#password", this.annotationHelper);
        _confirmPassword = new Password(page, "#confirmPassword", this.annotationHelper);
        _saveClose = new Button(page, "//span[text()=' Save and Close ']", this.annotationHelper);
        _searchTeamMember = new InputText(page, "//input[@placeholder='Search team members']", this.annotationHelper);
        _searchUserName = page.Locator("//tbody/tr[1]/td[contains(text(),'AtluriTest12345')]");
    }

    public async Task<bool> HasUserVisible() =>  await this._searchUserName.IsVisibleAsync();

    public async Task SaveTeamTembersAsync(string assignRole, string firstName, string lastName, string email, string user, string password, string confirmPassword)
    {
        await this._addTeamMember.ClickAsync();
        await Task.Delay(15000);
        await this._assignedRole.SelectOptionAsync(assignRole);
        await this._firstName.FillAsync(firstName);
        await this._lastName.FillAsync(lastName);
        await this._email.FillAsync(email);
        await this._userName.FillAsync(user);
        await this._password.FillAsync(password);
        await this._confirmPassword.FillAsync(confirmPassword);
        await this._saveClose.ClickAsync();
        await Task.Delay(20000);
    }

    public async Task searchUser(string firstName)
    {
        await this._searchTeamMember.FillAsync(firstName);
        await Task.Delay(5000);
        await this._searchUserName.IsVisibleAsync();
        await Task.Delay(5000);
        
    }
}
