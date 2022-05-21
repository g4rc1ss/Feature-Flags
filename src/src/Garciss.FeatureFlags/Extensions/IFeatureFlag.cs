namespace Garciss.FeatureFlags.Extensions
{
    /// <summary>
    /// Interfaz para implementar mediante Dependency Injection el uso de FeaturesFlags
    /// </summary>
    public interface IFeatureFlag
    {
        /// <summary>
        /// Obtenemos la FeatureFlag con el nombre correspondiente
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        FeatureFlag GetFeatureFlag(string name);
    }
}
