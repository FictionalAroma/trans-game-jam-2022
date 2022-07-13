
namespace DataLib.GameDataModels
{
    
    public interface ICharacter
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        /// <summary>
        /// Used for He/She/They
        /// </summary>
        public string Pronoun1 { get; set; }

        /// <summary>
        /// Used for Him/Her/They
        /// </summary>
        public string Pronoun2 { get; set; }

        public string CharacterFullDescription { get; set; }
        public string CharacterHeadline { get; set; }
    }
}
