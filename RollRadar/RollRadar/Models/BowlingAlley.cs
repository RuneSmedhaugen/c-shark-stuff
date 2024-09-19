namespace RollRadar.Models
{
    public class BowlingAlley : BaseModel
    {
        private string _location;
        private int _userId;

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }


        public BowlingAlley(string location, string name, string? image, string comments, int userId) : base(name, image, comments)
        {
            Location = location;
            UserId = userId;
        } 
    }
}
