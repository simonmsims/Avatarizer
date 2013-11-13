namespace Web.App_Start
{
  using System.Web.Optimization;
  
  public class Bundles
  {
    public const string Css = "~/bundles/site.css";

    internal void Register(BundleCollection bundles)
    {
      bundles.Add(this.GetCssBundle());
    }

    private Bundle GetCssBundle()
    {
      return new StyleBundle(Css).Include("~/Css/*.css");
    }
  }
}