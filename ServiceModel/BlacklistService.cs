using MySoapService.Request;
using MySoapService.Response;
using MySoapService.ServiceModel.Interfaces;

namespace MySoapService.ServiceModel
{
    public class BlacklistService : IBlacklistService
    {
        public BlacklistClientValResponse BlacklistClientValidate(BlacklistClientValRequest request)
        {
            return new BlacklistClientValResponse()
            {
                Return = new Return()
                {
                    Indicator = "Y",
                    ReasonCode = "00",
                    ResponseCode = "00",
                    ResponseDesc = "Success",
                    TrxId = request.TrxId
                }
            };
        }
    }
}
