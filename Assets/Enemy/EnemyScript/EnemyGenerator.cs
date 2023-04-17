using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public GameObject prehab;
    public Transform player;
    public int limit; //�G�̍ő吔�Ǘ����Ă܂��B����10��
    int counter = 0;    //�]���r�̐����Ǘ�����\��ł�

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
            Quaternion.identity
            );
            enemy.GetComponent<EnemyController>().Setplayer(player);
                counter++;
            }
        }
    }
}
