using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : EnemyController
{
    NavMeshAgent nav;
    Transform player;
    Animator animator;
    AudioSource source;

    //範囲(値=メートル)
    public float traceDist = 30.0f;//�Ƃ肠�����]���r�̃v���C���[��F�����鋗��20m
    public float RunRange = 10.0f;  //�]���r������n�߂鋗��15m
    public float AttackRange = 5.0f;//����p�̋���
    public AudioClip SE1;

    /*
    private Collider leftHandCollider;
    private Collider rightHandCollider;
    */

    private bool isInvincible = false;

    
    //SE
    /*
    public void SE()
    {
        EnemySoundEffect.instance.PlaySE();
    }
    */
    /*
    public void SE()
    {
        source.PlayOneShot(SE1);
    }
    */


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
            /*
            leftHandCollider.enabled = true;
            rightHandCollider.enabled = true;
            Invoke("ColliderReset", 1.5f);
            */
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



    void Start()
    {
        
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        

        //敵の攻撃の当たり判定を取得
        /*
        leftHandCollider = GameObject.Find("Base HumanLArmPalm").GetComponent<CapsuleCollider>();
        rightHandCollider = GameObject.Find("Base HumanRArmPalm").GetComponent<CapsuleCollider>();
        */
        //Setplayer(player);

        StartCoroutine(CheckDist());

    }

    IEnumerator CheckDist()
    {
        while (true)
        {
            //1�b�Ԃ�10�񔭌�����
            yield return new WaitForSeconds(0.1f);
            if (isInvincible)
            {
                yield break;
            }
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null)
            {
                transform.LookAt(p.transform);
            }
            /*
             if (p == null)
            {
                continue;
            }
            if (nav.enabled)
            {
                nav.SetDestination(p.transform.position);
            }
             */

            float dist =
                Vector3.Distance
                (p.transform.position, transform.position);
            //���G�͈͂ɓ���܂�����?
            if (dist < traceDist)
            {
                //�v���C���[�̈ʒu��ړI�l�ɐݒ�
                nav.SetDestination(p.transform.position);
                nav.isStopped = false;
                //SE();
                Run(dist);
            }
            else
            {
                nav.isStopped = true;
            }
            //           SE();
        }
    }

    public override void TakeDamage(int damage)
    {

        if (isInvincible)
        {
            return; // 無敵状態ならダメージを受けない、死んだら無敵にする
        }
        base.TakeDamage(damage);
        Hp -= damage;
        if (Hp <= 0)
        {
            animator.SetTrigger("dead");
            isInvincible = true;
            Destroy(gameObject, 3.0f);
            base.GameManager.Count++;
        }

    }

}