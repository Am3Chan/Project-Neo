using System.Text.Json.Serialization;
using Neo.Core;
using Neo.Core.Extensions;
using Neo.Core.Types;
using Neo.Driver.Interfaces;
using Neo.Game.Apex.Core.Interfaces;

namespace Neo.Game.Apex.Core.Models
{
    public class LocalPlayer : IUpdatable
    {
        private readonly Access<ulong> _value;

        #region Constructors

        public LocalPlayer(IDriver driver, IOffsets offsets, ulong address)
        {
            _value = driver.Access(address + offsets.CoreLocalPlayer, UInt64Type.Instance, 1000);
        }

        #endregion

        #region Properties

        [JsonPropertyName("value")]
        public ulong Value => _value.Get();

        #endregion

        #region Implementation of IUpdatable

        public void Update(DateTime frameTime)
        {
            _value.Update(frameTime);
        }

        #endregion
    }
}