using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader2 : MonoBehaviour
{
    public GameObject transitionImage;
    public string sceneNameToLoad;

    private AsyncOperation asyncLoad;
    private bool isLoading = false;

    void Start()
    {

        transitionImage.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject.FindWithTag("Player").GetComponent<CatchItems>().items[i].count = AllTimeValue.Item[i];
            }
            OnLoadSceneButtonClick();
        }
    }



    private void OnLoadSceneButtonClick()
    {
        if (!isLoading)
        {
            StartCoroutine(LoadSceneWithTransition());
        }
    }

    private IEnumerator LoadSceneWithTransition()
    {
        isLoading = true;


        float transitionDuration = 1.0f; // ���ɶ�������ʱ��
        float elapsed = 0f;

        while (elapsed < transitionDuration)
        {
            float t = elapsed / transitionDuration;
            transitionImage.SetActive(true);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // �첽���س���
        asyncLoad = SceneManager.LoadSceneAsync(sceneNameToLoad, LoadSceneMode.Single);

        // �ȴ������������
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // ���ع��ɶ���
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