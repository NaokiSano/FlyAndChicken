using UnityEngine;
using System.Collections;

public class ScoreSingleton<T> where T : class, new(){

    private static volatile T m_instance;
    private static object m_sync_obj = new object();

    /***** ジェネリックなインスタンス *****/
    public static T Instance
    {
        get
        {
            if(m_instance == null)
            {
                lock(m_sync_obj)
                {
                    if(m_instance == null)
                    {
                        m_instance = new T();
                    }
                }
            }
            return m_instance;
        }
    }

    // コンストラクタ
    protected ScoreSingleton() { }
}
