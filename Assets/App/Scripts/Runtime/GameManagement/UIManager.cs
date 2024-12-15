using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject welcomeWindowsGO;
    [SerializeField] GameObject chatGO;

    [SerializeField] RSE_LaunchSession rseLaunchSession;
    [SerializeField] RSE_BallCounterMax rseBallCounter;

    private void OnEnable()
    {
        rseLaunchSession.action += StartGame;
        rseBallCounter.action += EndGame;
    }
    private void OnDisable()
    {
        rseLaunchSession.action -= StartGame;
        rseBallCounter.action -= EndGame;
    }

    void StartGame()
    {
        welcomeWindowsGO.SetActive(false);
        chatGO.SetActive(true);
    }
    void EndGame()
    {
        welcomeWindowsGO.SetActive(false);
        chatGO.SetActive(false);
    }
}
