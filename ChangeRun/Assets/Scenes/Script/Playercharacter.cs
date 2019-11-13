using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercharacter : MonoBehaviour
{
    public enum TransColor
    {
        Red,
        Green,
        Undefine,
    }

    Rigidbody rigid;//获取人物刚体
    Renderer render;//获取人物渲染
    Animator ani;//获取动画
    Collision collisionRet;//获取碰撞物体
    TransColor colorCurrent;//人物现在的颜色

    public float speed;//人物速度
    public float firstjump;//一段跳
    public float secondjump;//二段跳
    public float SpeedUp;//加速度
    
    public bool isAlive;//判断是否死亡


    public ParticleSystem particleRed;//红色尾气动画
    public ParticleSystem particleGreen;//绿色尾气动画
    public ParticleSystem particleDie;//死亡动画
    public AudioClip jumpClip;//跳跃音效
    public AudioClip transClip;//变色音效

    int jumpcount = 0;//记录跳跃次数
    bool isGround;//地面检测
    float StartSpeed;//初始速度

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        render = GetComponentInChildren<Renderer>();//因为Randerer组件在Player的子节点上，所以使用获取孩子
        ani = GetComponentInChildren<Animator>();

        render.material.color = Color.red;//人物默认颜色变为红色
        colorCurrent = TransColor.Red;

        particleRed.gameObject.SetActive(true);//播放红色尾气动画
        particleGreen.gameObject.SetActive(false);//停止播放绿色尾气动画
        particleDie.Stop();//死亡动画初始为停止

        isAlive = true;
        StartSpeed = speed;
    }

    private void FixedUpdate()
    {
        if (!isAlive) return;
        Debug.Log(rigid.velocity.z);
        if (collisionRet != null)//碰撞结果不为空
        {
            if (collisionRet.gameObject.CompareTag("Red"))//碰到红色物体
            {
                if (colorCurrent != TransColor.Red)
                {
                    Die();
                }
            }
            else if (collisionRet.gameObject.CompareTag("Green"))//碰到绿色物体
            {
                if (colorCurrent != TransColor.Green)
                {
                    Die();
                }
            }
            else if (collisionRet.gameObject.CompareTag("Undefine"))//碰到黑色物体
            {
                Die();
            }
        }

        if (transform.position.y < -20)
        {
            Die();
        }

        isGround = GroundCheck();
        if (isGround)
        {

            SwitchDustWithState();
        }
        else
        {
            particleRed.gameObject.SetActive(false);
            particleGreen.gameObject.SetActive(false);
        }

   
            ani.SetBool("isGround", isGround);

        if (rigid.velocity.z > 25)//加速的最大值
        {
            SpeedUp = -3;
            firstjump = 16;
            secondjump = 16;
        }
        
        if (rigid.velocity.z < StartSpeed)//减速到原来的速度
        {
            SpeedUp = 0;
            firstjump = 12;
            secondjump = 12;
        }
    }
    public void Move()//人物移动
    {
        if (!isAlive) return;
        
        speed += SpeedUp * Time.deltaTime;
        var vel = rigid.velocity;//获取人物速度
        vel.z = (Vector3.forward * speed).z;//只让人物向前移动，z轴
        rigid.velocity = vel;
    }

    public void Jump()//人物跳跃
    {
        if (!isAlive) return;
        if (jumpcount < 2)
        {
            if (jumpcount == 0 || isGround)
            {
                rigid.velocity = new Vector3(rigid.velocity.x,0, rigid.velocity.z);
                rigid.AddForce(Vector3.up * firstjump, ForceMode.Impulse);
            }
            else if (jumpcount == 1 || isGround)
            {
                rigid.velocity = new Vector3(rigid.velocity.x, 0, rigid.velocity.z);
                rigid.AddForce(Vector3.up * secondjump, ForceMode.Impulse);
                
            }
            jumpcount++;
            ani.SetBool("isFalling", false);
        }
        
    }

    public void Gravity()//没有长按跳跃键，增加下坠的重力
    {
        rigid.AddForce(Vector3.down * 0.5f, ForceMode.Impulse);
        ani.SetBool("isFalling", true);
    }

    public bool GroundCheck()//地面检测
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);//自身为中心，画一个碰撞球，求内的所有碰撞器的集合
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)//要把自身排除掉
            {
                return true;
            }
        }
        return false;
    }

    public void Die()//人物死亡
    {
        if (!isAlive) return;
        isAlive = false;
        render.enabled = false;
        rigid.velocity = Vector3.zero;
        particleRed.Stop();
        particleGreen.Stop();
        particleDie.Play();
        Invoke("ReStart", 0.5f);//调用重启函数，隔1秒重启游戏
    }

    public void ReStart()//重启游戏
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ChangeRun");
    }

    public void ChangeColor()//人物变色
    {
        if (!isAlive) return;

        if (colorCurrent == TransColor.Green)
        {
            colorCurrent = TransColor.Red;
            render.material.color = Color.red;
        }
        else if (colorCurrent == TransColor.Red)
        {
            colorCurrent = TransColor.Green;
            render.material.color = Color.green;
        }
        SwitchDustWithState();
        ani.SetTrigger("ChangeColor");
        AudioSource.PlayClipAtPoint(transClip, transform.position);

    }

    void SwitchDustWithState()//变色时切换尾气动画
    {
        switch (colorCurrent)
        {
            case TransColor.Green:
                particleGreen.gameObject.SetActive(true);
                particleRed.gameObject.SetActive(false);
                break;
            case TransColor.Red:
                particleGreen.gameObject.SetActive(false);
                particleRed.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)//如果与物体相碰，就会刷新二段跳
    {
        jumpcount = 0;
        collisionRet = collision;//获取碰撞的物体
    }

    private void OnCollisionStay(Collision collision)
    {
        collisionRet = collision;
    }

    private void OnCollisionExit(Collision collision)
    {
        collisionRet = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Speed up"))//如果穿过加速道具，加速
        {
            SpeedUp = 15;
 
        }
    }
}


