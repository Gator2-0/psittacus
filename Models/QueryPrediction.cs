using Microsoft.ML.Data;

namespace psittacus.Models
{
    public class QueryPrediction
    {
        [ColumnName("PredictedLabel")]
        public string PredictedLabel { get; set; }
    }
}
