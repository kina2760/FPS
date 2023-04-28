using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public int shotCount = 50;
    const int MaxShotCount = 100;
    public GameObject bulletPrefab;
    public float shotSpeed;
    private float shotInterval;
    public GameObject muzzelSpawn;
    private GameObject holdFlash;
    GameManager gameManager;

    [SerializeField]
    private SoundManager soundManager; //�T�E���h�}�l�[�W���[

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }


    void Update()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        Animator animator = GetComponentInParent<Animator>();

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (gameManager.isPause)
            {
                return;
            }

            shotInterval += 5 * Time.deltaTime;

            if (shotInterval > 1.0f && shotCount > 0)
            {
                shotCount -= 1;

                if (animator.GetBool("Aim") == false)
                {
                    //�ˌ��G�t�F�N�g
                    holdFlash = Instantiate(muzzelSpawn, transform.position, muzzelSpawn.transform.rotation * Quaternion.Euler(0, 0, 90)) as GameObject;
                    //�e�𐶐�
                    GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
                    Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                    bulletRb.velocity = transform.forward * shotSpeed;
                    shotInterval = 0;
                    //�ˌ�����Ă���3�b��ɏe�e�̃I�u�W�F�N�g��j�󂷂�.

                    Destroy(bullet, 3.0f);
                    //soundManager.Play("player�U��");
                }
                else if (animator.GetBool("Aim"))
                {
                    /*  ���S�ɃJ�����̒��S����ʂ��o���X�N���v�g
                    // �J�����̈ʒu�ƌ������擾����
                    Vector3 cameraPosition = Camera.main.transform.position;
                    Vector3 cameraForward = Camera.main.transform.forward;

                    // �e�̔��ˈʒu���J�����̈ʒu�ɐݒ肷��
                    Vector3 startPos = cameraPosition;

                    // �J�����̌����Ă�������Ɍ������Ĕ��˂���
                    GameObject bullet = Instantiate(bulletPrefab, startPos, Quaternion.identity);
                    Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                    bulletRb.velocity = cameraForward * shotSpeed;
                    shotInterval = 0;
                    Destroy(bullet, 3.0f);
                    */
                    //�ˌ��G�t�F�N�g
                    holdFlash = Instantiate(muzzelSpawn, transform.position, muzzelSpawn.transform.rotation * Quaternion.Euler(0, 0, 90)) as GameObject;

                    //���ˈʒu�ƃJ��������
                    Vector3 startPos = transform.position;
                    Vector3 cameraPosition = Camera.main.transform.forward;
                    //Vector3 shootDirection = (cameraPosition - startPos).normalized;
                    //�e�𐶐�
                    GameObject bullet = Instantiate(bulletPrefab, startPos, Quaternion.identity);
                    Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                    bulletRb.velocity = cameraPosition * shotSpeed;
                    shotInterval = 0;
                    Destroy(bullet, 3.0f);
                    //soundManager.Play("player�U��");
                }
            }
            else if (ShotCount <= 0)
            {
                //soundManager.Play("player�e�؂�");
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            shotInterval = 2.0f;
        }

        /* �����[�h��4.19�ɍ폜�i�c�ʂ̓A�C�e���擾�ŉ�
        else if (Input.GetKeyDown(KeyCode.R))
        {
            shotCount = 30;
        }
        */
       
    }


    public int ShotCount
    {
        get
        {
            return shotCount;
        }
        set
        {
            shotCount = value;
        }
    }

}




