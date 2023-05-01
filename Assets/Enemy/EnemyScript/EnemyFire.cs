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
        GameObject arrow = Instantiate(Arrow, transform.position, Quaternion.identity);
        Rigidbody arrowRb = arrow.GetComponent<Rigidbody>();

        Quaternion currentRotation = transform.rotation;
        arrow.transform.rotation = Quaternion.LookRotation(currentRotation * Vector3.forward);
        // ��΂����������߂�B�uforward�v�́uz���v�����������i�|�C���g�j
        arrowRb.AddForce(transform.forward * speed);

        // �R�b��ɍ폜����B
        Destroy(arrow, 3.0f);
    }

    
}
