using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/*
SE�֘A���ЂƂ܂��R�����g�A�E�g 
�P�̂̉����̂ݓK����
 */


public class EnemyController_gob : MonoBehaviour
{


    NavMeshAgent nav;
    Transform player;
    Animator animator;
    AudioSource source;
    EnemyFire ef;

    //�͈�(�l=���[�g��)
    public float traceDist = 30.0f;//�Ƃ肠�����]���r�̃v���C���[��F�����鋗��20m
    public float RunRange = 15.0f;  //�]���r������n�߂鋗��15m
    public float AttackRange = 12.0f;//����p�̋���
    public AudioClip SE1;

    public int hp;


    private bool isInvincible = false;

    //�]���r��|�������ɃJ�E���g���邽�߂�gameManager��ǉ�
    GameManager gameManager;
    GameManager GameManager
    {
        get
        {
            if (gameManager == null)
            {
                gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
            }
            return gameManager;
        }
    }
    //SE
    /*
    public void SE()
    {
        EnemySoundEffect.instance.PlaySE();
    }
    */
    public void SE()
    {
        source.PlayOneShot(SE1);
    }

//�v���C���[�F���p
    public void Setplayer(Transform player)
    {
        this.player = player;
    }
    //����p�֐�
    public void Run(float dist)
    {
        if (dist < RunRange)
        { 
            animator.SetBool("Discover", true);
        }
        else
        {
            animator.SetBool("Discover", false);
        }
    }
    /*�U�����[�V�����p�֐�
    public void Attack(float dist)
    {
        if (dist < AttackRange)
        {
            animator.SetTrigger("Engage");
            ef.fire();
        }
        else
        {
            //animator.SetBool("Engage", false);
        }
    }
    */

    //�|��鏈��//�����I�Ɏg����������Ȃ�����   
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
    nav = GetComponent<NavMeshAgent>();
    animator = GetComponent<Animator>();
    source = GetComponent<AudioSource>();
    //�|�ɃA�^�b�`�����X�N���v�g�����o��
    ef = GameObject.Find("Goblin Necro Bow Quiver").GetComponent<EnemyFire>();
        
    StartCoroutine(CheckDist());
        StartCoroutine(Arrow());

    }

    IEnumerator CheckDist()
    {
        while(true)
        {
            //1�b�Ԃ�10�񔭌�����
            yield return new WaitForSeconds(0.1f);
            

            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null)
            {
                transform.LookAt(p.transform);
            }
            float dist =
                Vector3.Distance
                (p.transform.position, transform.position);
            //�U�����͒�~������A���G�͈͂ɓ���܂�����?
            if (dist < AttackRange)
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            else if (dist < traceDist)
            {
                //�v���C���[�̈ʒu��ړI�l�ɐݒ�
                nav.SetDestination(p.transform.position);
                nav.isStopped = false;
                SE();
                Run(dist);
            }
            else
            {
                nav.isStopped = true;
            }
//           SE();
        }
    }

    IEnumerator Arrow()
    {
        while (true)
        {
            //2�b�Ԃ�1�񔭌�����
            yield return new WaitForSeconds(2.0f);
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null)
            {
                transform.LookAt(p.transform);
            }
            float dist =
                Vector3.Distance
                (p.transform.position, transform.position);
            if (dist < AttackRange)
            {
                animator.SetTrigger("Engage");
                
                ef.Fire();
            }
           
        }
    }

    //��ےǋL hp�v���p�e�B
    public int Hp
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }
   

    //�_���[�W�����A0�ɂȂ����玀�S�A�j����3�b�ŏ�����
    public void TakeDamage(int damage)
    {
        if (isInvincible)
        {
            return; // ���G��ԂȂ�_���[�W���󂯂Ȃ��A���񂾂疳�G�ɂ���
        }
        Hp -= damage;
        if (Hp <= 0)
        {
            animator.SetTrigger("dead");
            isInvincible = true;
            Destroy(gameObject, 3.0f);
            GameManager.Count++;
        }
    }

}
