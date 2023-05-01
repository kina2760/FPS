using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject Arrow;
    public float speed;
    public bool rotateTowardsPlayer = true;

    private Quaternion initialRotation;
    void Start()
    {
        // ��̏����̌�����ۑ����Ă���
        initialRotation = Arrow.transform.rotation;
    }
    public void Fire()
    {
        Invoke("Fire2", 0.5f);
     
    }

    void Fire2()
    {
        GameObject arrow = Instantiate(Arrow, transform.position, Quaternion.identity);
        Rigidbody arrowRb = arrow.GetComponent<Rigidbody>();

        // ��΂����������߂�B�uforward�v�́uz���v�����������i�|�C���g�j
        arrowRb.AddForce(transform.forward * speed);

        
            arrow.transform.rotation = initialRotation;
        

        // �R�b��ɍ폜����B
        Destroy(arrow, 3.0f);
    }

    
}
