using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject instructions;
    public GameObject startButton;

    public void OnStartButtonClicked()
    {
        instructions.SetActive(false);
        startButton.SetActive(false);
        GameMng.Instance.StartGame();
    }
}