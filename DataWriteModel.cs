namespace httprequest
{
    internal class DataWriteModel<TDataModel>
    {
        public string plugin_id { get; set; }
        public string organization_id { get; set; }
        public string collection_name { get; set; }
        public bool bulk_write { get; set; }
        public TDataModel payload { get; set; }
    }
}