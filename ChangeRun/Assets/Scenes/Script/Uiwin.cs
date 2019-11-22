using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Uiwin : MonoBehaviour
{
    public Canvas gameui;//游戏ui
    public AudioSource back;//背景音乐
    public Button next;//下一关
    public Button exit;//退出按钮
    public string GameName;
    void Start()
    {
        gameui.enabled = false;
        exit.onClick.AddListener(Exitchick);
        next.onClick.AddListener(Nextchick);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Time.timeScale = 0;
            back.Stop();
            gameui.enabled = true;
        }
    }
    void Exitchick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
        Time.timeScale = 1;
    }

    void Nextchick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(GameName);
        Time.timeScale = 1;
    }
}