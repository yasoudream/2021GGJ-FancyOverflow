using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MonoController : MonoBehaviour
{
    private event UnityAction updateEvent;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (updateEvent != null)
            updateEvent();
    }

    public void AddUpdateListener(UnityAction action)
    {
        updateEvent += action;
    }
    public void RemoveUpdateListener(UnityAction action)
    {
        updateEvent -= action;
    }

    public void Clear()
    {
        updateEvent = null;
    }

    public void DestroyOtherObject(Object obj)
    {
        Destroy(obj);
    }
}
