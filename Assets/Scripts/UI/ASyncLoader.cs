//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
//using System.Collections;

//public class ASyncLoader : MonoBehaviour
//{
//    [Header("Menu Screens")]
//    [SerializeField] private GameObject loadingScreen;
//    [SerializeField] private GameObject mainMenu;

//    [Header("Slider")]
//    [SerializeField] private Slider loadingSlider;

//    public void LoadLevel1Btn(string levelToLoad)
//    {
//        mainMenu.SetActive(false);
//        loadingScreen.SetActive(true);

//        StartCoroutine(LoadLevelASync(levelToLoad));
//    }

//    IEnumerator LoadLevelASync(string levelToLoad)
//    {
//        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);
//        loadOperation.allowSceneActivation = false;

//        float targetProgress = 0;

//        while (!loadOperation.isDone)
//        {
//            if (loadOperation.progress < 0.9f)
//            {
//                targetProgress = Mathf.Clamp01(loadOperation.progress / 0.9f);
//            }
//            else
//            {
//                targetProgress = 1.0f;
//            }

//            loadingSlider.value = Mathf.MoveTowards(loadingSlider.value, targetProgress, Time.deltaTime);
//            Debug.Log($"progress: {loadOperation.progress}, slider: {loadingSlider.value}");

//            if (loadingSlider.value >= 1.0f && loadOperation.progress >= 0.9f)
//            {
//                loadOperation.allowSceneActivation = true;
//            }

//            yield return null;
//        }
//    }

//}
