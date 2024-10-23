using System.Threading.Tasks;
using Microsoft.Playwright;
using userManagementDemo.Base;
using userManagementDemo.Components;

namespace userManagementDemo.Pages;

public class HomePage : BasePage
{
    private Button _setUp;

    private Button _manageTeamMembers;
    
    public HomePage(IPage page) : base(page)
    {
        _setUp = new Button(page, "//li[@role='tablist']/a[text()='Setup']", this.annotationHelper);

        _manageTeamMembers = new Button(page, "//h3[text()='Manage Team Members']/parent::div/descendant::a[text()=' Manage ']", this.annotationHelper);
        
    }

    /// <summary>
    /// Navigate to team members
    /// </summary>
    /// <returns></returns>
    public async Task TeamMembersAsync()
    {
        await this._setUp.ClickAsync();
        //await this._manageTeamMembers.IsVisibleAsync();
        await this._manageTeamMembers.ClickAsync();
    }

   
}
