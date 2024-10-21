﻿using System.Data;
using System.Data.SqlClient;
using VisionHub.Models;

namespace VisionHub.Services
{
    public class CommentService : BaseService
    {
        public CommentService(string connectionString) : base(connectionString)
        {
        }

        public void AddComment(int artworkId, int userId, string commentText)
        {
            string query =
                "INSERT INTO Comments (ArtworkID, UserID, CommentText, CommentDate) VALUES (@ArtworkID, @UserID, @CommentText, @CommentDate)";
            var parameters = new[]
            {
                new SqlParameter("@ArtworkID", artworkId),
                new SqlParameter("@UserID", userId),
                new SqlParameter("@CommentText", commentText),
                new SqlParameter("@CommentDate", DateTime.Now)
            };

            ExecuteNonQuery(query, parameters);
        }

        public void RemoveComment(int commentId)
        {
            string query = "DELETE FROM Comments WHERE CommentID = @CommentID";
            var parameters = new[]
            {
                new SqlParameter("@CommentID", commentId)
            };
            ExecuteNonQuery(query, parameters);
        }

        public void UpdateComment(int commentId, string newCommentText)
        {
            string query = "UPDATE Comments SET CommentText = @CommentText WHERE CommentID = @CommentID";

            var parameters = new[]
            {
                new SqlParameter("@CommentText", newCommentText),
                new SqlParameter("@CommentID", commentId)
            };
            ExecuteNonQuery(query, parameters);
        }

        
        public List<Comments> GetAllComments()
        {
            string query = "SELECT * FROM Comments";
            
            DataTable dataTable = ExecuteQuery(query);

            return ConvertDataTableToCommentsList(dataTable);
        }

        public List<Comments> GetCommentsId(int commentID)
        {
            string query = "SELECT * FROM Comments WHERE CommentID = @CommentID";

            var parameters = new[]
            {
                new SqlParameter("@CommentID", commentID)
            };

            DataTable dataTable = ExecuteQuery(query);
            return ConvertDataTableToCommentsList(dataTable);
        }

        public List<Comments> GetCommentsArtworkID(int ArtworkID)
        {
            string query = "SELECT * FROM Comments WHERE ArtworkID = @ArtworkID";

            var parameters = new[]
            {
                new SqlParameter("@ArtworkID", ArtworkID)
            };

            DataTable dataTable = ExecuteQuery(query, parameters);
            return ConvertDataTableToCommentsList(dataTable);
        }

        public List<Comments> GetCommentsByUser(int UserID)
        {
            string query = "SELECT * FROM Comments WHERE UserID = @UserID";

            var parameters = new[]
            {
                new SqlParameter("UserID", UserID)
            };
            DataTable dataTable = ExecuteQuery(query, parameters);
            return ConvertDataTableToCommentsList(dataTable);
        }

        public List<Comments> ConvertDataTableToCommentsList(DataTable dataTable)
        {
            var commentsList = new List<Comments>();

            foreach (DataRow row in dataTable.Rows)
            {
                var comment = new Comments
                {
                    Id = Convert.ToInt32(row["CommentID"]),
                    ArtworkID = Convert.ToInt32(row["ArtworkID"]),
                    UserID = Convert.ToInt32(row["UserID"]),
                    CommentText = row["CommentText"].ToString(),
                };

                commentsList.Add(comment);
            }

            return commentsList;
        }
    }
}
