namespace DistributedSystems
{
    public class Link
    {
        public long Id { get; set; }
        public string Url { get; set; }
        //public string Status { get; set; } = "Not Changed";

        public Link(string url)
        {
            Url = url;
        }
    }
}
