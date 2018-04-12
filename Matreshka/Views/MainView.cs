using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Matreshka.Commands;
using Matreshka.Core;
using Newtonsoft.Json;

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

        public ObservableCollection<Worksheet> Worksheets { get; set; } = LoadProfiles();

        public ICommand CreateUser { get; }
        public ICommand RemoveUser { get; }
        public ICommand SaveUsers { get; }
        public ICommand SearchCandidats { get; }

        public static readonly Gender[] Genders = {Gender.Male, Gender.Female};
        public static readonly VarBool[] VarBools = {VarBool.None, VarBool.Yes, VarBool.No};

        public MainView()
        {
            CreateUser = new RelayCommand(CreateNewUser);
            RemoveUser = new RelayCommand(RemoveSelectedUser, o => SelectedItem != null);
            SaveUsers = new RelayCommand(SaveUsersToFile);
            SearchCandidats = new RelayCommand(FindCandidats);
        }

        private void CreateNewUser(object context)
        {
            var userWorksheet = new Worksheet();
            Worksheets.Add(userWorksheet);
            SelectedItem = userWorksheet;
        }

        private void RemoveSelectedUser(object context)
        {
            Worksheets.Remove(SelectedItem);
            SelectedItem = null;
        }

        private const string FilePath = "users.json";

        private static ObservableCollection<Worksheet> LoadProfiles()
        {
            if (File.Exists(FilePath))
            {
                var fileContent = File.ReadAllText(FilePath);
                return JsonConvert.DeserializeObject<ObservableCollection<Worksheet>>(fileContent);
            }
            else 
                return new ObservableCollection<Worksheet>{new Worksheet()};
        }

        private void SaveUsersToFile(object context)
        {
            var fileContent = JsonConvert.SerializeObject(Worksheets);
            File.WriteAllText(FilePath, fileContent);
        }

        private void FindCandidats(object context)
        {
            var target = SelectedItem;
            target.Candidats.Clear();

            var candidats =
                Worksheets.Where(candidat => candidat != target && WorksheetComparer.Compare(candidat, target));
            foreach (var candidat in candidats)
            {
                target.Candidats.Add(candidat);
            }
        }
    }
}