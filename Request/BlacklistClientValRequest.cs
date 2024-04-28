using System.Runtime.Serialization;

namespace MySoapService.Request;

[DataContract(Namespace = "http://beans.ddmws.services.emerio.com/xsd")]
public class BlacklistClientValRequest
{
    [DataMember(Order = 1, Name = "name")]
    public string Name { get; set; } = null!;

    [DataMember(Order = 2, Name = "passport", IsRequired = false)]
    public string Passport { get; set; } = null!;

    [DataMember(Order = 3, Name = "businessTag", IsRequired = false)]
    public string BusinessTag { get; set; } = null!;

    [DataMember(Order = 4, Name = "nric")]
    public string NRIC { get; set; } = null!;

    [DataMember(Order = 5, Name = "trxId")]
    public string TrxId { get; set; } = null!;
}
