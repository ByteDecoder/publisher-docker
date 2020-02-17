using System;

namespace UtilsLibrary {
  public static class Extensions {
    public static void Times(this int count, Action action) {
      for(var i = 0; i < count; i++) {
        action();
      }
    }

    public static void Times(this int count, Action<int> action) {
      for(var i = 0; i < count; i++) {
        action(i);
      }
    }

    /// <summary>
    /// var car = new Car().With(c =>
    /// {
    ///   c.VehicleType = "Sedan";
    ///   c.Model = "fancyModelName";
    ///   //and so on
    /// });
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    public static T With<T>(this T obj, Action<T> action) {
      action(obj);
      return obj;
    }
  }
}
