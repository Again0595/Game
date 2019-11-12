using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontrol : MonoBehaviour
{
    public Playercharacter character;
    void Awake()
    {
        character = FindObjectOfType<Playercharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!character.isAlive) return;
        bool jump;
        bool transColor;

        if (Application.isMobilePlatform)
        {
            jump = false;
            transColor = false;
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {

                if (touch.position.x > (Screen.width / 2))
                {
                    jump = true;
                }
                else
                {
                    transColor = true;
                }
            }
        }
        else
        {
            jump = Input.GetKeyDown(KeyCode.UpArrow);
            transColor = Input.GetKeyDown(KeyCode.Space);
        }

        character.Move();

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            character.Jump();
        }
        else if (!Input.GetKey(KeyCode.UpArrow))
        {
            character.Gravity();
        }

        if (transColor)
        {
            character.ChangeColor();
        }
    }
}
