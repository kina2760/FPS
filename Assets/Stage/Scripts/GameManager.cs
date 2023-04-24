using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float countup = 0.0f;
    public Text timeText;

    //[SerializeField]
    //MoveBehaviour moveBehaviour = null;
    
    //�Q�[���N���A���ɕ\�������L�����o�X�i���Canvas���\���ɂ��Ă����j
    [SerializeField]
    Canvas gameClearCanvas = null;

    //�Q�[���I�[�o�[���ɕ\�������L�����o�X�i���Canvas���\���ɂ��Ă����j
    [SerializeField]
    Canvas gameOverCanvas = null;

    //�Q�[���X�R�A��UI�i�b���j
    [SerializeField]
    Text countText = null;

    //�Q�[���̃N���A����
    [SerializeField, Min(1)]
    int maxCount = 5;

    bool isGameClear = false;
    bool isGameOver = false;
    int count = 0;

    public int Count
    {
        set
        {
            count = Mathf.Max(value, 0);
            UpdateCountText();
            if (count >= maxCount)
            {
                GameClear();
            }
        }
        get
        {
            return count;
        }
    }

    //�]���r�̗N��������N���A�����ɐݒ肷��ꍇ��
    //public GameObject zombie;
    //EnemyGenerator script;
    //int maxCount = script.limit;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        UpdateCountText();
    }

    // Update is called once per frame
    void Update()
    {
        //�J�E���g�A�b�v�̏���
        countup += Time.deltaTime;
        timeText.text = countup.ToString("f0") + "�b";
        Debug.Log(isGameClear);
      
    }

    public void GameClear()
    {
        if(isGameClear || isGameOver)
        {
            return;
        }


        //�N���A��̏���
        gameClearCanvas.enabled = true;
        //�e��̗N���~�߂�
        //�v���C���[�~�߂�
        //moveBehaviour.enabled = false;
       // Cursor.lockState = CursorLockMode.None;

        isGameClear = true;
    }

    public void GameOver()
    {
        if(isGameClear || isGameOver)
        {
            return;
        }
        
         // �Q�[���I�[�o�[��̏���
         //playerController.enabled = false;
         gameOverCanvas.enabled = true;
         //Cursor.lockState = CursorLockMode.None;
         
        isGameOver = true;
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
    public void UpdateCountText()
    {
        countText.text = count.ToString() + "/" + maxCount.ToString();
    }
}
