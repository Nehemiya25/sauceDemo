﻿using Microsoft.Playwright;
using System.Threading.Tasks;
using userManagementDemo.Base;

namespace userManagementDemo.Components;

public class Password : BaseLocator
{
    public Password(IPage page, string locator, AnnotationHelper annotationHelper) : base(page, locator, annotationHelper)
    {

    }

    /// <summary>
    /// Set input value like paste
    /// </summary>
    /// <param name="value">Value to fill</param>
    /// <returns></returns>
    public async Task FillAsync(string value)
    {
        this.AnnotationHelper.AddAnnotation(AnnotationType.Step, "Fill the password: *****"  );
        await this.Locator.FillAsync(value);
    }
}
