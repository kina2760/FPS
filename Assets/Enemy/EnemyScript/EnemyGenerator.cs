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
    base_Eneymy_Position = (10,0);

    Spawn_Position_Rotation = 
    Quaternion.Eular(0,Random.Range(0,180),0) * base_Enemy_Position;

    enemy_Spawn_Position = player.position + Spawn_Position_Rotation;
    

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
