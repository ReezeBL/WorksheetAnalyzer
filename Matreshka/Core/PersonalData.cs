using Matreshka.Views;

namespace Matreshka.Core
{
    public class PersonalData : AbstractView
    {
        private EyeColor eyeColor = EyeColor.Other;
        private HairColor hairColor = HairColor.Other;
        private Nationality nationality;
        private VarBool badHabbits = VarBool.None;
        private VarBool loveChildren = VarBool.None;
        private VarBool humor = VarBool.None;
        private VarBool kindness = VarBool.None;
        private Growth growth = Growth.Other;
        private int? weight;
        private VarBool cookery = VarBool.None;
        private VarBool jealousy = VarBool.None;
        private VarBool haveCar = VarBool.None;
        private VarBool fixedIncome = VarBool.None;
        private VarBool romance = VarBool.None;

        public EyeColor EyeColor  
        {
            get => eyeColor;
            set
            {
                if (value == eyeColor) return;
                eyeColor = value;
                OnPropertyChanged(nameof(EyeColor));
            }
        }

        public HairColor HairColor
        {
            get => hairColor;
            set
            {
                if (value == hairColor) return;
                hairColor = value;
                OnPropertyChanged(nameof(HairColor));
            }
        }

        public Nationality Nationality
        {
            get => nationality;
            set
            {
                if (value == nationality) return;
                nationality = value;
                OnPropertyChanged(nameof(Nationality));
            }
        }

        public VarBool BadHabbits   
        {
            get => badHabbits;
            set
            {
                if (value == badHabbits) return;
                badHabbits = value;
                OnPropertyChanged(nameof(BadHabbits));
            }
        }

        public VarBool LoveChildren
        {
            get => loveChildren;
            set
            {
                if (value == loveChildren) return;
                loveChildren = value;
                OnPropertyChanged(nameof(LoveChildren));
            }
        }

        public VarBool Humor
        {
            get => humor;
            set
            {
                if (value == humor) return;
                humor = value;
                OnPropertyChanged(nameof(Humor));
            }
        }

        public VarBool Kindness
        {
            get => kindness;
            set
            {
                if (value == kindness) return;
                kindness = value;
                OnPropertyChanged(nameof(Kindness));
            }
        }

        public Growth Growth
        {
            get => growth;
            set
            {
                if (value == growth) return;
                growth = value;
                OnPropertyChanged(nameof(Growth));
            }
        }

        public int? Weight  
        {
            get => weight;
            set
            {
                if (value == weight) return;
                weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }

        public VarBool Cookery
        {
            get => cookery;
            set
            {
                if (value == cookery) return;
                cookery = value;
                OnPropertyChanged(nameof(Cookery));
            }
        }

        public VarBool Jealousy
        {
            get => jealousy;
            set
            {
                if (value == jealousy) return;
                jealousy = value;
                OnPropertyChanged(nameof(Jealousy));
            }
        }

        public VarBool HaveCar
        {
            get => haveCar;
            set
            {
                if (value == haveCar) return;
                haveCar = value;
                OnPropertyChanged(nameof(HaveCar));
            }
        }

        public VarBool FixedIncome
        {
            get => fixedIncome;
            set
            {
                if (value == fixedIncome) return;
                fixedIncome = value;
                OnPropertyChanged(nameof(FixedIncome));
            }
        }

        public VarBool Romance
        {
            get => romance;
            set
            {
                if (value == romance) return;
                romance = value;
                OnPropertyChanged(nameof(Romance));
            }
        }
    }
}