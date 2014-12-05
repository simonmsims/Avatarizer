namespace Avatarizer.Example
{
  using System.Web.Optimization;
  
  public class Bundles
  {
    public const string Css = "~/bundles/base.css";

    internal void Register(BundleCollection bundles)
    {
      bundles.Add(this.GetCssBundle());
    }

    private Bundle GetCssBundle()
    {
      return new StyleBundle(Css).Include("~/Css/base.css").Include("~/Css/layout.css");
    }
  }
}