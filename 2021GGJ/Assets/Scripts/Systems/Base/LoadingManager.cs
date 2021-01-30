using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoadingManager : SingletonBase<LoadingManager>
{
    public T Load<T>(string name) where T: Object
    {
        T res = Resources.Load<T>(name);
        if (res is GameObject)
            return GameObject.Instantiate(res);
        else
            return res;
    }

    public void LoadAsync<T>(string name, UnityAction<T> callback) where T : Object
    {
        MonoManager.GetInstance().StartCoroutine(LoadAsync_R(name, callback));
    }

    private IEnumerator LoadAsync_R<T>(string name, UnityAction<T> callback) where T :Object
    {
        ResourceRequest r = Resources.LoadAsync<T>(name);
        yield return r;
        if (r.asset is GameObject)
        {
            GameObject obj = GameObject.Instantiate(r.asset) as GameObject;
            if (callback != null)
                callback(obj as T);
        }
        else
        {
            if (callback != null)
                callback(r.asset as T);
        }
    }

}
