using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercharacter : MonoBehaviour
{
    Rigidbody rigid;//获取人物刚体
    Renderer render;//获取人物渲染
    Animator ani;//获取动画
    Collision collisionRet;//获取碰撞器

    public float speed;
    public float firstjump;
    public float secondjump;

    int jumpcount = 0;
    bool isGround;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        render = GetComponentInChildren<Renderer>();//因为Randerer组件在Player的子节点上，所以使用获取孩子
        ani = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        isGround = GroundCheck();

        ani.SetBool("isGround", isGround);
    }
    public void Move()//人物移动
    {
        var vel = rigid.velocity;//获取人物速度
        vel.z = (Vector3.forward * speed).z;//只让人物向前移动，z轴
        rigid.velocity = vel;
    }

    public void Jump()//人物跳跃
    {
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
                ani.SetTrigger("Double");
            }
            jumpcount++;
        }
    }

    public void Gravity()//没有长按跳跃键，增加下坠的重力
    {
        rigid.AddForce(Vector3.down * 1f, ForceMode.Impulse);
        ani.SetTrigger("Falling");
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

    }

    public void ChangeColor()//人物变色
    {

    }

    private void OnCollisionEnter(Collision collision)//如果与物体相碰，就会刷新二段跳
    {
        jumpcount = 0;
        collisionRet = collision;
    }

    private void OnCollisionStay(Collision collision)
    {
        collisionRet = collision;
    }

    private void OnCollisionExit(Collision collision)
    {
        collisionRet = null;
    }
}


