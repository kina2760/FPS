using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    MyStatus script;

    //�A�C�e������
    public GameObject bulletPrefab; //�A�C�e���̃v���n�u�@Asset/Stage/Prefabs/Bullet2(1)
    public float itemSpawnTime;     //�A�C�e���̃X�|�[������
    GameObject[] bulletArray;       //���������A�C�e��������z��
    public float itemLimit;         //�A�C�e���̐������

    //�]���r����
    public GameObject enemyPrefab;  //�G�̃v���n�u�@Asset/Enemy/Prehab/Enemy
    public Transform player;        //�v���C���[�̈ʒu�H�H
    public float enemySpawnTime;    //�G�̏o������܂ł̎���
    public int enemyLimit;           //�G�̍ő吔�Ǘ����Ă܂��B����10��
    int enemyCount = 0;            //�]���r�̐����Ǘ�����\��ł�

    float countup = 0f;           //�^�C�}�[�̏����ݒ�
    public Text timeText;           //���ԕ\���̃e�L�X�g
    public Text scoreText;          //�N���A���ɕ\�������X�R�A�̃e�L�X�g
    
    //�Q�[���N���A���ɕ\�������L�����o�X�i���Canvas���\���ɂ��Ă����j
    [SerializeField]
    Canvas gameClearCanvas = null;

    //�Q�[���I�[�o�[���ɕ\�������L�����o�X�i���Canvas���\���ɂ��Ă����j
    [SerializeField]
    Canvas gameOverCanvas = null;

    //�Q�[���v���C���ɕ\������UI�̃L�����o�X
    [SerializeField]
    Canvas Canvas_playerst;

    [SerializeField]
    Canvas Pause;

    [SerializeField]
    Canvas Resume;

    //�G�̌��j��
    [SerializeField]
    Text countText = null;

    //�G�̌��j�ڕW
    [SerializeField, Min(1)]
    int maxCount = 5;

    //�G�̌��j���̏����ݒ�
    int count = 0;

    //�Q�[���I���̃t���O
    bool isGameClear = false;
    bool isGameOver = false;

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
        bulletArray = GameObject.FindGameObjectsWithTag("Bullet");

        StartCoroutine("GenerateItem");
        StartCoroutine("GanarateEnemy");

        //count = 0;
        
        int def = DifficultyButton.difficulty; //�^�C�g���V�[������difficulty�̐������擾
        
        script = playerPrefab.GetComponent<MyStatus>();
        //��Փx�ݒ荀��
        switch (def)
        {
            case 1:�@//Easy
                maxCount = 5;
                enemyLimit = 10;
                enemySpawnTime = 5;
                itemLimit = 5;
                itemSpawnTime = 5;
                break;

            case 2: //Normal
                maxCount = 10;
                enemyLimit = 20;
                enemySpawnTime = 4;
                itemLimit = 4;
                itemSpawnTime = 4;
                break;

            case 3: //Hard
                maxCount = 15;
                enemyLimit = 30;
                enemySpawnTime = 3;
                itemLimit = 3;
                itemSpawnTime = 3;
                break;
            case 4: //Hell
                maxCount = 30;
                enemyLimit = 50;
                enemySpawnTime = 1;
                itemLimit = 3;
                itemSpawnTime = 3;
                script.hp = 50;
                break;
        }

        Debug.Log(DifficultyButton.difficulty);
        Debug.Log(maxCount);
        UpdateCountText();

    }
   
    //�A�C�e�������R���[�`��
    IEnumerator GenerateItem()
    {
        while (true)
        {
            bulletArray = GameObject.FindGameObjectsWithTag("Bullet");
            //Debug.Log(bulletArray.Length);
            if (bulletArray.Length < itemLimit)
            {

                NavMeshHit navMeshHit;
                while (true)
                {
                    float x = Random.Range(-50.0f, 50.0f);
                    float z = Random.Range(-47.0f, 45.0f);
                    Vector3 randomPoint = new Vector3(x, 3.0f, z);
                    if (NavMesh.SamplePosition(randomPoint, out navMeshHit, 2.0f, NavMesh.AllAreas))
                    {
                        break;
                    }
                }

                yield return new WaitForSeconds(itemSpawnTime);
                Instantiate(bulletPrefab, navMeshHit.position, Quaternion.identity);


                /*bulletArray = GameObject.FindGameObjectsWithTag("Bullet");
                Debug.Log(bulletArray.Length);

                while (bulletArray.Length >= itemLimit)
                {
                    yield return new WaitForSeconds(1.0f);
                    bulletArray = GameObject.FindGameObjectsWithTag("Bullet");
                    if (bulletArray.Length < itemLimit)
                    {
                        Debug.Log(bulletArray.Length);
                        break;
                    }
                }*/
            }
            yield return null;
        }

    }

    //�]���r�����R���[�`��
    IEnumerator GanarateEnemy()
    {
        while (true)
        {
            //�w�肵���b�����ɃC���X�^���X����܂��B
            yield return new WaitForSeconds(enemySpawnTime);
            if (enemyCount < enemyLimit)
            {
                float x = Random.Range(-45f, 45f);
                float y = Random.Range(1f, 2f);
                float z = Random.Range(-45f, 45f);
                Vector3 spwonPoint = new Vector3(x, y, z);
                //navMesh.Hit�֐��̓x�C�N�G���A�ɒu����ꍇ�͂��̂܂�
                //�u���Ȃ��ꍇ�́A��ԋ߂��x�C�N�G���A�ɑ�������炵��(�����ǂ�Ȃ̂����œ����Ă邩�킩���)
                if (NavMesh.SamplePosition(spwonPoint, out NavMeshHit navMeshHit, 10.0f, NavMesh.AllAreas))
                {
                    GameObject enemy =
                    Instantiate(enemyPrefab, navMeshHit.position, Quaternion.LookRotation(player.position));
                    enemy.GetComponent<EnemyController>().Setplayer(player);
                    enemyCount++;
                }
            }
        }
    }


    void Update()
    {
        //�J�E���g�A�b�v�̏���
        countup += Time.deltaTime;
        timeText.text = "SCORE" + " " + countup.ToString("f0");

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
        //

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

    //Retry�{�^�����������Ƃ�
    public void Retry()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Stage1");
        
    }

    //Quit�{�^�����������Ƃ�
    public void Quit()
    {
        DifficultyButton.difficulty = 0;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Title");
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        Pause.enabled = false;
        Resume.enabled = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        Pause.enabled = true;
        Resume.enabled = false;
    }

    //�v���C���[UI�̌��j�����X�V
    public void UpdateCountText()
    {
        countText.text = count.ToString() + "/" + maxCount.ToString();
    }
}
