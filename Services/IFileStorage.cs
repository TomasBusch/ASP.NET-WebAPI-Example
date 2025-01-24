namespace WebAPI.Services
{
    public interface IFileStorage
    {
        public Task<bool> SaveFileAsync();

        public Task<bool> DeleteFileAsync();

    }
}
