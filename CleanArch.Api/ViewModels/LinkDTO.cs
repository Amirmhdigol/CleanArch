namespace CleanArch.Api.ViewModels
{
    public class LinkDTO
    {
        public LinkDTO(string url, string rel, string method)
        {
            Url = url;
            Rel = rel;
            Method = method;
        }
        public string Url { get; private set; }
        public string Rel { get; private set; }
        public string Method { get; private set; }

    }
}
