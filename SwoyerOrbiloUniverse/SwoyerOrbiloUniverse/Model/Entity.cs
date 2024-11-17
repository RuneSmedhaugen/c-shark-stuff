namespace SwoyerOrbiloUniverse.Model
{
    public class Entity
    {
        public int Id { get; set; } // Primary Key
        public int Number { get; set; } // Unique number for the entity
        public string Name { get; set; } // Name of the entity
        public string Ability { get; set; } // Entity's ability
        public string Risk { get; set; } // Risk level of the entity
        public string Origin { get; set; } // Entity's origin
        public string Category { get; set; } // Category of the entity
        public string Goal { get; set; } // Entity's goal
        public DateTime? DateOfDiscovery { get; set; } // Date the entity was discovered
        public DateTime? DateOfDeathOrContainment { get; set; } // Date the entity was contained or died
        public string FunFact { get; set; } // Fun fact about the entity
        public string ImagePath { get; set; } // Path or URL to the entity's image
    }

}
