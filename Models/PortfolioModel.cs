using System.Collections.Generic;

namespace PortfolioWebsite.Models
{
    public class PortfolioModel
    {
        public string Name { get; set; }
        public string Overview { get; set; }
        public string Background { get; set; }
        public string Experience { get; set; }
        public string Goals { get; set; }
        public Dictionary<string, List<string>> TechSkills { get; set; }
    }
}