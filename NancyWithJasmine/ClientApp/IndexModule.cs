namespace ClientApp
{
  using Nancy;

  public class IndexModule : NancyModule
  {
    public IndexModule()
    {
        Get["/"] = o => View["index"];
    }
  }
}