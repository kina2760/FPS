using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/*
SE�֘A���ЂƂ܂��R�����g�A�E�g 
�P�̂̉����̂ݓK����
 */


public class EnemyController : MonoBehaviour
{


    NavMeshAgent nav;
    Transform player;
    Animator animator;
    AudioSource source;

    //�͈�(�l=���[�g��)
    /*
    public float traceDist;
    public float RunRange;
    public float AttackRange;
    public AudioClip SE1;

    */
    public int hp = 10;

    private Collider leftHandCollider;
    private Collider rightHandCollider;

    private bool isInvincible = false;

    //�]���r��|�������ɃJ�E���g���邽�߂�gameManager��ǉ�
    GameManager gameManager;
    public GameManager GameManager
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
   
//�v���C���[�F���p
    public void Setplayer(Transform player)
    {
        this.player = player;
    }
   
    
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
    public virtual void TakeDamage(int damage)
    {
        
    }

}
