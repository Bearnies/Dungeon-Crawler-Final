using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string firstLevel;

    public GameObject optionScreen; 

    public GameObject LoadingScreen, loadingIcon;

    public Text loadingText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        //SceneManager.LoadScene(firstLevel);
        StartCoroutine(LoadStart());
    }

    public void OpenOptions()
    {
        optionScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        optionScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public IEnumerator LoadStart()
    {
        LoadingScreen.SetActive(true);
        AsyncOperation asyncLoad= SceneManager.LoadSceneAsync(firstLevel);
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
                }
            }

            yield return null;
        }
    }
}
