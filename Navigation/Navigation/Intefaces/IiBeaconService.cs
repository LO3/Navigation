using System;
using static IBeaconLIc.Events.IBeaconDelegate;

namespace IBeaconLIc.Interfaces
{
    public interface IiBeaconService
    {
        event MyEvent Notify;
        void Initialize();
    }
}
