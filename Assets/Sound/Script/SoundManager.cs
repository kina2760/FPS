using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    //�X���C�_�[���K�v�Ȃ̂�
    public Slider slider;

    //System.�Ő錾���鎖�ŁA�C���X�y�N�^�[����l���Z�b�g�ł���B
    [System.Serializable]
    public class SoundData
    {
        public string name;         //�C���X�y�N�^�[�Ŗ��O�����Ă�
        public AudioClip audioClip; //�󂯎�鉹
        public float playedTime;    //�O��Đ���������
        public float Volume = 0.1f;   //�{�����[���Ǘ����\��
    }

    [SerializeField]
    private SoundData[] soundDatas;

    //AudioSource�i�X�s�[�J�[�j�𓯎��ɖ炵�������̐������p��(20�͑���������łƂ肠����10�܂Ō��炵��)
    private AudioSource[] audioSourceList = new AudioSource[10];

    //�ʖ�(name)���L�[�Ƃ����Ǘ��pDictionary
    private Dictionary<string, SoundData> soundDictionary = new Dictionary<string, SoundData>();

    //��x�Đ����Ă���A���Đ��o����܂ł̊Ԋu(����0.2�b)
    [SerializeField]
    private float playableDistance = 0.2f;

    //����ς�X�^�e�B�b�N���g���ƁA���Œ�`���鎞�ƂĂ��ȒP�B
    public static SoundManager instance;

    private void Awake()
    {

        //�V���O���g���p�^�[��
        if (instance == null)
        { 
            //auidioSourceList�z��̐�����AudioSource���������g�ɐ������Ĕz��Ɋi�[
            for (var i = 0; i < audioSourceList.Length; ++i)
            {
                audioSourceList[i] = gameObject.AddComponent<AudioSource>();
                
                Debug.Log("�E������");
            }

            //soundDictionary�ɃZ�b�g
            foreach (var soundData in soundDatas)
            {
                soundDictionary.Add(soundData.name, soundData);
            }
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //���g�p��AudioSource�̎擾 �S�Ďg�p���̏ꍇ��null��Ԃ�
    private AudioSource GetUnusedAudioSource()
    {
        for (var i = 0; i < audioSourceList.Length; ++i)
        {
            if (audioSourceList[i].isPlaying == false) return audioSourceList[i];
        }
        Debug.Log("���g�p��AudioSource�͌�����܂���ł���");
        return null; //���g�p��AudioSource�͌�����܂���ł���
    }

    //�w�肳�ꂽAudioClip�𖢎g�p��AudioSource�ōĐ�
    public void Play(AudioClip clip)
    {
        var audioSource = GetUnusedAudioSource();
        if (audioSource == null) return; //�Đ��ł��܂���ł���
        audioSource.clip = clip;
        audioSource.Play();
    }

    //�w�肳�ꂽ�ʖ��œo�^���ꂽAudioClip���Đ�
    public void Play(string name)
    {
        if (soundDictionary.TryGetValue(name, out var soundData)) //�Ǘ��pDictionary ����A�ʖ��ŒT��
        {
            if (Time.realtimeSinceStartup - soundData.playedTime < playableDistance) return;    //�܂��Đ�����ɂ͑���
            soundData.playedTime = Time.realtimeSinceStartup;//����p�ɍ���̍Đ����Ԃ̕ێ�
            Play(soundData.audioClip); //����������A�Đ�
        }
        else
        {
            Debug.LogWarning($"���̕ʖ��͓o�^����Ă��܂���:{name}");
        }
    }

    //���ʒ�������X���C�_�[�p
    public void SoundSliderOnValueChange(float newSliderValue)
    {


        for (var i = 0; i < audioSourceList.Length; ++i)
        {
            audioSourceList[i].volume = newSliderValue;
            Debug.Log("�ύX������");
        }
    }

}