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
    Transform player;
    /*
    NavMeshAgent nav;
    
    Animator animator;
    AudioSource source;
    */

    //�͈�(�l=���[�g��)
    /*
    public float traceDist;
    public float RunRange;
    public float AttackRange;
    */
    public int hp = 10;

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
    
//�v���C���[�F���p(���������񂩂��AGenerator�ƈꏏ�ɏ���
    public void Setplayer(Transform player)
    {
        this.player = player;
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
   
    public virtual void TakeDamage(int damage)
    {
        
    }

}
