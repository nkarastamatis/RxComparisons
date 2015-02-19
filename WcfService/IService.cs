using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IServiceCallback))]
    public interface IService
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<int> GetEnumerableOfInt();

        [OperationContract]
        IQueryable<int> GetQueryableOfInt();

        [OperationContract]
        void GetCallbackOfInt();

        [OperationContract]
        void Connect();

        [OperationContract]
        long GetValue(long key);

        [OperationContract]
        void SaveValue(long key, long value);
        // TODO: Add your service operations here
    }

    public interface IServiceCallback 
    {
        [OperationContract]
        void OnCallback();

        [OperationContract]
        void SendInt(long i);

        [OperationContract]
        void ChangedRecord(long key, long value);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

}
