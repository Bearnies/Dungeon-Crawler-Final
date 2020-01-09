using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject optionScreen, pauseScreen;
    public string mainMenuSceen;

    public bool isPause;

    public GameObject LoadingScreen, loadingIcon;

    public Text loadingText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    public void PauseUnpause()
    {
        if (!isPause)
        {
            pauseScreen.SetActive(true);
            isPause=true;

            Time.timeScale=0f;
        }
        else
        {
            pauseScreen.SetActive(false);
            isPause=false;
            Time.timeScale=1f;
        }
    }

    public void OpenOptions()
    {
        optionScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        optionScreen.SetActive(false);
    }

    public void QuitToMain()
    {
        //SceneManager.LoadScene(mainMenuSceen);
        //Time.timeScale=1f;

        StartCoroutine(LoadMain());
    }

    public IEnumerator LoadMain()
    {
        LoadingScreen.SetActive(true);
        AsyncOperation asyncLoad= SceneManager.LoadSceneAsync(mainMenuSceen);
        asyncLoad.allowSceneActivation=false;
        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress>=0.9f)
            {
                loadingText.text="Press any key to continue";
                loadingIcon.SetActive(false);

                if (Input.anyKeyDown)
                {
                    asyncLoad.allowSceneActivation=true;
                    Time.timeScale=1f;
                }
            }

            yield return null;
        }
    }
}
