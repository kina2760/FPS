using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifficultyButton : MonoBehaviour
{
    [SerializeField]
//    private SoundManager soundManager; //�T�E���h�}�l�[�W���[�@���^

    public static int difficulty;

    public void ButtonClick(string button)
    {

        Debug.Log((string)button);
        switch (button)
        {
            case "Easy":
                difficulty = 1;
                break;
            case "Normal":
                difficulty = 2;
                break;
            case "Hard":
                difficulty = 3;
                break;
            case "Hell":
                difficulty = 4;
                break;
        }
        //        soundManager.Play("�I��");���^
        SoundManager.instance.Play("�I��");
        Debug.Log(difficulty);
    }
}
