using System;
using System.Runtime.Serialization;

namespace Garciss.FeatureFlags.Exceptions;

/// <summary>
/// 
/// </summary>
public class NotExistsFeatureFlagException : Exception
{

    /// <summary>
    /// Implementamos una Excepcion personalizada cuando no existe una FeatureFlag
    /// </summary>
    public NotExistsFeatureFlagException()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    public NotExistsFeatureFlagException(string message) : base(message)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public NotExistsFeatureFlagException(string message, Exception innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected NotExistsFeatureFlagException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
