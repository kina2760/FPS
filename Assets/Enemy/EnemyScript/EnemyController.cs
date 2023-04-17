using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    Transform player;
    Animator animator;

    public void Setplayer(Transform player)
    {
        this.player = player;
    }

    //���G�͈�(�l=���[�g��)
    public float traceDist = 20.0f;//�Ƃ肠�����]���r�̃v���C���[��F�����鋗��20m
    public float RunRange = 15.0f;  //�]���r������n�߂鋗��
    public float AttackRange = 1.0f;//����p�̋���
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
            //1�b�Ԃ�10�񔭌�����
            yield return new WaitForSeconds(0.1f);
            float dist =
                Vector3.Distance
                (player.position, transform.position);
            //���G�͈͂ɓ���܂�����?
            if(dist<traceDist)
            {
                //�v���C���[�̈ʒu��ړI�l�ɐݒ�
                nav.SetDestination(player.position);
                nav.isStopped = false;
                if (dist < RunRange)
                {
                    animator.SetBool("Discover",true);
                }
                else
                {
                    animator.SetBool("Discover",false);
                }
            }
            else
            {
                nav.isStopped = true;
            }
            if (dist < AttackRange)
            {
                animator.SetTrigger("Engage");
            }
        }
    }
}
