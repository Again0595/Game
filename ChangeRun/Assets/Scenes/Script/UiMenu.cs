using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiMenu : MonoBehaviour
{
    public Button back;
    public Button first;

    void Start()
    {
        back.onClick.AddListener(Back);
        first.onClick.AddListener(First);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Back()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
    }

    void First()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ChangeRun");
    }
}
