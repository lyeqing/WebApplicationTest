using System.Xml.Serialization;

namespace WebApplicationTest.Models.ProcessModels
{
    [XmlRoot(ElementName = "remove")]
    public class Remove
    {

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        //[XmlAttribute(AttributeName = "id")]
        //public int? Id { get; set; }
    }
}
