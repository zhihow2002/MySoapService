using System.ServiceModel;
using MySoapService.Request;
using MySoapService.Response;

namespace MySoapService.ServiceModel.Interfaces;

[ServiceContract(Namespace = "http://ddmws.services.emerio.com")]
public interface IBlacklistService
{
    [OperationContract]
    BlacklistClientValResponse BlacklistClientValidate(BlacklistClientValRequest request);
}
