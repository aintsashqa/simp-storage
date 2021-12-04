using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SimpStorage.WebClient.Pages.FileStorage.Components.RenderFileContent
{
    public class RenderFileContentViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string contentType, byte[] content)
        {
            var viewModel = new RenderFileContentViewModel(contentType, content);
            return await Task.FromResult(View(viewModel));
        }
    }
}
