using UnityEngine;

public class GameMapManager : MonoBehaviour
{
    [SerializeField] GameObject[] objectsToActivate;

    [SerializeField] RSE_LaunchSession rseLaunchSession;
    [SerializeField] RSE_BallCounterMax rseBallCounter;
    
    private void OnEnable()
    {
        rseLaunchSession.action += StartGame;
        rseBallCounter.action += EndSession;
    }
    private void OnDisable()
    {
        rseLaunchSession.action -= StartGame;
        rseBallCounter.action -= EndSession;
    }

    void StartGame()
    {
        for (int i = 0; i < objectsToActivate.Length; i++)
        {
            objectsToActivate[i].SetActive(true);
        }
    }

    void EndSession()
    {
        for (int i = 0; i < objectsToActivate.Length; i++)
        {
            objectsToActivate[i].SetActive(false);
        }
    }
}
