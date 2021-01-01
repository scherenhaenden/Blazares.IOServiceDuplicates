namespace Blazares.IOServiceDuplicates.Hashers
{
    public interface IFileHasher
    {
        string GetHashFromFileByPath(string filePath);

    }
}