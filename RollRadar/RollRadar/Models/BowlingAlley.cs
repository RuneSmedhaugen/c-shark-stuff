namespace RollRadar.Models
{
    public class BowlingAlley
    {
        private int _id;
        private string _name;
        private string _location;
        private string _review;
        private string _image;

        public int Id
        {
            get => _id;
            private set => _id = value;
        }

        public string Name
        {
            get => _name; 
            set => _name = value;
        }

        public string Location
        {
            get => _location;
            set => _location = value;
        }

        public string Review
        {
            get => _review;
            set => _review = value;
        }

        public string Image
        {
            get => _image;
            set => _image = value;
        }

        public BowlingAlley(int id, string name, string location, string review, string image)
        {
            _id = id;
            _name = name;
            _location = location;
            _review = review;
            _image = image;
        } 
    }
}
