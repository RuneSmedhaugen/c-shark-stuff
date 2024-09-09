namespace RollRadar.Models
{
    public class Inherit
    {
        private string Name;
        private string Location;
        private int Id;
        private string Image;
        private string Comments;

        public string name
        {
            get { return Name; }
            set { Name = value; }
        }

        public string location
        {
            get { return Location; }
            set { Location = value; }
        }

        public int id
        {
            get { return Id; }
            set { Id = value; }
        }

        public string image
        {
            get { return Image; }
            set { Image = value; }
        }

        public string comments
        {
            get { return Comments; }
            set { Comments = value; }
        }

        public Inherit(string name, string location, string image, string comments)
        {
            this.name = name;
            this.location = location;
            this.image = image;
            this.comments = comments;
        }

        public Inherit(string name, string image, string comments)
        {
            this.name = name;
            location = image;
            this.comments = comments;
        }

    }
}
