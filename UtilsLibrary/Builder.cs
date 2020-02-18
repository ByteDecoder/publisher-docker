using System;
using System.Collections.Generic;

public class Builder<T> where T : new()
{
  IList<Action<T>> actions = new List<Action<T>>();

  public T Build()
  {
    var built = new T();
    foreach (var action in actions)
    {
      action(built);
    }
    return built;
  }

  public Builder<T> With(Action<T> with)
  {
    actions.Add(with);
    return this;
  }
}
