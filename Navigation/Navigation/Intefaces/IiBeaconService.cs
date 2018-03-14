using System;
using static IBeaconLIc.Events.IBeaconEvent;

namespace IBeaconLIc.Interfaces
{
    public interface IiBeaconService
    {
        event IBeaconHandler OnBeaconDataChanged;
        void Initialize();
    }
}
