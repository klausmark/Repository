namespace Repository
{
    internal interface IFile
    {
        void WriteAllText(string path, string contents);
        string ReadAllText(string path);
        bool Exists(string path);
    }
}