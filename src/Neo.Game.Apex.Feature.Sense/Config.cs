using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Neo.Core.Extensions;

namespace Neo.Game.Apex.Feature.Sense
{
    public class Config
    {
        private readonly IConfigurationSection _config;

        #region Constructors

        public Config(IConfiguration config)
        {
            _config = config.GetSection(typeof(Config).Namespace);
        }

        #endregion

        #region Properties

        [JsonPropertyName("distance")]
        public int Distance => _config.GetProperty<int>();

        #endregion
    }
}