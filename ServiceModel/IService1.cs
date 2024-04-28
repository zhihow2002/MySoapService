using System.ServiceModel;

[ServiceContract]
public interface IService1
{
    [OperationContract]
    string ProcessData(string input);
}