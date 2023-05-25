using System.Xml.Serialization;

namespace WebApplicationTest.Models.ProcessModels
{
    [XmlRoot(ElementName = "meta_descriptions")]
    public class MetaDescriptions
    {
        [XmlElement(ElementName = "replacement")]
        public List<Replacement> Replacement { get; set; }
    }
}
