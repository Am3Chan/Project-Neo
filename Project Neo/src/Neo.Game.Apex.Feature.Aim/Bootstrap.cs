using Microsoft.Extensions.DependencyInjection;
using Neo.Game.Apex.Core.Interfaces;

namespace Neo.Game.Apex.Feature.Aim
{
    public static class Bootstrap
    {
        #region Statics

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<Config>();
            services.AddTransient<IFeature, Feature>();
        }

        #endregion
    }
}