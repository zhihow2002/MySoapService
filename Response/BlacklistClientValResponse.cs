using System.Xml.Serialization;

namespace MySoapService.Response
{
    [XmlRoot(
        ElementName = "blacklist_client_valResponse",
        Namespace = "http://ddmws.services.emerio.com"
    )]
    public class BlacklistClientValResponse
    {
        [XmlElement(ElementName = "return", Namespace = "http://ddmws.services.emerio.com")]
        public Return Return { get; set; } = null!;
    }

    public class Return
    {
        [XmlElement(
            ElementName = "indicator",
            Namespace = "http://beans.ddmws.services.emerio.com/xsd"
        )]
        public string Indicator { get; set; } = null!;

        [XmlElement(
            ElementName = "reasonCode",
            Namespace = "http://beans.ddmws.services.emerio.com/xsd"
        )]
        public string ReasonCode { get; set; } = null!;

        [XmlElement(
            ElementName = "responseCode",
            Namespace = "http://beans.ddmws.services.emerio.com/xsd"
        )]
        public string ResponseCode { get; set; } = null!;

        [XmlElement(
            ElementName = "responseDesc",
            Namespace = "http://beans.ddmws.services.emerio.com/xsd"
        )]
        public string ResponseDesc { get; set; } = null!;

        [XmlElement(
            ElementName = "trxId",
            Namespace = "http://beans.ddmws.services.emerio.com/xsd"
        )]
        public string TrxId { get; set; } = null!;
    }
}
