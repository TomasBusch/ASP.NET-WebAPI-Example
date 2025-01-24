namespace WebAPI.Services
{
    public interface IFileStorage
    {
        public Task<bool> SaveFileAsync(string FilePath, string FileName);

        public Task<bool> DeleteFileAsync(string FileId);

    }
}
