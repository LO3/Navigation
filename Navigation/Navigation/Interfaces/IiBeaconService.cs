using System;
using static Notification.Events.IBeaconEvent;

namespace Navigation.Interfaces
{
    public interface IiBeaconService
    {
        event IBeaconHandler OnBeaconDataChanged;
        void Initialize();
    }
}
