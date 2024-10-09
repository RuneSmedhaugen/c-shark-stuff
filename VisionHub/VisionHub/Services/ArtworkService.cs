using System.Data;
using System.Data.SqlClient;
using VisionHub.Models;

namespace VisionHub.Services


{
    public class ArtworkService : BaseService
    {
        public ArtworkService(string connectionString) : base(connectionString)
        {

        }

        public void AddArt(int userID, string title, string description, string imageUrl)
        {
            string query =
                "INSERT INTO Artworks (UserID, Title, Description, UploadDate, ImageUrl) VALUES (@UserID, @Title, @Description, @UploadDate, @ImageUrl)";
            var parameters = new[]
            {
                new SqlParameter("@UserID", userID),
                new SqlParameter("@Title", title),
                new SqlParameter("@Description", description),
                new SqlParameter("@ImageUrl", imageUrl),
                new SqlParameter("@UploadDate", DateTime.Now)
            };

            ExecuteNonQuery(query, parameters);
        }

        public void UpdateArt(int artID, string newTitle, string newDescription, string newImageUrl)
        {
        string query = "UPDATE Artworks SET Title = @Title, Description = @Description, ImageUrl = @ImageUrl WHERE ArtID = @ArtID";

        var parameters = new[]
        {
            new SqlParameter("@ArtID", artID),
            new SqlParameter("@Title", newTitle),
            new SqlParameter("@Description", newDescription),
            new SqlParameter("@ImageUrl", newImageUrl)

        };

        ExecuteNonQuery(query, parameters);
        }

        public void DeleteArt(int artID)
        {
        string Query = "DELETE Artworks WHERE ArtID = @ArtID";
        var parameters = new[]
        {
            new SqlParameter("@ArtID", artID)
        };
        ExecuteNonQuery(Query, parameters);
        }

        public List<Artworks> GetUserArt(int userID)
        {
            string query = "SELECT * FROM Artworks WHERE UserID = @UserID";
            var parameters = new[]
            {
                new SqlParameter("@UserID", userID)
            };

            DataTable dataTable = ExecuteQuery(query, parameters);
            return ConvertDataTableToArtworksList(dataTable);
        }

        public List<Artworks> GetArtId(int artID)
        {
            string query = "SELECT * FROM Artworks WHERE ArtID = @ArtID";
            var parameters = new[]
            {
                new SqlParameter("@ArtID", artID)
            };

            DataTable dataTable = ExecuteQuery(query, parameters);
            return ConvertDataTableToArtworksList(dataTable);
        }

        public List<Artworks> GetAllArt()
        {
            string query = "SELECT * FROM Artworks";
            DataTable dataTable = ExecuteQuery(query);
            return ConvertDataTableToArtworksList(dataTable);
        }

        public List<Artworks> ConvertDataTableToArtworksList(DataTable dataTable)
        {
            List<Artworks> artworksList = new List<Artworks>();

            foreach (DataRow row in dataTable.Rows)
            {
                Artworks artwork = new Artworks
                {
                    Id = Convert.ToInt32(row["ArtID"]),
                    UserID = Convert.ToInt32(row["UserID"]),
                    Title = row["Title"].ToString(),
                    Description = row["Description"].ToString(),
                    ImageUrl = row["ImageUrl"].ToString(),
                };

                artworksList.Add(artwork);
            }

            return artworksList;
        }
    }
}

