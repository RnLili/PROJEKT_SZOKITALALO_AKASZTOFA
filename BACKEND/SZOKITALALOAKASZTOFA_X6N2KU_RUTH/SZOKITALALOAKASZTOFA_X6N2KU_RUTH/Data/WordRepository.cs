namespace SZOKITALALOAKASZTOFA_X6N2KU_RUTH.Data
{
    public class WordRepository : IWordRepository
    {
        List<string> Words;

        public WordRepository()
        {
            Words = new List<string> { "macska", "laptop", "kutya", "oposszum", "orgona", "bolyhos", "nyuszi" , "csillag"};
        }

        public IEnumerable<string> Read()
        {
            return Words;
        }
        public string ReadRandom()
        {
            Random rnd = new Random();
            int wordNum = rnd.Next(Words.Count);
            return Words[wordNum];
        }
    }
}
