using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCamera : MonoBehaviour
{ 
    private Vector3 previousPosition; // �O�t���[���̃J�����ʒu���L�����邽�߂̕ϐ�
    private Quaternion previousRotation; // �O�t���[���̃J������]���L�����邽�߂̕ϐ�
    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("PauseCamera: GameManager��������܂���ł����B");
            enabled = false; // ���̃X�N���v�g�𖳌��ɂ���
        }
    }

    // ���t���[���Ăяo�����֐�
    void Update()
    {
        // GameManager��isPause��true�̏ꍇ�A�J�����̈ʒu�Ɖ�]��O�t���[���̒l�ɖ߂�
        if (gameManager.isPause)
        {
            transform.position = previousPosition;
            transform.rotation = previousRotation;
        }
        // GameManager��isPause��false�̏ꍇ�A�J�����̈ʒu�Ɖ�]���X�V����
        /*
        else
        {
            previousPosition = transform.position;
            previousRotation = transform.rotation;
        }
        */
    }
}
