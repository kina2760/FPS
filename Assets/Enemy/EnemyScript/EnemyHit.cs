using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{

    //�I�u�W�F�N�g�ƐڐG�����u�ԂɌĂяo�����
    public int damage;

    //�R���C�_�[�������葱����HP����u�łȂ��Ȃ�Ȃ��悤���G���Ԃ�݂���
    private bool isInvincible = false;
    public float invincibleTimer = 2.0f;

    void OnTriggerEnter(Collider other)
    {
        if (isInvincible)
        {
            return; // ���G��ԂȂ�_���[�W���󂯂Ȃ�
        }

        //�U���������肪Enemy�̏ꍇ
        if (other.CompareTag("Player"))
        {
            MyStatus ms = other.gameObject.GetComponent<MyStatus>();
            if (ms != null)
            {
                ms.Hp -= damage;
            }

            isInvincible = true;
            Invoke("ResetInvincibility", invincibleTimer);

        }
    }

    void ResetInvincibility()
    {
        isInvincible = false;
    }

}
