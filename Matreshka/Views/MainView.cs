using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
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
        private string filterText;

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
        public ObservableCollection<Worksheet> FilteredWorksheets { get; set; }

        public ICommand CreateUser { get; }
        public ICommand RemoveUser { get; }
        public ICommand SaveUsers { get; }
        public ICommand SearchCandidats { get; }

        public string FilterText
        { 
            get => filterText;
            set
            {
                if (filterText == value)
                    return;
                filterText = value;
                ApplyFilter(value);
            }
        }

        private void ApplyFilter(string value)
        {
            value = value.Trim();
            if (string.IsNullOrEmpty(value))
            {
                FilteredWorksheets.Clear();
                foreach (var worksheet in Worksheets)
                {
                    FilteredWorksheets.Add(worksheet);
                }
            }
            else
            {
                FilteredWorksheets.Clear();
                var parts = value.Split(' ');
                foreach (var worksheet in Worksheets)
                {
                    if (parts.Any(part => worksheet.Surname.StartsWith(part) || worksheet.Name.StartsWith(part)))
                    {
                        FilteredWorksheets.Add(worksheet);
                    }
                }
            }
        }

        public static readonly Gender[] Genders = {Gender.Male, Gender.Female};
        public static readonly VarBool[] VarBools = {VarBool.None, VarBool.Yes, VarBool.No};

        public static readonly Nationality[] Nationalities =
            {Nationality.Slav, Nationality.Belarus, Nationality.Ukranian, Nationality.Aremnian, Nationality.Grousian};
        public static readonly EyeColor[] EyeColors =
            {EyeColor.Black, EyeColor.Blue, EyeColor.Brown, EyeColor.Green, EyeColor.Grey, EyeColor.Other};

        public static readonly HairColor[] HairColors =
            { HairColor.Black, HairColor.Blond, HairColor.Grey, HairColor.Red, HairColor.Other};

        public static readonly Growth[] Growths = {Growth.Little, Growth.Small, Growth.High, Growth.Other };

        public MainView()
        {
            FilteredWorksheets = new ObservableCollection<Worksheet>(Worksheets);
            Worksheets.CollectionChanged += UpdateDisplayedObjects;
            
            CreateUser = new RelayCommand(CreateNewUser);
            RemoveUser = new RelayCommand(RemoveSelectedUser, o => SelectedItem != null);
            SaveUsers = new RelayCommand(SaveUsersToFile);
            SearchCandidats = new RelayCommand(FindCandidats);
        }

        private void UpdateDisplayedObjects(object sender, NotifyCollectionChangedEventArgs e)
        {
            ApplyFilter("");
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
                try
                {
                    return JsonConvert.DeserializeObject<ObservableCollection<Worksheet>>(fileContent);
                }
                catch (Exception e)
                {
                    return new ObservableCollection<Worksheet> { new Worksheet() };
                }
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