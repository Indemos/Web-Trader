using Core.ManagerSpace;
using Core.ModelSpace;
using System;
using System.Linq;

namespace Core.CollectionSpace
{
  /// <summary>
  /// Collection with aggregation by date and time
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public interface ITimeCollection<T> : IIndexCollection<T> where T : ITimeModel
  {
    /// <summary>
    /// Update or add item to the collection depending on its date and time 
    /// </summary>
    void Add(T item, TimeSpan span);
  }

  /// <summary>
  /// Collection with aggregation by date and time
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class TimeCollection<T> : IndexCollection<T>, ITimeCollection<T> where T : ITimeModel
  {
    /// <summary>
    /// Update or add item to the collection depending on its date and time 
    /// </summary>
    public virtual void Add(T item, TimeSpan span)
    {
      var previous = this.LastOrDefault();

      if (previous != null)
      {
        var nextTime = ConversionManager.Round(item.Time, span);
        var previousTime = ConversionManager.Round(previous.Time, span);

        if (Equals(previousTime, nextTime))
        {
          this[Count - 1] = item;
          return;
        }
      }

      base.Add(item);
    }
  }
}
