using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    float countup = 0.0f;
    public Text timeText;
    public Text scoreText;
    
    //�Q�[���N���A���ɕ\�������L�����o�X�i���Canvas���\���ɂ��Ă����j
    [SerializeField]
    Canvas gameClearCanvas = null;

    //�Q�[���I�[�o�[���ɕ\�������L�����o�X�i���Canvas���\���ɂ��Ă����j
    [SerializeField]
    Canvas gameOverCanvas = null;

    [SerializeField]
    Canvas Canvas_playerst;

    //�G�̌��j��
    [SerializeField]
    Text countText = null;

    //�G�̌��j�ڕW
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


    void Start()
    {
        count = 0;
        UpdateCountText();
        //StartCoroutine("CountScore");
    }

    /*IEnumerator CountScore()
    {
        countup += Time.deltaTime;
        timeText.text = "Score" + " " + countup.ToString("f0");

        if()
    }*/

    void Update()
    {
        //�J�E���g�A�b�v�̏���
        countup += Time.deltaTime;
        timeText.text = "Score" + " " + countup.ToString("f0");
        //�N���Aor�Q�[���I�[�o�[���Ɏ��Ԃ��~�߂�
        if (isGameClear || isGameOver)
        {
            Time.timeScale = 0;
            scoreText.text = "Score" + " " + countup.ToString("f0");
            return;
        }
    }

    public void GameClear()
    {
        if(isGameClear || isGameOver)
        {
            return;
        }


        //�N���A��̏���
        //freezeUpdate = true;
        //�Q�[���N���AUI�̕\��
        gameClearCanvas.enabled = true;
        //�N���A��Ƀv���C���[UI���\��
        Canvas_playerst.enabled = false;
        //�J�[�\���\��������
        Cursor.lockState = CursorLockMode.None;
        //�e��̗N���~�߂�
        


        isGameClear = true;
    }

    public void GameOver()
    {
        if(isGameClear || isGameOver)
        {
            return;
        }

        // �Q�[���I�[�o�[��̏���
        //freezeUpdate = true;
        //�Q�[���I�[�o�[UI�̕\��
        gameOverCanvas.enabled = true;
        //�Q�[���I�[�o�[��Ƀv���C���[UI���\��
        Canvas_playerst.enabled = false;
        //�J�[�\���\��������
        Cursor.lockState = CursorLockMode.None;
         
        isGameOver = true;
    }

    public void Retry()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void UpdateCountText()
    {
        countText.text = count.ToString() + "/" + maxCount.ToString();
    }
}
