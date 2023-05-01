using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public GameObject gameManager;
    GameManager gm;

    [SerializeField]
    int point;

    string[] ranking = { "�����L���O1��", "�����L���O2��", "�����L���O3��", "�����L���O4��", "�����L���O5��" };

    int dif = DifficultyButton.difficulty -1;

    //[SerializeField]
    //string[,] ranking = new string[4,5];
    [SerializeField]
    Text[,] rankingText = new Text[4,5];
    [SerializeField]
    float[,] rankingValue = new float[4,5];


    // Use this for initialization
    void Start()
    {
        gm = gameManager.GetComponent<GameManager>();

        GetRanking();

        SetRanking(gm.countup);

        for (int i = 0; i < rankingText.Length; i++)
        {
            rankingText[dif,i].text = rankingValue[dif,i].ToString();
        }
    }

    /// <summary>
    /// �����L���O�Ăяo��
    /// </summary>
    void GetRanking()
    {

        //�����L���O�Ăяo��
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[dif,i] = PlayerPrefs.GetInt(ranking[i]);
        }
    }
    /// <summary>
    /// �����L���O��������
    /// </summary>
    void SetRanking(float _value)
    {
        //�������ݗp
        for (int i = 0; i < ranking.Length; i++)
        {
            //�擾�����l��Ranking�̒l���r���ē���ւ�
            if (_value < rankingValue[dif,i])
            {
                var change = rankingValue[dif,i];
                rankingValue[dif,i] = _value;
                _value = change;
            }
        }

        //����ւ����l��ۑ�
        for (int i = 0; i < ranking.Length; i++)
        {
            PlayerPrefs.SetFloat(ranking[i], rankingValue[dif,i]);
        }
    }
}