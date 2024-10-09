using Microsoft.AspNetCore.SignalR;

namespace VisionHub.Models
{
    public abstract class BaseModel
    {
        private int _id;
        private string _connectionString;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string ConnectionString
        {
            get => _connectionString;
            set => _connectionString = value;
        }

        public BaseModel(int id, string connectionString)
        {
            Id = id;
            ConnectionString = connectionString;
        }

        public BaseModel()
        {
            
        }
    }
}
