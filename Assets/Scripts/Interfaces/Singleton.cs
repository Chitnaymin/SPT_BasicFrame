using System;

public class Singleton<T>
{
    protected static readonly T m_instance = Activator.CreateInstance<T>();
    public static T Instance { get { return m_instance; } }

    protected Singleton() { }

    public virtual void Initialize() { }
}
