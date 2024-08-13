using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter
{
    internal class SortingHat
    {
        public string _sentences;
        public string _type;
        Random random = new Random();

        public SortingHat(string sentences, string type)
        {
            _sentences = sentences;
            _type = type;
        }

        public SortingHat()
        {

        }

        public (SortingHat Nice, SortingHat Insult, SortingHat House) SelectedSenteces()
        {
            List<SortingHat> sentences = new List<SortingHat>
            {
                new SortingHat("very stupid", "insult"),
                new SortingHat("extremely clumsy", "insult"),
                new SortingHat("incredibly annoying", "insult"),
                new SortingHat("evil as fuck", "insult"),
                new SortingHat("gullible", "insult"),
                new SortingHat("a motherfucker", "insult"),

                new SortingHat("very nice looking", "nice"),
                new SortingHat("sexy as fuuuuck", "nice"),
                new SortingHat("Godgiven", "nice"),
                new SortingHat("kindhearted", "nice"),
                new SortingHat("helpful", "nice"),
                new SortingHat("stronger than most here", "nice"),

                new SortingHat("HUFFLEPUFF", "house"),
                new SortingHat("RAVENCLAW", "house"),
                new SortingHat("SLITHERIN", "house"),
                new SortingHat("GRYFFINDOR", "house"),
            };

            var randomInsult = sentences.Where(s => s._type == "insult").OrderBy(s => random.Next()).FirstOrDefault();
            var randomNice = sentences.Where(s => s._type == "nice").OrderBy(s => random.Next()).FirstOrDefault();
            var randomHouse = sentences.Where(s => s._type == "house").OrderBy(s => random.Next()).FirstOrDefault();

            return (randomNice, randomInsult, randomHouse);
        }
    }
}
