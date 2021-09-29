using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class EventManager
{ 
    private static List<Listener> _eventList = new List<Listener>();  

    public static void Trigger<T>(T paramToSend) where T : struct
    {
        foreach(var el in _eventList)
        {            
            if (el.Type == typeof(T))
            {
                ((IListener<T>)el.ListenerObj).EMCallEvent(paramToSend);
            }
        }
    }

    public static void AddListener<T>(IListener listener) where T: struct
    {         
        foreach(var el in _eventList)
        {
            var hashCode = el.ListenerObj.GetHashCode();
            var hashCodeToReg = listener.GetHashCode();
            if (el.Type == typeof(T) && hashCode == hashCodeToReg)
            {
                throw new Exception("There already is a listener for the same event");                
            }
        }
        
        _eventList.Add(new Listener(listener, typeof(T)));        
    }
    
    public static void RemoveListener<T>(IListener listener) where T : struct
    {
        foreach (var el in _eventList)
        {
            var hashCode = el.ListenerObj.GetHashCode();
            var hashCodeToReg = listener.GetHashCode();
            if (el.Type == typeof(T) && hashCode == hashCodeToReg)
            {
                _eventList.Remove(el);
                return;
            }
        }
        
    }
}
