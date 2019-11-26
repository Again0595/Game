using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontrol : MonoBehaviour
{
    public Playercharacter character;
    bool jump;
    bool jump2 = false;
    bool transColor;
    void Awake()
    {
        character = FindObjectOfType<Playercharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!character.isAlive) return;




        if (Application.isMobilePlatform)
        {
            transColor = false;
            jump = false;
            jump2 = false;
            if (Input.GetMouseButtonDown(0) && Input.mousePosition.x > (Screen.width / 2))//当手指触碰屏幕
            {
                jump = true;
                jump2 = true;
            }

            else if (Input.GetMouseButtonDown(0) && Input.mousePosition.x < (Screen.width / 2))//当手指触碰屏幕
            {
                transColor = true;
            }

            else if (Input.GetMouseButton(0))
            {
                jump2 = true;
            }

        }

        else
          {

            jump = Input.GetKeyDown(KeyCode.UpArrow);
            jump2 = Input.GetKey(KeyCode.UpArrow);
            transColor = Input.GetKeyDown(KeyCode.Space);
           }



        character.Move();
        

        if (jump)
        {
            character.Jump();
        }
        if (!jump2)
        {
            character.Gravity();
        }

        if (transColor)
        {
            character.ChangeColor();
        }
    }
}
