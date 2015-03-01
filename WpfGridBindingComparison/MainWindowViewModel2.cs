using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Commands;
using System.Collections.ObjectModel;
using System.IO;
using WpfGridBindingComparison.TWS;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
using System.Threading;
using System.Reactive.PlatformServices;

namespace WpfGridBindingComparison
{
    public class MainWindowViewModel2 : BindableBase
    {
        private ObservableCollection<Location> _gridObject; 
        public ObservableCollection<Location> GridObjects { get; private set; }
        public ObservableCollection<Location> RxGridObjects { get; private set; }

        public DelegateCommand LoadGrid { get; private set; }
        public DelegateCommand LoadRxGrid { get; private set; }

        private string _rxProgress;
        public string RxProgress
        {
            get { return _rxProgress; }
            set { base.SetProperty<string>(ref _rxProgress, value); }
        }

        Service _service;

        public MainWindowViewModel2()
        {
            _service = new Service();
            _service.Timeout = 0;


            GridObjects = new ObservableCollection<Location>() { new Location() { description = "10000" } };
            RxGridObjects = new ObservableCollection<Location>();
            _locations = new List<Location>();

            LoadGrid = new DelegateCommand(ExecuteLoadGrid);
            LoadRxGrid = new DelegateCommand(ExecuteLoadRxGrid);

            var filePath = "C:\\Users\\Nicholas\\logs\\copyAllToBackup020120151410.txt";
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    _locations.Add(new Location() 
                    {
                        locationIdentity = new LocationIdentity(),
                        description = reader.ReadLine(),
                        accountType = "ACCOUNTTYPE1",
                        activeAlertRecipients = new List<ActiveAlertRecipient>().ToArray(),
                        address = new Address(),
                        deliveryDays = "MT",
                        deliveryRadius = .10,
                        locquality = GeocodeResult.grAuto,
                        lastOrderDate = DateTime.Now,
                        alternateContact = "44353885",
                        buildingDeliverySequence = 2,
                        employees = new List<EmployeeIdentity>().ToArray(),
                        faxNumber = "3345678",
                        geocodeVerified = false,
                        locConfidence = GeocodeConfidence.gcLow,
                        longitude = -123456,
                        latitude = 4356432,
                        markAsVoid = false,
                        bulkThreashold = new Quantities(),
                        acceptsMFRPalletType = false,
                        dateAdded = DateTime.Now,
                        fixedFee = 25.0,
                        serviceTimeOverrides = new List<ServiceTimeOverride>().ToArray()
                    });
                }
            }

            _locations.AddRange(_locations);
            _locations.AddRange(_locations);
            _locations.AddRange(_locations);
            _locations.AddRange(_locations);
        }

        private void ExecuteLoadGrid()
        {
            GridObjects.Clear();
            foreach (var location in _locations)
                GridObjects.Add(location);
        }

        private void ExecuteLoadRxGrid()
        {
            RxGridObjects.Clear();
            _locations.ToObservable()
                .Buffer(TimeSpan.FromMilliseconds(1000), 5000)
                .ObserveOnDispatcher(System.Windows.Threading.DispatcherPriority.Background)//(SynchronizationContext.Current)
                .Subscribe(loadedData =>
                {
                    foreach (var location in loadedData)
                        RxGridObjects.Add(location);

                    RxProgress = string.Format("Loaded {0} rows", RxGridObjects.Count);
                },
                exception => { RxProgress = exception.Message; },
                () => { RxProgress = string.Format("Finished loading {0} rows", RxGridObjects.Count); });
        }

        private List<Location> _locations;

        public class Service : TransportationWebService
        {
            public System.Net.WebRequest GetRequest(Uri uri)
            {
                return base.GetWebRequest(uri);
            }
        }
    }
}
