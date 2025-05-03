namespace SZOKITALALOAKASZTOFA_X6N2KU_RUTH.BACKEND.Data
{
    public interface IWordRepository
    {
        IEnumerable<string> Read();
        string ReadRandom();
    }
}