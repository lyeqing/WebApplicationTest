using System.Xml.Serialization;

namespace WebApplicationTest.Models.ProcessModels
{
    [XmlRoot(ElementName = "except")]
    public class Except
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }
}
