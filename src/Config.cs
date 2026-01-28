namespace NoticeableAlerts;

public class Config
{
    public readonly Alert[] Alerts =
    [
        new("""^<font color="#ff9102"><strong>Server is restarting in (\d+) minutes?</strong></font>$""", "Restart in {0} minutes", "game:sounds/effect/deepbell"),
        new("^A (light|medium|heavy) temporal storm is approaching$", "Storm Approaching ({0})", "game:sounds/effect/deepbell"),
        new("^A (light|medium|heavy) temporal storm is imminent$", "Storm Imminent ({0})", "game:sounds/effect/deepbell"),
        new("^The temporal storm seems to be waning$", "Storm Waning", null)
    ];
    
    public class Alert(string pattern, string? displayText, string? soundLocation)
    {
        public readonly string Pattern = pattern;
        public readonly string? DisplayText = displayText;
        public readonly string? SoundLocation = soundLocation;
    }
}