using UnityEngine;
using System;
using System.Collections.Generic;

public class EventBus : MonoBehaviour
{
    private readonly Dictionary<Type, Delegate> _listeners = new Dictionary<Type, Delegate>();

    public void Subscribe<T>(Action<T> listener)
    {
        Type type = typeof(T);
        
        _listeners.TryAdd(type, listener);
    }
    
    public void Unsubscribe<T>(Action<T> listener)
    {
        Type type = typeof(T);

        if (_listeners.ContainsKey(type))
        {
            _listeners[type] = Delegate.Remove(_listeners[type], listener);
        }
    }

    public void Raise<T>(T eventArgs)
    {
        Type type = typeof(T);
        if (_listeners.TryGetValue(type, out var del) && del is Action<T> action)
        {
            action.Invoke(eventArgs);
        }
    }
}
