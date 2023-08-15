namespace Data.Access 
{
    public interface IDownloadTestFile 
    {
        Task<FileAccess> GetFileAsync(); 
    }
}