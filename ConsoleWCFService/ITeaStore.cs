using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWCFService
{
    [ServiceContract(Namespace = "http://wakeupbuytea.com")]
    public interface ITeaStore
    {
        [OperationContract]
        string GetTeaInfo(string teaName);

        [OperationContract]
        string GetTeaNames();

        [OperationContract]
        List<Tea> GetAllTeas();
    }
}
