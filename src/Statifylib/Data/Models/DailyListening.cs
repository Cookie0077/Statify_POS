namespace StatifyLib.Data.Models;

public class DailyListening
{
    public DateTime Timestamp { get; set; }
    public int Playtime { get; set; }  // in ms
}