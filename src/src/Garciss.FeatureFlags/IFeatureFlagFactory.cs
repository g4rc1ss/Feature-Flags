namespace Garciss.FeatureFlags
{
    public interface IFeatureFlagFactory
    {
        FeatureFlag CreateFeatureFlag(EnvironmentMode featureFlagEnvironment);
    }
}