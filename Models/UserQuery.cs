using Microsoft.ML.Data;

namespace psittacus.Models
{
    public class UserQuery
    {
        [LoadColumn(0)]
        public string Text { get; set; }

        [LoadColumn(1)]
        public string Label { get; set; }
    }
}
