using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiHelp : MonoBehaviour
{

    public AudioSource back;
    public Slider slider;
    public Button re;

    void Start()
    {

        re.onClick.AddListener(Re);
    }

    void Update()
    {
        back.volume = slider.value;
    }

    public void Re()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
    }
}
