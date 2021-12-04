namespace SimpStorage.Domain
{
    public class BinaryObject : EntityBase
    {
        public virtual byte[] Data { get; set; } = new byte[] { };
        public virtual Metadata Metadata { get; set; } = default!;
    }
}
