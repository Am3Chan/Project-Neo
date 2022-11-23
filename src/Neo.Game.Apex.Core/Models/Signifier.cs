using System.Text;
using System.Text.Json.Serialization;
using Neo.Core;
using Neo.Core.Extensions;
using Neo.Core.Types;
using Neo.Driver.Interfaces;
using Neo.Game.Apex.Core.Interfaces;

namespace Neo.Game.Apex.Core.Models
{
    public class Signifier : IUpdatable
    {
        private readonly Access<string> _value;

        #region Constructors

        public Signifier(IDriver driver, ulong address)
        {
            _value = driver.Access(address, new StringType(32, Encoding.ASCII), 60000);
        }

        #endregion

        #region Properties

        [JsonPropertyName("name")]
        public string Value
        {
            get => _value.Get();
            set => _value.Set(value);
        }

        #endregion

        #region Implementation of IUpdatable

        public void Update(DateTime frameTime)
        {
            _value.Update(frameTime);
        }

        #endregion
    }
}