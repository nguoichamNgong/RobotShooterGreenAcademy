using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoadingSceneController : MonoBehaviour
{
    public Slider slider;
    public GameObject loadingPanel;

    void Start()
    {
        string targetScene = PlayerPrefs.GetString("TargetScene", "MainLevel");
        StartCoroutine(LoadAsync(targetScene));
    }

    IEnumerator LoadAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        loadingPanel.SetActive(true);
        float fakeProgress = 0f;

        while (!operation.isDone)
        {
            float target = Mathf.Clamp01(operation.progress / 0.9f);
            fakeProgress = Mathf.MoveTowards(fakeProgress, target, Time.deltaTime * 1f);
            slider.value = fakeProgress;

            if (fakeProgress >= 1f && operation.progress >= 0.9f)
            {
                yield return new WaitForSeconds(0.3f);
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
