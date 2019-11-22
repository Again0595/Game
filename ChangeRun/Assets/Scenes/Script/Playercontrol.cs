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
 

    
        
        character.Move();
        

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            character.Jump();
        }
        else if (!Input.GetKey(KeyCode.UpArrow))
        {
            character.Gravity();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            character.ChangeColor();
        }
    }
}
