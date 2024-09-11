﻿namespace RollRadar.Models
{
    public class Inherit
    {
        private string _name;
        private string _location;
        private int _id;
        private string _image;
        private string _comments;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public string Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }

        public Inherit(string name, string location, string image, string comments)
        {
            this.Name = name;
            this.Image = image;
            this.Comments = comments;
        }

        public Inherit(string name, string image, string comments)
        {
            this.Name = name;
            this.Image = image;
            this.Comments = comments;
        }

    }
}
