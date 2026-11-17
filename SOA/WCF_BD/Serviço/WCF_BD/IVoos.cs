using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFBD
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IVoos" in both code and config file together.
    [ServiceContract]
    public interface IVoos
    {
        [OperationContract]
        DataSet GetAllFlights();
    }
}
