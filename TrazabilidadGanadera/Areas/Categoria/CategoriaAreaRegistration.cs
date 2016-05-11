using System.Web.Mvc;

namespace TrazabilidadGanadera.Areas.Categoria
{
    public class CategoriaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Categoria";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Categoria_default",
                "Categoria/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
