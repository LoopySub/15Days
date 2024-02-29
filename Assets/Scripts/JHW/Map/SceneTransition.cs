using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    [SerializeField]
    private SceneFader sceneFader;

    void Start()
    {
    }

    public void TransitToNextScene(string SceneName)
    {
        StartCoroutine(TransitionCoroutine(SceneName));
    }

    IEnumerator TransitionCoroutine(string SceneName)
    {
        float fadeTime = sceneFader.BeginFade(1);
        yield return new WaitForSeconds(fadeTime);

        SceneManager.LoadScene(SceneName);
    }
}
