namespace psittacus.Models
{
    public class NlpResponse
    {
        public string Label { get; set; }
        public object Data { get; set; } // Use object type to hold any kind of data
    }
}
