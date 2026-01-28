namespace NoticeableAlerts;

public class Config
{
    public readonly Alert[] Alerts =
    [
        new("""^<font color="red">\[Restart\]</font> Server restart in 15 minute\(s\)!.*$""", "Restart in 15 minutes", "game:sounds/effect/deepbell"),
        new("""^<font color="red">\[Restart\]</font> Server restart in 10 minute\(s\)!.*$""", "Restart in 10 minutes", "game:sounds/effect/deepbell"),
        new("""^<font color="red">\[Restart\]</font> Server restart in 5 minute\(s\)!.*$""", "Restart in 5 minutes", "game:sounds/effect/deepbell"),
        new("""^<font color="red">\[Restart\]</font> Server restart in 3 minute\(s\)!.*$""", "Restart in 3 minutes", "game:sounds/effect/deepbell"),
        new("""^<font color="red">\[Restart\]</font> Server restart in 1 minute\(s\)!.*$""", "Restart in 1 minutes", "game:sounds/effect/deepbell"),
        new("^A (light) temporal storm is (approaching)$", "Storm Approaching (light)", "game:sounds/effect/deepbell"),
        new("^A (medium) temporal storm is (approaching)$", "Storm Approaching (medium)", "game:sounds/effect/deepbell"),
        new("^A (heavy) temporal storm is (approaching)$", "Storm Approaching (heavy)", "game:sounds/effect/deepbell"),
        new("^A (light) temporal storm is (imminent)$", "Storm Imminent (light)", "game:sounds/effect/deepbell"),
        new("^A (medium) temporal storm is (imminent)$", "Storm Imminent (medium)", "game:sounds/effect/deepbell"),
        new("^A (heavy) temporal storm is (imminent)$", "Storm Imminent (heavy)", "game:sounds/effect/deepbell"),
        new("^The temporal storm seems to be waning$", "Storm Waning", null)
    ];
    
    public class Alert(string pattern, string? displayText, string? soundLocation)
    {
        public string Pattern = pattern;
        public string? DisplayText = displayText;
        public string? SoundLocation = soundLocation;
    }
}