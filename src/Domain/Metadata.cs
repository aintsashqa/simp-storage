namespace SimpStorage.Domain
{
    public class Metadata : EntityBase
    {
        public long Size { get; set; } = 0;
        public string Filename { get; set; } = string.Empty;
        public string Extension { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public virtual BinaryObject BinaryObject { get; set; } = default!;
    }
}
