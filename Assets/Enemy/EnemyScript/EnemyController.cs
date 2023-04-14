using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    //���G�͈�(�l=���[�g��)
    public float traceDist = 20.0f;//�Ƃ肠����20m
    NavMeshAgent nav;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
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
            }
            else
            {
                nav.isStopped = true;
            }
        }
    }
}
