using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CustomSceneManager : SingletonBase<CustomSceneManager>
{
    public void LoadScene(string name, UnityAction action)
    {
        SceneManager.LoadScene(name);
        if (action != null)
            action();
    }

    public void LoadSceneAysn(string name, UnityAction action)
    {
        MonoManager.GetInstance().StartCoroutine(LoadSceneAsync_R(name, action));
    }

    private IEnumerator LoadSceneAsync_R(string name, UnityAction action)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(name);
        while (!ao.isDone)
        {
            EventCenter.GetInstance().EventTrigger(name + "Loading", ao.progress);
            yield return ao.progress;
        }
        if (action != null)
            action();
        yield return 0;
    }
}
