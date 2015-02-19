using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Reactive.Linq;
using System.Reactive.Threading;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service : IService
    {        
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public IEnumerable<int> GetEnumerableOfInt()
        {
            return Enumerable.Range(1, 100);
        }

        public IQueryable<int> GetQueryableOfInt()
        {
            System.Threading.Tasks.Task.Delay(10000).Wait();
            return Enumerable.Range(1, 100).AsQueryable();
        }

        public void GetCallbackOfInt()
        {
            Callback = OperationContext.Current.GetCallbackChannel<IServiceCallback>();
            Observable.Interval(TimeSpan.FromSeconds(1))
                .Subscribe(
                i =>
                {
                    try
                    {
                        Callback.SendInt(i);
                    }
                    catch { }
                },
                ex => Console.WriteLine("Error in interval"));
        }

        public long GetValue(long key)
        {
            long value = -1;

            valuesByKey.TryGetValue(key, out value);

            return value;
        }

        public void Connect()
        {
            Callbacks.Add(OperationContext.Current.GetCallbackChannel<IServiceCallback>());
        }

        public void SaveValue(long key, long value)
        {
            if (valuesByKey.ContainsKey(key))
            {
                if (valuesByKey[key] != value)
                {
                    valuesByKey[key] = value;
                    try
                    {
                        Callbacks.ForEach(callback => callback.ChangedRecord(key, value));
                    }
                    catch { }
                }
            }
            else
            {
                valuesByKey.Add(key, value);
            }
        }

        static Dictionary<long, long> valuesByKey = new Dictionary<long, long>();

        public static IServiceCallback Callback;
        public static List<IServiceCallback> Callbacks = new List<IServiceCallback>();
    }
}
