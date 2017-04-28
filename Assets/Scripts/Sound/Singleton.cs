using UnityEngine;

public class Singleton<T> where T : class, new()
{//Singleton() { }
    private static T obj = null;
    public static T instance
    {
        get
        {
            if (obj == null)
                obj = new T();
            return obj;
        }
    }
}
