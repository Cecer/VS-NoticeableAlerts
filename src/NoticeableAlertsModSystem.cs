using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Vintagestory.API.Client;
using Vintagestory.API.Common;

namespace NoticeableAlerts;

public class NoticeableAlertsModSystem : ModSystem
{
    private const string ConfigFileName = "noticeablealerts.json";

    private ICoreClientAPI? _api;

    private IReadOnlyList<Alert>? _alerts;

    public override bool ShouldLoad(EnumAppSide forSide) => forSide == EnumAppSide.Client;
    public override void StartClientSide(ICoreClientAPI api)
    {
        _api = api;

        var config = api.LoadModConfig<Config>(ConfigFileName);
        if (config == null)
        {
            config = new Config();
        }
        api.StoreModConfig(config, ConfigFileName);

        _alerts = config.Alerts
            .Select(a => new Alert(a))
            .ToList()
            .AsReadOnly();

        _api.Event.ChatMessage += OnMessage;
    }

    public override void Dispose()
    {
        if (_api != null)
        {
            _api.Event.ChatMessage -= OnMessage;
        }

        _alerts = [];
    }

    private void OnMessage(int _, string message, EnumChatType chatType, string data)
    {
        if (_alerts == null)
        {
            return;
        }

        foreach (var alert in _alerts)
        {
            if (alert.Pattern.IsMatch(message))
            {
                if (alert.DisplayText != null)
                {
                    _api?.TriggerIngameDiscovery(this, "", alert.DisplayText);
                }

                if (alert.SoundLocation != null)
                {
                    _api?.World.PlaySoundFor(alert.SoundLocation, _api.World.Player, range: float.MaxValue, volume: 1f);
                }
            }
        }
    }

    private class Alert(Config.Alert config)
    {
        public readonly Regex Pattern = new(config.Pattern, RegexOptions.Compiled);
        public readonly string? DisplayText = config.DisplayText;
        public readonly AssetLocation? SoundLocation = config.SoundLocation != null ? new AssetLocation(config.SoundLocation) : null;
    }
}