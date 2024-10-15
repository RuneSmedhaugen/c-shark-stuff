using Microsoft.AspNetCore.Mvc;

namespace VisionHub.Models
{
    public class Artworks : BaseModel
    {
        private int _userID;
        private int _categoryID;
        private string _title;
        private string _description;
        private string _url;
        private DateTime _uploadDate = DateTime.Now;

        public int UserID { get { return _userID; } set { _userID = value; } }
        public string Title { get { return _title; } set { _title = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public DateTime UploadDate { get { return _uploadDate; } private set { _uploadDate = value; } }
        public string ImageUrl { get { return _url; } set { _url = value; } }
        public int CategoryID { get { return _categoryID; } set { _categoryID = value; } }

        public Artworks(int id, int userID, int categoryID, string title, string description, string imageUrl, DateTime uploadDate) : base(id)
        {
            UserID = userID;
            CategoryID = categoryID;
            Title = title;
            Description = description;
            ImageUrl = imageUrl;

        }

        public Artworks()
        {
            
        }
    }
}
