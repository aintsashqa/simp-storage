using System.IO;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpStorage.Application.Commands.AddBinaryObject;
using SimpStorage.WebClient.Models;

namespace SimpStorage.WebClient.Pages.FileStorage
{
    public class UploadPageModel : PageModel
    {
        private readonly IMediator _mediator;

        [BindProperty]
        public UploadFile UploadFile { get; set; } = default!;

        public UploadPageModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            using (var stream = new MemoryStream())
            {
                await UploadFile.FileInfo.CopyToAsync(stream);

                var extension = Path.GetExtension(UploadFile.FileInfo.FileName);
                var filename = string.IsNullOrWhiteSpace(UploadFile.Filename)
                    ? UploadFile.FileInfo.FileName.Replace(extension, string.Empty)
                    : UploadFile.Filename;

                var requestCommand = new AddBinaryObjectCommand(UploadFile.FileInfo.Length, filename,
                    extension, UploadFile.FileInfo.ContentType, stream.GetBuffer());
                await _mediator.Send(requestCommand);
            }

            return await Task.FromResult(RedirectToPage("IndexPage"));
        }
    }
}
