using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager Instance;

    public GameObject LoadingPanel;
    public float MinLoadTime;

    public GameObject guadanaLoading;
    public float guadanaSpeed;

    private string targetScene;
    private bool isLoading;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        LoadingPanel.SetActive(false);
    }

    public void LoadScene(string sceneName)
    {

        targetScene = sceneName;
        StartCoroutine(LoadSceneRoutine());
    }

    private IEnumerator LoadSceneRoutine()
    {
        isLoading = true;
        Time.timeScale = 1f;

        LoadingPanel.SetActive(true);
        StartCoroutine(SpinGuadanaRoutine());

        AsyncOperation op = SceneManager.LoadSceneAsync(targetScene);
        float elapsedLoadTime = 0f;

        while(!op.isDone)
        {
            elapsedLoadTime += Time.deltaTime;
            yield return null;
        }
            

        while (elapsedLoadTime < MinLoadTime)
        {
            elapsedLoadTime += Time.deltaTime;
            yield return null;
        }

        LoadingPanel.SetActive(false);

        isLoading = false;
    }

    private IEnumerator SpinGuadanaRoutine()
    {
        while(isLoading)
        {
            guadanaLoading.transform.Rotate(0, 0, -guadanaSpeed);
            yield return null;
        }
    }
}
