using System.Runtime.InteropServices.JavaScript;

namespace RollRadar.Models
{
    public class Score : Inherit
    {
        public int UserId { get; set; }

        public int TotalScore { get; set; }

        public int Strikes { get; set; }

        public int Spares { get; set; }

        public int Holes { get; set; }

        public int BowlingAlleyId { get; set; }

        public DateTime ScoreDate { get; set; }


        public string BowlingAlleyName { get; set; }

        public Score(string name, int totalScore, int strikes, int spares, int holes, DateTime scoreDate, string bowlingAlleyName, string image, string comments) : base(name, image, comments)
        {
            this.TotalScore = totalScore;
            this.Strikes = strikes;
            this.Spares = spares;
            this.Holes = holes;
            this.ScoreDate = scoreDate;
            this.BowlingAlleyName = bowlingAlleyName;
        }
    }
}
