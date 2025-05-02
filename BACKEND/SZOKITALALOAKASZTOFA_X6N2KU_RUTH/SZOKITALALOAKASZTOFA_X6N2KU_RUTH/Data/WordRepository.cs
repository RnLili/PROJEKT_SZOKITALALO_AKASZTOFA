namespace SZOKITALALOAKASZTOFA_X6N2KU_RUTH.Data
{
    public class WordRepository : IWordRepository
    {
        List<string> Words;

        public WordRepository()
        {
            Words = new List<string> { "macska", "laptop", "kutya", "mosógép", "orgona", "bögre", "nyuszi" };
        }

        public IEnumerable<string> Read()
        {
            return this.Words;
        }
        public string ReadRandom()
        {
            Random rnd = new Random();
            int wordNum = rnd.Next(this.Words.Count);
            return this.Words[wordNum];
        }
    }
}
