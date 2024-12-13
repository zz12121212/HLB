using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Button loadButton;
    public GameObject transitionImage; 
    public string sceneNameToLoad; 

    private AsyncOperation asyncLoad;
    private bool isLoading = false;

    void Start()
    {
    
        loadButton.onClick.AddListener(OnLoadSceneButtonClick);


        transitionImage.SetActive(false);
    }

    private void OnLoadSceneButtonClick()
    {
        if (!isLoading)
        {if (GameObject.FindWithTag("Player") != null)
            { for (int i = 0; i < 10; i++)
                {
                    GameObject.FindWithTag("Player").GetComponent<CatchItems>().items[i].count = AllTimeValue.Item[i];
                }
            }
            StartCoroutine(LoadSceneWithTransition());
        }
    }

    private IEnumerator LoadSceneWithTransition()
    {
        isLoading = true;


        float transitionDuration = 1.0f; // 过渡动画持续时间
        float elapsed = 0f;

        while (elapsed < transitionDuration)
        {
            float t = elapsed / transitionDuration;
            transitionImage.SetActive(true);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // 异步加载场景
        asyncLoad = SceneManager.LoadSceneAsync(sceneNameToLoad, LoadSceneMode.Single);

        // 等待场景加载完成
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // 隐藏过渡动画
        elapsed = 0f;
        while (elapsed < transitionDuration)
        {
            float t = elapsed / transitionDuration;
            transitionImage.SetActive(false);
            elapsed += Time.deltaTime;
            yield return null;
        }

        isLoading = false;
    }
}
