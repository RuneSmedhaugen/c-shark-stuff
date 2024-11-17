namespace SwoyerOrbiloUniverse.Model
{
    public class Human
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } // Name of the human
        public string Role { get; set; } // Role within the organization
        public string Personality { get; set; } // Personality description
        public string FunFact { get; set; } // Fun fact about the human
        public DateTime? DateOfBirth { get; set; } // Date of birth
        public DateTime? DateOfDeath { get; set; } // Date of death (if applicable)
        public string ImagePath { get; set; } // Path or URL to the human's image
    }

}
