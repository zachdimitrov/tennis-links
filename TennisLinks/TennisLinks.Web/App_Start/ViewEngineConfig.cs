using System.Web.Mvc;

namespace TennisLinks.Web.App_Start
{
    public class ViewEngineConfig
    {
        internal static void RemoveUnusedViewEngines()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}