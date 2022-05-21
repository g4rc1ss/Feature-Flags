using System;
using System.Collections.Generic;
using Garciss.FeatureFlags.Extensions.Configuration;
using Garciss.FeatureFlags.Extensions.Static;
using Microsoft.Extensions.DependencyInjection;

namespace Garciss.FeatureFlags.Extensions
{
    /// <summary>
    /// Clase que extiende funciones de IServiceCollection para agregar dependencias a FeatureFlags
    /// </summary>
    public static class FeatureFlagServiceCollectionExtension
    {

        /// <summary>
        /// Agrega a la inyeccion de dependencias el uso de las feature flags de forma estatica
        /// Se enviara un diccionario con las FeatureFlags correspondientes
        /// La dependencia se agrega como Singleton
        /// </summary>
        /// <param name="services"></param>
        /// <param name="featuresFlags"></param>
        /// <returns></returns>
        public static IServiceCollection AddFeatureFlagsWithDictionary(this IServiceCollection services, Dictionary<string, string> featuresFlags)
        {
            services.AddSingleton<IFeatureFlagFactory, FeatureFlagFactory>();

            services.AddSingleton<IFeatureFlag, FeatureFlagStatic>(service =>
            {
                var factoria = service.GetService<IFeatureFlagFactory>();

                var initializeFeatureFlag = new FeatureFlagStatic();
                foreach (var featureFlag in featuresFlags)
                {
                    Enum.TryParse<EnvironmentMode>(featureFlag.Value, out var value);
                    initializeFeatureFlag.AddFeatureFlag(featureFlag.Key, factoria.CreateFeatureFlag(value));
                }
                return initializeFeatureFlag;
            });
            return services;
        }

        /// <summary>
        /// Crear una seccion en el appsettings.json llamada FeatureFlags
        /// Esta funcion agregara como dependencia el uso de FeatureFlags usando el objeto IConfiguration para mapear el appsettings.json
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddFeatureFlagsWithIConfiguration(this IServiceCollection services)
        {
            services.AddSingleton<IFeatureFlagFactory, FeatureFlagFactory>();

            services.AddScoped<IFeatureFlag, FeatureFlagConfiguration>();
            return services;
        }
    }
}
