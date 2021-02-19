namespace Model
{
    public class ChunkStatusModel
    {
        public string Id { get; set; }
        public string IndexId { get; set; }
        public string IndexName { get; set; }
        public int ResolvedItems { get; set; }
        public int UnresolvedItems { get; set; }
        public string ChunkText { get; set; }
    }
}
