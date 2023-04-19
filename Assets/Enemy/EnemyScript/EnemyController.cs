using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    Transform player;
    Animator animator;
    //プレイヤー認識用
    public void Setplayer(Transform player)
    {
        this.player = player;
    }
    //走る用関数
    public void Run(float dist)
    {
        if (dist < RunRange)
        {
            animator.SetBool("Discover", true);
            Attack(dist);
        }
        else
        {
            animator.SetBool("Discover", false);
        }
    }
    //攻撃モーション用関数
    public void Attack(float dist)
    {
        if (dist < AttackRange)
        {
            animator.SetBool("Engage", true);
        }
        else
        {
            animator.SetBool("Engage", false);
        }
    }
    //倒れる処理//将来的に使うかもしれないもの   
   /* public void Delite(int hp)
    {
        if (hp <= 0)
        {
            animator.SetTrigger("dead");
            
        }    
    }
*/

    //範囲(値=メートル)
    public float traceDist = 30.0f;//とりあえずゾンビのプレイヤーを認識する距離20m
    public float RunRange = 10.0f;  //ゾンビが走り始める距離15m
    public float AttackRange = 5.0f;//殴る用の距離

    NavMeshAgent nav;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        StartCoroutine(CheckDist());
    }

    IEnumerator CheckDist()
    {
        while(true)
        {
            //1秒間に10回発見判定
            yield return new WaitForSeconds(0.1f);
            float dist =
                Vector3.Distance
                (player.position, transform.position);           
            //索敵範囲に入りましたか?
            if (dist < traceDist)
            {
                //プレイヤーの位置を目的値に設定
                nav.SetDestination(player.position);
                nav.isStopped = false;
                Run(dist);
            }
            else
            {
                nav.isStopped = true;
            }
        }
    }
}
