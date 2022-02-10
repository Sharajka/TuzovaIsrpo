using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba9B
{
    internal class ParkModel : IDataErrorInfo
    {
        public static MainWindow Owner { get; set; }


        public int CountAutomobile { get; set; }

        private string _error;
        public string Error => _error;


        public string this[string columnName]
        {
            get
            {
                _error = string.Empty;

                switch (columnName)
                {
                    case nameof(CountAutomobile):
                        if (CountAutomobile >= 2 && CountAutomobile <= 60)
                        {
                            Owner.ConfirmButton.IsEnabled = true;
                            break;
                        }

                        _error = "Введите значение от 2 до 60";
                        Owner.ConfirmButton.IsEnabled = false;
                        break;
                }

                return Error;
            }
        }

        
    }
}
