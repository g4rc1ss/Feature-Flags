using System.Collections.Generic;
using Garciss.FeatureFlags.Exceptions;

namespace Garciss.FeatureFlags.Extensions.Static
{
    internal class FeatureFlagStatic : IFeatureFlag
    {
        private readonly Dictionary<string, FeatureFlag> _valuesOfFeatureFlag = new();

        /// <summary>
        /// Obtenemos la Feature Flag inyectada
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Objeto que contiene la Feature Flag inicializa con los parametros para comprobar si esta o no activa</returns>
        public FeatureFlag GetFeatureFlag(string name)
        {
            if (!_valuesOfFeatureFlag.TryGetValue(name, out var featureFlag))
            {
                throw new NotExistsFeatureFlagException($"Don't exists {name}");
            }
            return featureFlag;
        }

        internal void AddFeatureFlag(string name, FeatureFlag featureFlag)
        {
            _valuesOfFeatureFlag.Add(name, featureFlag);
        }
    }
}
