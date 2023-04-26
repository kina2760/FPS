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
    public GameObject difficultyButton;
    
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
        int def = DifficultyButton.difficulty;
        switch (def)
        {
            case 1:
                maxCount = 5;
                break;
            case 2:
                maxCount = 10;
                break;
            case 3:
                maxCount = 15;
                break;

        }
        Debug.Log(DifficultyButton.difficulty);

    }

    /*public void StartGame(int def)
    {
        count = 0;
        UpdateCountText();
        
        switch(def)
        {
            case 1:
                maxCount = 5;
                break;
            case 2:
                maxCount = 10;
                break;
            case 3:
                maxCount = 15;
                break;

        }
    }
    */


    void Update()
    {
        //�J�E���g�A�b�v�̏���
        countup += Time.deltaTime;
        timeText.text = "SCORE" + " " + countup.ToString("f0");
        //�N���Aor�Q�[���I�[�o�[���Ɏ��Ԃ��~�߂�
        //if (isGameClear || isGameOver)
        //{
        //  //Debug.Break();
        //    Time.timeScale = 0.0f;
        //    scoreText.text = "Score" + " " + countup.ToString("f0");
            
        //}
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


        Time.timeScale = 0.0f;
        scoreText.text = "SCORE" + " " + countup.ToString("f0");

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
        Time.timeScale = 0.0f;
        isGameOver = true;
    }

    public void Retry()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Stage1");
        
    }

    public void Quit()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Title");
    }
    public void UpdateCountText()
    {
        countText.text = count.ToString() + "/" + maxCount.ToString();
    }
}
