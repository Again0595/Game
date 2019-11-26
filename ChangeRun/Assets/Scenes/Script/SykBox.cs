using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SykBox : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RotateSky();
    }
    /// <summary>
    /// 天空盒旋转
    /// </summary>
    public void RotateSky()
    {
        //（前提 摄像机标签为MainCamera）
        float num = Camera.main.GetComponent<Skybox>().material.GetFloat("_Rotation");
        Camera.main.GetComponent<Skybox>().material.SetFloat("_Rotation", num + 0.05f);
    }


}
