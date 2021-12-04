using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SimpStorage.WebClient.Models
{
    public record UploadFile(
        string? Filename,
        [Required] IFormFile FileInfo
    );
}
