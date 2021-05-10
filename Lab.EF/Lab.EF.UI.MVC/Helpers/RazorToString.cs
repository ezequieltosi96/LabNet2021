using System.IO;
using System.Web.Mvc;

namespace Lab.EF.UI.MVC.Helpers
{
    public class RazorToString
    {
        public static string RenderRazorViewToString(ControllerContext context, string viewPath, object model = null, bool partial = false)
        {
            ViewEngineResult viewEngineResult = null;
            viewEngineResult = partial
                ? ViewEngines.Engines.FindPartialView(context, viewPath)
                : ViewEngines.Engines.FindView(context, viewPath, null);

            if (viewEngineResult == null) throw new FileNotFoundException("View cannot be found.");

            var view = viewEngineResult.View;
            context.Controller.ViewData.Model = model;

            string result = null;

            using (var sw = new StringWriter())
            {
                var ctx = new ViewContext(context, view, context.Controller.ViewData, context.Controller.TempData, sw);
                view.Render(ctx, sw);
                result = sw.ToString();
            }

            return result;
        }
    }
}