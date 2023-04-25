using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bloodEffect;
    public GameObject decalHitWall;
    Shooter ss;

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
    // �e�̃G�t�F�N�g
    //public GameObject effect;

    void Start()
    {
        ss = GameObject.Find("Shooter").GetComponent<Shooter>();
    }

    // �e�̓����蔻�菈��
    void OnCollisionEnter(Collision collision)
    {
        // �Փ˂����I�u�W�F�N�g���G�ł���ꍇ
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyController ec = collision.gameObject.GetComponent<EnemyController>();
            if (ec != null)
            {
                ec.TakeDamage(10);
            }
            Destroy(gameObject);
            GameManager.Count++;
            // �G�t�F�N�g���o��
            Instantiate(bloodEffect, transform.position, Quaternion.identity);
        }
        else
        {
            // �e������
            Destroy(gameObject);
            // �G�ȊO�ł�������G�t�F�N�g���o���@
            Instantiate(decalHitWall, transform.position, Quaternion.LookRotation(collision.contacts[0].normal));
        }
        
    }

    // �e�̈ړ�����
    void Update()
    {
        
    }
}

