namespace Business.Interfaces;

public interface iFileService
{
    bool SaveContentToFile(string content);

    string GetContentFromFile();
}
