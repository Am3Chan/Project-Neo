using System.Text.Json.Serialization;
using Neo.Core;
using Neo.Core.Extensions;
using Neo.Core.Models;
using Neo.Core.Types;
using Neo.Driver.Interfaces;
using Neo.Game.Apex.Core.Interfaces;
using Neo.Game.Apex.Core.Utilities;

namespace Neo.Game.Apex.Core.Models
{
    public class Npc : IUpdatable
    {
        private readonly LastVisibleTime _lastVisibleTime;
        private readonly Access<Vector> _localOrigin;

        #region Constructors

        public Npc(IDriver driver, IOffsets offsets, ulong address)
        {
            _lastVisibleTime = new LastVisibleTime(driver.Access(address + offsets.EntityLastVisibleTime, SingleType.Instance));
            _localOrigin = driver.Access(address + offsets.EntityLocalOrigin, VectorType.Instance);
        }

        #endregion

        #region Properties

        [JsonPropertyName("localOrigin")]
        public Vector LocalOrigin
        {
            get => _localOrigin.Get();
            set => _localOrigin.Set(value);
        }

        [JsonPropertyName("visible")]
        public bool Visible => _lastVisibleTime.Visible;

        #endregion

        #region Implementation of IUpdatable

        public void Update(DateTime frameTime)
        {
            _lastVisibleTime.Update(frameTime);
            _localOrigin.Update(frameTime);
        }

        #endregion
    }
}