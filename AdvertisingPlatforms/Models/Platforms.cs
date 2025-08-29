namespace AdvertisingPlatforms.Models
{
    public class Platforms
    {
        public string Name { get; set; } = string.Empty;

        public List<string> Locations { get; set; } = new List<string>();
    }
}
