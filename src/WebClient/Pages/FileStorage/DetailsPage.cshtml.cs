using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpStorage.Application.Queries.GetBinaryObjectDetails;
using SimpStorage.WebClient.Models;

namespace SimpStorage.WebClient.Pages.FileStorage
{
    public class DetailsPageModel : PageModel
    {
        private readonly IMediator _mediator;

        [FromRoute]
        public Guid Id { get; set; }

        public FileDetails Details { get; private set; }
            = default!;

        public DetailsPageModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task OnGetAsync()
        {
            var requestQuery = new GetBinaryObjectDetailsQuery(Id);
            var queryResponse = await _mediator.Send(requestQuery, HttpContext.RequestAborted);

            Details = new FileDetails(
                queryResponse.Metadata.Filename,
                queryResponse.Metadata.Extension,
                queryResponse.Metadata.ContentType,
                queryResponse.Data
            );
        }
    }
}
