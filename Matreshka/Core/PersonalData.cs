namespace Matreshka.Core
{
    public class PersonalData
    {
        public string EyeColor { get; set; }
        public string HairColor { get; set; }
        public string Nationality { get; set; }
        public VarBool BadHabbits { get; set; } = VarBool.None;
        public VarBool LoveChildren { get; set; } = VarBool.None;
        public VarBool Humor { get; set; } = VarBool.None;
        public VarBool Kindness { get; set; } = VarBool.None;
        public int? Growth { get; set; }
        public int? Weight { get; set; }
        public VarBool Cookery { get; set; } = VarBool.None;
        public VarBool Jealousy { get; set; } = VarBool.None;
        public VarBool HaveCar { get; set; } = VarBool.None;
        public VarBool FixedIncome { get; set; } = VarBool.None;
        public VarBool Romance { get; set; } = VarBool.None;
    }
}