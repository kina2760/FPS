using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Ranking : MonoBehaviour
{
    public GameObject gameManager;
    //GameManager gm;

    //string[] ranking = { "�����L���O1��", "�����L���O2��", "�����L���O3��", "�����L���O4��", "�����L���O5��" };

    int dif = DifficultyButton.difficulty -1;

    [SerializeField]
    string[,] ranking = new string[5,4];

    //[SerializeField]
    //Text[,] rankingText = new Text[4,5];

    [SerializeField]
    string[,] rankingValue = new string[5, 4];
    //float[,] rankingValue = new float[4,5];

    //[SerializeField]
    //TextArray[] rknm = new TextArray[4];

    //string[,] highScores = new int[5, 4];


    // Use this for initialization
    void Start()
    {
        //gm = gameManager.GetComponent<GameManager>();

        //GetRanking();

        //SetRanking(gm.countup);

        /*for (int i = 0; i < rankingText.GetLength(0); i++)
        {
            rankingText[dif,i].text = rankingValue[dif,i].ToString();
        }*/
        //for (int i = 0; i < rknm.Length; i++)
       // {
       //     rknm[dif].rkText[i].text = rankingValue[dif,i].ToString();
       // }
    }

    /// <summary>
    /// �����L���O�Ăяo��
    /// </summary>
    public void GetRanking()
    {
        //gm = gameManager.GetComponent<GameManager>();

        for (int i = 0; i < rknm.Length; i++)
        {
            rknm[dif].rkText[i].text = rankingValue[dif, i].ToString();
        }


        //�����L���O�Ăяo��
        for (int i = 0; i < rknm.Length; i++)
        {
            rankingValue[dif,i] = PlayerPrefs.GetInt(ranking[dif,i]);
        }
    }
    /// <summary>
    /// �����L���O��������
    /// </summary>
    public void SetRanking(string _value)
    {
        //�������ݗp
        for (int i = 0; i < 5; i++)
        {
            //�擾�����l��Ranking�̒l���r���ē���ւ�
            if (_value < rankingValue[i,dif])
            {
                var change = rankingValue[i,dif];
                rankingValue[i,dif] = _value;
                _value = change;
            }
        }

        //����ւ����l��ۑ�
        for (int i = 0; i < 5; i++)
        {
            string key = "HighScore" + i.ToString() + "-" + dif.ToString();
            PlayerPrefs.SetString(key, rankingValue[i, dif]);
        }
    }

    [System.Serializable]
    public class TextArray
    {
        public Text[] rkText = new Text[5];
    }
}