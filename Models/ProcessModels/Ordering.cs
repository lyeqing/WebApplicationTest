using System.Xml.Serialization;

namespace WebApplicationTest.Models.ProcessModels
{
    [XmlRoot(ElementName = "ordering")]
    public class Ordering
    {

        [XmlElement(ElementName = "categories")]
        public Categories Categories { get; set; }

        [XmlElement(ElementName = "category")]
        public Category Category { get; set; }

        [XmlElement(ElementName = "meta_descriptions")]
        public MetaDescriptions MetaDescriptions { get; set; }
    }
}
