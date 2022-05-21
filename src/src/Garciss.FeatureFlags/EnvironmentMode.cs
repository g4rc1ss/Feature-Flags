namespace Garciss.FeatureFlags
{
    /// <summary>
    /// Enumerador para indicar el entorno en el cual se debera de ejecutar la Feature Flag
    /// </summary>
    public enum EnvironmentMode
    {
        /// <summary>
        /// Cuando no queremos que se ejecute la Feature Flag en ningun entorno
        /// </summary>
        Unknow,
        /// <summary>
        /// Se usará para poder ejecutar la Feature Flag solo en entornos de desarrollo
        /// </summary>
        Development,
        /// <summary>
        /// Se usará para ejecutar la Feature Flag en cualquier tipo de entorno
        /// </summary>
        Production
    }
}
