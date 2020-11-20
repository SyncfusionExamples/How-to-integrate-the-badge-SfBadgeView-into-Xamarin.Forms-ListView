using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace BadgeSample.ViewModel
{
    public class ViewModel
    {
        public ObservableCollection<ModelList> Items { get; set; }

        public ViewModel()
        {
            var modellList1 = new ModelList()
            {
                new Model(){Category = "Primary", Count = 27, Color = Color.FromHex("#e3165b")},
                new Model(){Category = "Social", Count = 12, Color = Color.FromHex("#3f51b5")},
                new Model(){Category = "Promotions", Count = 7, Color = Color.FromHex("#4d841d")},
                new Model(){Category = "Updates", Count = 1, Color = Color.FromHex("#2088da")},
            };
            modellList1.Heading = "Inbox";

            var modellList2 = new ModelList()
            {
                new Model(){Category = "Starred", Count = 0, Color = Color.Brown},
                new Model(){Category = "Important", Count = 12, Color = Color.Brown},
                new Model(){Category = "Sent", Count = 0, Color = Color.FromHex("#e3165b")},
                new Model(){Category = "Drafts", Count = 0, Color = Color.FromHex("#e3165b")},
            };
            modellList2.Heading = "All Labels";

            Items = new ObservableCollection<ModelList>()
            {
                modellList1,
                modellList2
            };
        }
    }

    public class ModelList:ObservableCollection<Model>
    {
        public ObservableCollection<Model> Models => this;
        public string Heading { get; set; }
    }

    public class ZeroValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(!value.ToString().Equals("0"))
            {
                return value.ToString() + " New";
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
