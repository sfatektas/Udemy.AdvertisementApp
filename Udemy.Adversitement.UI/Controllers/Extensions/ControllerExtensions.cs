using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udemy.Adversitement.Common;
using Udemy.Adversitement.Common.Interfaces;

namespace Udemy.Adversitement.UI.Controllers.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult ResponseRedirectAction<T>(this Controller controller,
            IResponse<T> response, string actionName) where T : class, new()
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }
            if (response.ResponseType == ResponseType.ValidationError)
            {
                return controller.View(response.Data);
            }
            return controller.RedirectToAction(actionName);
        }
        public static IActionResult ResponseView<T>(this Controller controller, IResponse<T> response) where T : class, new()
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }
            return controller.View(response.Data);
        }
        public static IActionResult ResponseRedirectAction(this Controller controller,
          IResponse response, string actionName)
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }
            else
                return controller.RedirectToAction(actionName);
        }
    }
}
