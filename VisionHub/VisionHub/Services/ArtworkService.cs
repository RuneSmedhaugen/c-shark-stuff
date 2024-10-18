using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using VisionHub.Models;

namespace VisionHub.Services


{
    public class ArtworkService : BaseService
    {
        public ArtworkService(string connectionString) : base(connectionString)
        {

        }

        public void AddArt(int userID, int categoryId, string title, string description, string imageUrl, bool isFeatured)
        {
            string query = "INSERT INTO Artworks (UserID, CategoryId, Title, Description, UploadDate, ImageUrl, IsFeatured) VALUES (@UserID, @CategoryId, @Title, @Description, @UploadDate, @ImageUrl, @IsFeatured)";
            var parameters = new[]
            {
                new SqlParameter("@UserID", userID),
                new SqlParameter("@CategoryId", categoryId),
                new SqlParameter("@Title", title),
                new SqlParameter("@Description", description),
                new SqlParameter("@ImageUrl", SqlDbType.NVarChar) { Value = (object)imageUrl ?? DBNull.Value },
                new SqlParameter("@UploadDate", DateTime.Now),
                new SqlParameter("@IsFeatured", isFeatured)
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
            new SqlParameter("@ImageUrl", SqlDbType.NVarChar) { Value = (object)newImageUrl ?? DBNull.Value },

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

        public List<Artworks> GetFeaturedArtworks()
        {
            string query = "SELECT TOP 5 * FROM Artworks WHERE IsFeatured = 1 ORDER BY NEWID()";
            DataTable dataTable = ExecuteQuery(query);
            return ConvertDataTableToArtworksList(dataTable);
        }

        public List<Artworks> GetArtCategoryId(int categoryId)
        {
            string query = "SELECT * FROM Artworks WHERE CategoryId = @CategoryId";
            var parameters = new[]
            {
                new SqlParameter("@CategoryId", categoryId)
            };
            DataTable dataTable = ExecuteQuery(query, parameters);
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
                    CategoryId = Convert.ToInt32(row["CategoryId"])
                };

                artworksList.Add(artwork);
            }

            return artworksList;
        }
    }
}

