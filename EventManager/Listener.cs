using System;
using System.Collections;
using System.Collections.Generic;


public class Listener
{
    public IListener ListenerObj;
    public Type Type;

    public Listener(IListener listener, Type type)
    {
        ListenerObj = listener;
        Type = type;
    }
}
