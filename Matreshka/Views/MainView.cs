using System.Collections.ObjectModel;
using Matreshka.Core;

namespace Matreshka.Views
{
    public class MainView : AbstractView
    {
        private Worksheet selectedItem;

        public Worksheet SelectedItem   
        {
            get => selectedItem;
            set
            {
                if (Equals(value, selectedItem)) return;
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ObservableCollection<Worksheet> Worksheets { get; set; } = new ObservableCollection<Worksheet>
        {
            new Worksheet {Name="Poop", Surname = "Megapoop"}
        };
    }
}