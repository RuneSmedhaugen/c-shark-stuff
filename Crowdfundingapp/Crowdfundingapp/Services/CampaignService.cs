using Crowdfunding_app.Models;
using System.Data.SqlClient;

namespace Crowdfunding_app.Services
{
    public class CampaignService
    {
        private readonly SqlConnection _connection;

        public CampaignService(SqlConnection connection)
        {
            _connection = connection;
        }

        public async Task AddCampaignAsync(Campaign campaign)
        {
            string query = "INSERT INTO Campaigns (UserID, Title, Description, GoalAmount, StartDate, EndDate, IsActive) VALUES (@UserID, @Title, @Description, @GoalAmount, @StartDate, @EndDate, @IsActive)";

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@UserID", campaign.UserID);
                command.Parameters.AddWithValue("@Title", campaign.Title);
                command.Parameters.AddWithValue("@Description", campaign.Description);
                command.Parameters.AddWithValue("@GoalAmount", campaign.GoalAmount);
                command.Parameters.AddWithValue("@StartDate", campaign.StartDate);
                command.Parameters.AddWithValue("@EndDate", campaign.EndDate);
                command.Parameters.AddWithValue("@IsActive", campaign.IsActive);

                await _connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
                await _connection.CloseAsync();
            }
        }

        public async Task<List<Campaign>> GetCampaignsAsync()
        {
            var campaigns = new List<Campaign>();
            string query = "SELECT * FROM Campaigns";

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                await _connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var campaign = new Campaign
                        {
                            ID = reader.GetInt32(0),
                            UserID = reader.GetInt32(1),
                            Title = reader.GetString(2),
                            Description = reader.GetString(3),
                            GoalAmount = reader.GetDecimal(4),
                            CurrentAmount = reader.GetDecimal(5),
                            StartDate = reader.GetDateTime(6),
                            EndDate = reader.GetDateTime(7),
                            IsActive = reader.GetBoolean(8)
                        };
                        campaigns.Add(campaign);
                    }
                }
                await _connection.CloseAsync();
            }

            return campaigns;
        }

        public async Task UpdateCampaignAsync(Campaign campaign)
        {
            string query = "UPDATE Campaigns SET Title = @Title, Description = @Description, GoalAmount = @GoalAmount, StartDate = @StartDate, EndDate = @EndDate, IsActive = @IsActive WHERE ID = @ID";

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Title", campaign.Title);
                command.Parameters.AddWithValue("@Description", campaign.Description);
                command.Parameters.AddWithValue("@GoalAmount", campaign.GoalAmount);
                command.Parameters.AddWithValue("@StartDate", campaign.StartDate);
                command.Parameters.AddWithValue("@EndDate", campaign.EndDate);
                command.Parameters.AddWithValue("@IsActive", campaign.IsActive);
                command.Parameters.AddWithValue("@ID", campaign.ID);

                await _connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
                await _connection.CloseAsync();
            }
        }

        public async Task DeleteCampaignAsync(int id)
        {
            string query = "DELETE FROM Campaigns WHERE ID = @ID";

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@ID", id);

                await _connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
                await _connection.CloseAsync();
            }
        }

        public async Task<Campaign> GetCampaignByIdAsync(int id)
        {
            string query = "SELECT * FROM Campaigns WHERE ID = @ID";
            Campaign campaign = null;

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@ID", id);

                await _connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        campaign = new Campaign
                        {
                            ID = reader.GetInt32(0),
                            UserID = reader.GetInt32(1),
                            Title = reader.GetString(2),
                            Description = reader.GetString(3),
                            GoalAmount = reader.GetDecimal(4),
                            CurrentAmount = reader.GetDecimal(5),
                            StartDate = reader.GetDateTime(6),
                            EndDate = reader.GetDateTime(7),
                            IsActive = reader.GetBoolean(8)
                        };
                    }
                }
                await _connection.CloseAsync();
            }

            return campaign;
        }

    }

}
