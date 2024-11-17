namespace SwoyerOrbiloUniverse.Model
{
    public class Group
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } // Name of the group
        public string Description { get; set; } // Description of the group
        public string Category { get; set; } // Category (e.g., vampire, alien, etc.)
        public string Origin { get; set; } // Origin of the group
        public string ImagePath { get; set; } // Path or URL to the group's image
    }

}
