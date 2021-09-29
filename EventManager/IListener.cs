using System.Collections;
using System.Collections.Generic;

public interface IListener<T> : IListener where T : struct
{
    void EMCallEvent(T arg);  
}

public interface IListener
{
    
}