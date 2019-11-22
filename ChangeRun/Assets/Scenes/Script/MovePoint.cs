using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint : MonoBehaviour
{
    public float speed;
    public float hight;

    Vector3 startpos;
    
    void Awake()
    {
        startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
        //超出范围
        if (transform.position.y >= hight || transform.position.y <= startpos.y)
        {
            //反向
            speed = -speed;
        }
       // transform.position = new Vector3(startpos.x, Mathf.PingPong(Time.time * speed, hight), startpos.z);
    }
}
