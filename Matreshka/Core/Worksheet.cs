using System;
using System.Collections.ObjectModel;
using Matreshka.Views;
using Newtonsoft.Json;

namespace Matreshka.Core
{
    public class Worksheet : AbstractView
    {
        private string name = "Иван";
        private string surname = "Иванов";
        private string middlename = "Иванович";
        private PersonalData personalData = new PersonalData(){EyeColor = EyeColor.Blue, HairColor = HairColor.Black};
        private PersonalData desires = new PersonalData();

        public string Name
        {
            get => name;
            set
            {
                if (value == name) return;
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Surname   
        {
            get => surname;
            set
            {
                if (value == surname) return;
                surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public string Middlename    
        {
            get => middlename;
            set
            {
                if (value == middlename) return;
                middlename = value;
                OnPropertyChanged(nameof(Middlename));
            }
        }

        public string City { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Today;

        public PersonalData PersonalData
        {
            get => personalData;
            set
            {
                if (Equals(value, personalData)) return;
                personalData = value;
                OnPropertyChanged(nameof(PersonalData));
            }
        }

        public PersonalData Desires
        {
            get => desires;
            set
            {
                if (Equals(value, desires)) return;
                desires = value;
                OnPropertyChanged(nameof(Desires));
            }
        }

        [JsonIgnore]
        public ObservableCollection<Worksheet> Candidats { get; set; } = new ObservableCollection<Worksheet>();
    }
}