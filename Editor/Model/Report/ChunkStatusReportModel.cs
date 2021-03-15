namespace Model.Report
{
    public class ChunkStatusReportModel : ChunkReportModel
    {
        public int ResolvedItems { get; set; }
        public int UnresolvedItems { get; set; }
        public string Languages { get; set; }
        public bool HasVersion { get; set; }
    }
}
