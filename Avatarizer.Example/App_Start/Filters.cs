namespace Avatarizer.Example
{
  using System.Web.Mvc;

  internal class Filters
  {
    public void Register(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
    }
  }
}