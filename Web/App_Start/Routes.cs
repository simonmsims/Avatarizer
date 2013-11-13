namespace Web.App_Start
{
  using System.Web.Mvc;
  using System.Web.Routing;

  internal class Routes
  {
    public void Register(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.MapRoute(
          name: "Default",
          url: "{controller}/{action}/{id}",
          defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
      );
    }
  }
}