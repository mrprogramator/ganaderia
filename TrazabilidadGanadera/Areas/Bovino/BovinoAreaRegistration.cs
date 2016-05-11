using System.Web.Mvc;

namespace TrazabilidadGanadera.Areas.Bovino
{
    public class BovinoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Bovino";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Bovino_default",
                "Bovino/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
