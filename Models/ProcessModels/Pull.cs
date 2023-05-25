using System.Xml.Serialization;

namespace WebApplicationTest.Models.ProcessModels
{
    [XmlRoot(ElementName = "pull")]
    public class Pull
    {

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        //[XmlAttribute(AttributeName = "id")]
        //public int? Id { get; set; }

        [XmlElement(ElementName = "except")]
        public Except? Except { get; set; }
    }
}
