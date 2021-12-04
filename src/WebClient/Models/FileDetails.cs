namespace SimpStorage.WebClient.Models
{
    public record FileDetails(
        string Filename,
        string Extension,
        string ContentType,
        byte[] Content
    );
}
