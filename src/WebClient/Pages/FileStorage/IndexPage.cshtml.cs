using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpStorage.Application.Queries.GetBinaryObjectsCollection;
using SimpStorage.WebClient.Models;

namespace SimpStorage.WebClient.Pages.FileStorage
{
    public class IndexPageModel : PageModel
    {
        private readonly IMediator _mediator;

        [FromQuery]
        public string Sort { get; set; }
            = string.Empty;

        public IEnumerable<FileLookupItem> FileCollection { get; private set; }
            = new FileLookupItem[] { };

        public IndexPageModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task OnGetAsync()
        {
            var order = GetOrderByQueryPropertySort();
            var requestQuery = new GetBinaryObjectsCollectionQuery(15, 0, order);
            var queryResponse = await _mediator.Send(requestQuery, HttpContext.RequestAborted);
            FileCollection = queryResponse.Select(x =>
                new FileLookupItem(x.Id, x.Metadata.Filename + x.Metadata.Extension, x.Metadata.Size, x.Metadata.CreationDate));
        }

        private BinaryObjectsCollectionOrder GetOrderByQueryPropertySort()
        {
            switch (Sort)
            {
                case "filename":
                    return BinaryObjectsCollectionOrder.ByFilename;

                case "size":
                    return BinaryObjectsCollectionOrder.BySize;

                case "uploaded-at-date":
                    return BinaryObjectsCollectionOrder.ByCreationDate;

                default:
                    return BinaryObjectsCollectionOrder.None;
            }
        }
    }
}
