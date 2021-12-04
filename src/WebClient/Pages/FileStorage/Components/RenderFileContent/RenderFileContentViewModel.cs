using System;
using System.Linq;

namespace SimpStorage.WebClient.Pages.FileStorage.Components.RenderFileContent
{
    public record RenderFileContentViewModel(
        string ContentType,
        byte[] Content
    )
    {
        public FileContentType FileContentType
        {
            get
            {
                var prefix = ContentType.Split('/').ElementAt(0);
                switch (prefix)
                {
                    case "image":
                        return FileContentType.Image;

                    case "video":
                        return FileContentType.Video;

                    default:
                        return FileContentType.Unsupported;
                }
            }
        }

        public string ShowAsMediaContent()
        {
            var base64 = Convert.ToBase64String(Content);
            return string.Format($"data:{ContentType};base64,{base64}");
        }
    }
}
