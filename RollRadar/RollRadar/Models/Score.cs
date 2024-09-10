using System.Runtime.InteropServices.JavaScript;

namespace RollRadar.Models
{
    public class Score : Inherit
    {
      
        private int _userId;
        private int _totalScore;
        private int _strikes;
        private int _spares;
        private int _holes;
        private int _bowlingAlleyId;
        private string _bowlingAlleyName;
        private DateTime _scoreDate;


        public int userId
        {
            get => _userId;
            set => _userId = value;
        }

        public int totalScore
        {
            get => _totalScore;
            set => _totalScore = value;
        }

        public int strikes
        {
            get => _strikes;
            set => _strikes = value;
        }

        public int spares
        {
            get => _spares;
            set => _spares = value;
        }

        public int holes
        {
            get => _holes;
            set => _holes = value;
        }

        public int bowlingAlleyId
        {
            get => _bowlingAlleyId;
            set => _bowlingAlleyId = value;
        }

        public DateTime scoreDate
        {
            get => _scoreDate;
            set => _scoreDate = value;
        }


        public string bowlingAlleyName
        {
            get => _bowlingAlleyName;
            set => _bowlingAlleyName = value;
        }

        public Score(string name, int totalScore, int strikes, int spares, int holes, DateTime scoreDate, string bowlingAlleyName, string image, string comments) : base(name, image, comments)
        {
            this.totalScore = totalScore;
            this.strikes = strikes;
            this.spares = spares;
            this.holes = holes;
            this.scoreDate = scoreDate;
            this.bowlingAlleyName = bowlingAlleyName;
        }
    }
}
