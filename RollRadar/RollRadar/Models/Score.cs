namespace RollRadar.Models
{
    public class Score
    {
        private int _id;
        private int _userId;
        private int _totalScore;
        private int _strikes;
        private int _spares;
        private int _holes;
        private int _bowlingAlleyId;
        private string _bowlingAlleyName;
        private DateTime _scoreDate;
        private string _image;
        private string _comments;

        public int Id
        {
            get => _id;
            private set => _id = value;
        }

        public int UserId
        {
            get => _userId;
            set => _userId = value;
        }

        public int TotalScore
        {
            get => _totalScore;
            set
            {
                if (value < 0)
                    throw new ArgumentException("TotalScore cannot be negative");
                _totalScore = value;
            }
        }

        public int Strikes
        {
            get => _strikes;
            set
            {
                if (value < 0) 
                    throw new ArgumentException("Strikes cannot be negative");
                _strikes = value;
            }
        }

        public int Spares
        {
            get => _spares;
            set
            {
                if (value < 0) 
                    throw new ArgumentException("Spares cannot be negative");
                _spares = value;
            }
        }

        public int Holes
        {
            get => _holes;
            set
            {
                if (value < 0) 
                    throw new ArgumentException("Holes cannot be negative");
                _holes = value;
            }
        }

        public int BowlingAlleyId
        {
            get => _bowlingAlleyId;
            set => _bowlingAlleyId = value;
        }

        public DateTime ScoreDate
        {
            get => _scoreDate;
            set => _scoreDate = value;
        }

        public string Image
        {
            get => _image;
            set => _image = value;
        }

        public string Comments
        {
            get => _comments;
            set => _comments = value;
        }

        public string BowlingAlleyName
        {
            get => _bowlingAlleyName;
            set => _bowlingAlleyName = value;
        }

        public Score(int totalScore, int strikes, int spares, int holes, DateTime scoreDate, string image, string comments, string bowlingAlleyName)
        {
            TotalScore = totalScore;
            Strikes = strikes;
            Spares = spares;
            Holes = holes;
            ScoreDate = scoreDate;
            Image = image;
            Comments = comments;
            BowlingAlleyName = bowlingAlleyName;
        }
    }
}
