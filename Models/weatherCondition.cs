namespace psittacus.Models
{
    public class WeatherCondition
    {
        

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Condition { get; set; }
        public double Temperature { get; set; }
        public double Precipitation { get; set; }
        public double WindSpeed { get; set; }
        public int WindDirection { get; set; }
        public string WindCardinal { get; set; }
        public double WaveHeight { get; set; }
        public int WaveDirection { get; set; }
        public string WaveCardinal { get; set; }
        public double WaveHeightMax { get; set; }
        public double WaveHeightMin { get; set; }
        public double Grade { get; set; }
    

    }
}
