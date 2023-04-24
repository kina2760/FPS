using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameManager gameManager;
    // �e�̃G�t�F�N�g
    //public GameObject effect;
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

    // �e�̓����蔻�菈��
    void OnCollisionEnter(Collision collision)
    {
        // �Փ˂����I�u�W�F�N�g���G�ł���ꍇ
        if (collision.gameObject.tag == "Enemy")
        {
            // �G��j�󂷂�
            Destroy(collision.gameObject);
            GameManager.Count++;

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
