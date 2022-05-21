using System;
using Garciss.FeatureFlags.Exceptions;
using Microsoft.Extensions.Configuration;

namespace Garciss.FeatureFlags.Extensions.Configuration
{
    internal class FeatureFlagConfiguration : IFeatureFlag
    {
        private readonly IConfiguration _configuration;
        private readonly IFeatureFlagFactory _featureFlagFactory;
        private const string SECTION_NAME = "FeatureFlags";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="featureFlagFactory"></param>
        public FeatureFlagConfiguration(IConfiguration configuration, IFeatureFlagFactory featureFlagFactory)
        {
            _configuration = configuration;
            _featureFlagFactory = featureFlagFactory;
        }

        /// <summary>
        /// Obtenemos la Feature Flag inyectada
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Objeto que contiene la Feature Flag inicializa con los parametros para comprobar si esta o no activa</returns>
        public FeatureFlag GetFeatureFlag(string name)
        {
            var featureFlag = _configuration.GetSection(SECTION_NAME).GetSection(name);
            if (!featureFlag.Exists())
            {
                throw new NotExistsFeatureFlagException($"No existe la FeatureFlag {name}");
            }

            Enum.TryParse<EnvironmentMode>(featureFlag.Value, out var environment);
            return _featureFlagFactory.CreateFeatureFlag(environment);
        }
    }
}
