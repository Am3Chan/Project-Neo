using System.Text.Json.Serialization;
using Neo.Core;
using Neo.Core.Extensions;
using Neo.Core.Types;
using Neo.Driver.Interfaces;
using Neo.Game.Apex.Core.Interfaces;

namespace Neo.Game.Apex.Core.Models
{
    public class Entity : IUpdatable
    {
        private readonly Access<ulong> _signifierName;

        #region Constructors

        public Entity(IDriver driver, IOffsets offsets, ulong address)
        {
            _signifierName = driver.Access(address + offsets.EntitySignifierName, UInt64Type.Instance, 60000);
        }

        #endregion

        #region Properties

        [JsonPropertyName("signifierName")]
        public ulong SignifierName
        {
            get => _signifierName.Get();
            set => _signifierName.Set(value);
        }

        #endregion

        #region Implementation of IUpdatable

        public void Update(DateTime frameTime)
        {
            _signifierName.Update(frameTime);
        }

        #endregion
    }
}