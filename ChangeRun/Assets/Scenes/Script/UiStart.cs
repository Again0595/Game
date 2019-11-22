using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UiStart : MonoBehaviour
{
    public Button start;
    public Button help;
    public Button exit;
    void Start()
    {
        start.onClick.AddListener(Startchick);
        exit.onClick.AddListener(Exitchick);
        help.onClick.AddListener(Helpchick);
    }

    
    void Update()
    {
        
    }

    public void Startchick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ChangeRunone");
    }

    public void Exitchick()
    {
        Application.Quit();
    }
    public void Helpchick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Help");
    }
}
