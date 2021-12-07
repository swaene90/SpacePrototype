using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public GameObject menuPanel;

    // Start is called before the first frame update
    void Start()
    {
        menuPanel.SetActive(false);
    }

    // Update is called once per frame


    public void onContinueButton()
    {
        Time.timeScale = 1;
        menuPanel.SetActive(false);
    }

    public void onRestartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void onExitButton()
    {
        Application.Quit();
    }

}
