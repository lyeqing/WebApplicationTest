using System.Xml.Serialization;

namespace WebApplicationTest.Models.ProcessModels
{
    [XmlRoot(ElementName = "ranking")]
    public class Ranking
    {
        [XmlAttribute(AttributeName = "match")]
        public string Match { get; set; }
        [XmlAttribute(AttributeName = "rank")]
        public int Rank { get; set; }
    }
}
