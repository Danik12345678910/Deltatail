using System;
using UnityEngine.SceneManagement;

public class SceneTransitionController : MonoBehaviourService
{
    public void Transition(Scene scene)
    {
        SceneManager.LoadScene(scene.name);
    }

    public void Transition(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public override Type ServiceType => GetType();
}