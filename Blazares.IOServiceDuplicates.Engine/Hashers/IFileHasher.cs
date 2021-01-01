namespace Blazares.IOServiceDuplicates.Engine.Hashers
{
    public interface IFileHasher
    {
        string GetHashFromFileByPath(string filePath);

    }
}