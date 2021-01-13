namespace Core.ModelSpace
{
  /// <summary>
  /// Definition
  /// </summary>
  public interface IInstanceManager<T>
  {
    /// <summary>
    /// Single instance
    /// </summary>
    static T Instance { get; }
  }

  /// <summary>
  /// Service to track account changes, including equity and quotes
  /// </summary>
  public class InstanceManager<T> : IInstanceManager<T> where T: new()
  {
    private static readonly T _instance = new T();

    /// <summary>
    /// Single instance
    /// </summary>
    public static T Instance => _instance;

    /// <summary>
    /// Constructor
    /// </summary>
    static InstanceManager()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    private InstanceManager()
    {
    }
  }
}
