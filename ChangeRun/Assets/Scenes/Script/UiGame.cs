using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UiGame : MonoBehaviour
{
    public bool IsGamePaused;//游戏暂停条件
    public Canvas gameui;//游戏ui
    public AudioSource back;//背景音乐
    public AudioSource Jump;//跳跃音效
    public AudioSource Tran;//变颜色音效
    public AudioSource Die;//跳跃音效
    public Button re;//开始按钮
    public Button exit;//退出按钮
    public Slider slider;//背景音乐滑动条
    public Slider slider2;//音效滑动条
    float t;//记录音乐的暂停时间
    //CanvasGroup canvasgroup;
    void Start()
    {
        //canvasgroup = GetComponentInChildren<CanvasGroup>();
        gameui.enabled = false;

        exit.onClick.AddListener(Exitchick);
        re.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {

                PauseGame();

        }
        back.volume = slider.value;
        Jump.volume = slider2.value;
        Tran.volume = slider2.value;
        Die.volume = slider2.value;

}



    void StartGame()
    {
        IsGamePaused = false;
        Time.timeScale = 1;
        gameui.enabled = false;//ui开始关闭
        back.time = t;
        back.Play();
        //canvasgroup.alpha = 0;
        //canvasgroup.interactable = false;
        //canvasgroup.blocksRaycasts = false;
    }
    void PauseGame()
    {
        IsGamePaused = true;
        Time.timeScale = 0;
        gameui.enabled = true;//开启ui
        t = back.time;
        back.Stop();
        //canvasgroup.alpha = 1;
        //canvasgroup.interactable = true;
        //canvasgroup.blocksRaycasts = true;
    }

    void Exitchick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
        Time.timeScale = 1;
    }

 
}
