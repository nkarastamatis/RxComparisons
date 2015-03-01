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

namespace WpfGridBindingComparison
{
    public class MainWindowViewModel2 : BindableBase
    {
        public ObservableCollection<Location> GridObjects { get; private set; }
        public ObservableCollection<Location> RxGridObjects { get; private set; }

        public DelegateCommand LoadGrid { get; private set; }
        public DelegateCommand LoadRxGrid { get; private set; }

        public MainWindowViewModel2()
        {
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
                    _locations.Add(new Location() { description = reader.ReadLine() });
                }
            }
        }

        private void ExecuteLoadGrid()
        {
            foreach (var location in _locations)
                GridObjects.Add(location);
        }

        private void ExecuteLoadRxGrid()
        {
            throw new NotImplementedException();
        }


        private List<Location> _locations;
    }
}
