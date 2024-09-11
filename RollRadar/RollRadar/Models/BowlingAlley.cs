namespace RollRadar.Models
{
    public class BowlingAlley : Inherit
    {
        private string Location;

        public string location
        {
            get { return Location; }
            set { Location = value; }
        }


        public BowlingAlley(string location, string name, string image, string comments) : base(name, image, comments)
        {
            this.location = location;
        } 
    }
}
