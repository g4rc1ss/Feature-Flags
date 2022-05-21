using Microsoft.Extensions.Hosting;

namespace Garciss.FeatureFlags;

/// <summary>
/// Clase para crear la FeatureFlag comprobando el Entorno de ejecucion actual de la maquina
/// </summary>
public class FeatureFlagFactory : IFeatureFlagFactory
{
    private readonly IHostEnvironment _environment;

    public FeatureFlagFactory(IHostEnvironment environment)
    {
        _environment = environment;
    }

    public FeatureFlag CreateFeatureFlag(EnvironmentMode featureFlagEnvironment)
    {
        return new FeatureFlag(featureFlagEnvironment, _environment);
    }
}
