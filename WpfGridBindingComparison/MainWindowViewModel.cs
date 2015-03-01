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
    public class MainWindowViewModel : BindableBase
    {
        public ObservableCollection<LogLine> GridObjects { get; private set; }
        public ObservableCollection<LogLine> RxGridObjects { get; private set; }

        public DelegateCommand LoadGrid { get; private set; }
        public DelegateCommand LoadRxGrid { get; private set; }

        public MainWindowViewModel()
        {
            GridObjects = new ObservableCollection<LogLine>() { new LogLine() { Line = "10000" } };
            RxGridObjects = new ObservableCollection<LogLine>();
            _lines = new List<LogLine>();

            LoadGrid = new DelegateCommand(ExecuteLoadGrid);
            LoadRxGrid = new DelegateCommand(ExecuteLoadRxGrid);

            var filePath = "C:\\Users\\Nicholas\\logs\\copyAllToBackup020120151410.txt";
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    _lines.Add(new LogLine() { Line = reader.ReadLine() });
                }
            }
        }

        private void ExecuteLoadGrid()
        {
            foreach (var line in _lines)
                GridObjects.Add(line);
        }

        private void ExecuteLoadRxGrid()
        {
            throw new NotImplementedException();
        }


        private List<LogLine> _lines;
    }

    public class LogLine
    {
        public string Line { get; set; }
    }
}
