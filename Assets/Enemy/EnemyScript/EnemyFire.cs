using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject Arrow;
    public float speed;


    public void Fire()
    {
        Invoke("Fire2", 0.5f);
     
    }

    void Fire2()
    {
        GameObject arrow = Instantiate(Arrow, transform.position, Quaternion.Euler(90, 0, 0));

        Rigidbody arrowRb = arrow.GetComponent<Rigidbody>();

        // �~�T�C�����΂����������߂�B�uforward�v�́uz���v�����������i�|�C���g�j
        arrowRb.AddForce(transform.forward * speed);

        // �R�b��ɓG�̃~�T�C�����폜����B
        Destroy(arrow, 3.0f);
    }

    
}
