using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject prehab;
     IEnumerator Start()
     {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            Instantiate(
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
        }
    }

}
