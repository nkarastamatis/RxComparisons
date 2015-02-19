using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleServiceClient.Service;
using System.Reactive;
using System.Reactive.Threading.Tasks;
using System.Reactive.Linq;
using System.ServiceModel;
using System.Reactive.Subjects;
using System.Reactive.Disposables;


namespace ConsoleServiceClient
{
    class Program
    {
        static Dictionary<long, long> localValuesByKey = new Dictionary<long, long>();

        static void Main(string[] args)
        {

            var callback = new ServiceCallback();
            callback.Integers
                .Subscribe(i => Console.WriteLine("Subscription {0}", i));

            var instanceContext = new InstanceContext(callback);
            var proxy = new Service.ServiceClient(instanceContext);
            proxy.Connect();
            //var a = proxy.GetQueryableOfIntAsync();
            //a.ToObservable()
            //    .Subscribe(intarray => 
            //    {
            //        intarray.ToList().ForEach(i => Console.Write("{0} ", i)); 
            //    });

            //proxy.GetCallbackOfIntAsync();            

            var readLoop = Observable.Create(
                (IObserver<string> observer) => 
                    {
                        string line = null;
                        while (line != "q")
                        {
                            line = Console.ReadLine();
                            observer.OnNext(line);
                        }
                        return Disposable.Create(() => Console.WriteLine("Observer has unsubscribed"));
                    });

            readLoop.Subscribe(
                line =>
                {
                    var strings = line.Split(new[] { ' ', ',' });
                    if (strings.Length == 1)
                    {
                        var value = proxy.GetValue(Int64.Parse(strings[0]));
                        Console.WriteLine("Value is {0}", value);
                    }
                    else if (strings.Length == 2)
                    {
                        long key = Int64.Parse(strings[0]);
                        long value = Int64.Parse( strings[1]);
                        if (localValuesByKey.ContainsKey(key))
                            localValuesByKey[key] = value;
                        else
                            localValuesByKey.Add(key, value);         
                        proxy.SaveValue(key, value);
                        Console.WriteLine("Value saved.");
                    }
                    else
                    {
                        Console.WriteLine(strings.ToString());
                    }

                });

            Console.WriteLine("Hit q to quit.");
            Console.ReadLine();
        }

        public class ServiceCallback : Service.IServiceCallback
        {
            private ISubject<long> _integers = new Subject<long>();

            public IObservable<long> Integers
            {
                get { return _integers.AsObservable(); }
            }

            public void OnCallback()
            {
                Console.WriteLine("> Received callback at {0}", DateTime.Now);
            }

            public void SendInt(long i)
            {
                _integers.OnNext(i);
            }

            public void ChangedRecord(long key, long value)
            {
                if (localValuesByKey.ContainsKey(key))
                {
                    if (localValuesByKey[key] != value)
                    {
                        localValuesByKey[key] = value;
                        Console.WriteLine("Local value changed by another user Key = {0}, Value = {1}.", key, value);
                    }
                }
            }
        }
    }
}
