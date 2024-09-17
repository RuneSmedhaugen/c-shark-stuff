namespace RollRadar.Models
{
    public class BowlingAlley : BaseModel
    {
        private string _location;

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }


        public BowlingAlley(string location, string name, string? image, string comments) : base(name, image, comments)
        {
            Location = location;
        } 
    }
}
