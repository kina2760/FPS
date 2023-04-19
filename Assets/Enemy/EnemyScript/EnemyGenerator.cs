using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public GameObject prehab;
    public Transform player;
    public int limit; //�G�̍ő吔�Ǘ����Ă܂��B����10��
    int counter = 0;    //�]���r�̐����Ǘ�����\��ł�

//�����_���z�u�ŃI�u�W�F�N�g�ɏd�Ȃ�Ȃ��悤�ɉ������B
/*

    

 */

    IEnumerator Start()
    {
        while (true)
        {
            //1�b���Ƃ�1�����Ă܂��B
            yield return new WaitForSeconds(1.0f);
            if (counter < limit)
            {

                GameObject enemy = Instantiate(
                //�������A�Q�Ƃ������
                prehab,
                //�������A���W(x,y,z)
                new Vector3(
                    Random.Range(-45f, 45f),
                    Random.Range(1f, 2f),
                    Random.Range(-45f, 45f)
                ),
                //��O�����A����(�f�t�H���g�����̏ꍇ�AQuaternion.identity)
                Quaternion.LookRotation(player.position)
                ) ;
            enemy.GetComponent<EnemyController>().Setplayer(player);
                counter++;
            }
        }
    }
}
