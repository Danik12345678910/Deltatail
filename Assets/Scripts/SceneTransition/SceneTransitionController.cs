using UnityEngine.SceneManagement;

sealed public class SceneTransitionController
{
    public void Transition(in Scene scene) => SceneManager.LoadScene(scene.name);

    public void Transition(in string sceneName) => SceneManager.LoadScene(sceneName);
}