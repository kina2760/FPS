using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KariController_OKU : MonoBehaviour
{
/*    CharacterController cc;*/

    void Start()
    {
/*        //�L�����R���擾
        cc = GetComponent<CharacterController>();*/
    }

    void Update()
    {
        transform.Rotate(
        0,
        Input.GetAxis("Horizontal") * 90 * Time.deltaTime,
        0
        );

        transform.Translate(
        0,
        0,
        Input.GetAxis("Vertical") * 5.0f * Time.deltaTime);

        /*        //�����̐؂�ւ�
                transform.Rotate(Vector3.up * Input.GetAxis("Horizontal"));
                //�ړ�
                cc.SimpleMove(transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * 36.0f);*/
    }
}
