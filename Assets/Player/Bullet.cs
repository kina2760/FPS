using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // �e�̃G�t�F�N�g
    //public GameObject effect;

    // �e�̓����蔻�菈��
    void OnCollisionEnter(Collision collision)
    {
        // �Փ˂����I�u�W�F�N�g���G�ł���ꍇ
        if (collision.gameObject.tag == "Enemy")
        {
            // �G��j�󂷂�
            Destroy(collision.gameObject);

            // �G�t�F�N�g���o��
            //Instantiate(effect, transform.position, Quaternion.identity);
        }

        // �e������
        Destroy(gameObject);
        // �G�ȊO�ł�������G�t�F�N�g���o���@
        //Instantiate(effect, transform.position, Quaternion.identity);
    }

    // �e�̈ړ�����
    void Update()
    {
        
    }
}
