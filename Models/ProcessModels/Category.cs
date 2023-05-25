using System.Xml.Serialization;

namespace WebApplicationTest.Models.ProcessModels
{
    [XmlRoot(ElementName = "category")]
    public class Category
    {
        [XmlElement(ElementName = "remove")]
        public List<Remove>? Remove { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string? Name { get; set; }

        [XmlAttribute(AttributeName = "primary")]
        public string? Primary { get; set; }

        [XmlElement(ElementName = "ranking")]
        public List<Ranking>? Ranking { get; set; }

        [XmlElement(ElementName = "pull")]
        public List<Pull>? Pull { get; set; }

        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }

        [XmlAttribute(AttributeName = "debug")]
        public string? Debug { get; set; }

        [XmlAttribute(AttributeName = "authority")]
        public string? Authority { get; set; }

        [XmlElement(ElementName = "category")]
        public List<Category> Categorie { get; set; }

        [XmlAttribute(AttributeName = "merge")]
        public string? Merge { get; set; }

        [XmlAttribute(AttributeName = "titleX")]
        public string? TitleX { get; set; }
    }
}
