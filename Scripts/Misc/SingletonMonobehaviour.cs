using UnityEngine;

// herhangi bir zamanda bir singleton'un yalnızca bir örneğinin var olmasını sağlar.

public abstract class SingletonMonobehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            return instance;
        }
    }

    protected virtual void Awake()
    {
        // herhangi bir zamanda bu Singleton nesnelerinden yalnızca birinin var olmasını istiyorum.
        if (instance == null) // örnek mevcut değilse
        {
            // T tipi olarak örneği başlatacağım
            instance = this as T;
        }
        else
        {
            // örnek mevcutsa, bununla ilgili oyun nesnesini yok edeceğim
            Destroy(gameObject);
        }
    }
}
