using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool freezeUpdate = false;
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
        //StartCoroutine("CountScore");
    }

    /*IEnumerator CountScore()
    {
        countup += Time.deltaTime;
        timeText.text = "Score" + " " + countup.ToString("f0");

        if()
    }*/
    // Update is called once per frame
    void Update()
    {
        //�J�E���g�A�b�v�̏���
        countup += Time.deltaTime;
        timeText.text = "Score" + " " + countup.ToString("f0");
        if (freezeUpdate) return;
      
    }

    public void GameClear()
    {
        if(isGameClear || isGameOver)
        {
            return;
        }


        //�N���A��̏���
        freezeUpdate = true;
        //�Q�[���N���AUI�̕\��
        gameClearCanvas.enabled = true;
        //�J�[�\���\��������
        Cursor.lockState = CursorLockMode.None;
        //�e��̗N���~�߂�
        //�v���C���[�~�߂�


        isGameClear = true;
    }

    public void GameOver()
    {
        if(isGameClear || isGameOver)
        {
            return;
        }

        // �Q�[���I�[�o�[��̏���
        freezeUpdate = true;
        //�Q�[���I�[�o�[UI�̕\��
        gameOverCanvas.enabled = true;
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
