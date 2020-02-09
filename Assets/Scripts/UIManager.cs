using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField]
    Text Diamond;
    [SerializeField]
    Text Steps;

    [SerializeField]
    GameObject GameOverCanvas;
    [SerializeField]
    Text FinalResult;

    private int diamondCount;
    private int stepsCount;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
    }

    public void PlayerGetDiamond()
    {
        diamondCount++;
        Diamond.text = diamondCount.ToString();
    }

    public void PlayerSteps()
    {
        stepsCount++;
        Steps.text = stepsCount.ToString();
    }

    public void GameOver()
    {
        GameOverCanvas.SetActive(true);
        FinalResult.text = Steps.text;
    }

    public void OnClickReplay()
    {
        SceneManager.LoadScene(0);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
