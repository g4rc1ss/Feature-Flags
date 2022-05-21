using Microsoft.Extensions.Hosting;

namespace Garciss.FeatureFlags
{
    public class FeatureFlag
    {
        private readonly IHostEnvironment _appEnvironment;
        private readonly EnvironmentMode _environmentMode;
        /// <summary>
        /// Campo que indica si la Feature Flag esta activa para el entorno de ejecucion actual
        /// </summary>
        public readonly bool isEnabled;

        /// <summary>
        /// Recibimos un enumerador con el Environment en el que se va a indicar la FeatureFlag
        /// </summary>
        /// <param name="environmentMode"></param>
        internal FeatureFlag(EnvironmentMode environmentMode, IHostEnvironment appEnvironment)
        {
            _environmentMode = environmentMode;
            _appEnvironment = appEnvironment;

            isEnabled = IsEnabled();
        }

        private bool IsEnabled()
        {
            return GetCurrentEnvironment() <= _environmentMode;
        }

        private EnvironmentMode GetCurrentEnvironment()
        {
            return _appEnvironment.IsDevelopment() ? EnvironmentMode.Development : EnvironmentMode.Production;
        }
    }
}
