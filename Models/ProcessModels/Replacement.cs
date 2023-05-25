using System.Xml.Serialization;

namespace WebApplicationTest.Models.ProcessModels
{
    [XmlRoot(ElementName = "replacement")]
    public class Replacement
    {

        [XmlAttribute(AttributeName = "from")]
        public string From { get; set; }

        [XmlAttribute(AttributeName = "to")]
        public string To { get; set; }
    }
}
