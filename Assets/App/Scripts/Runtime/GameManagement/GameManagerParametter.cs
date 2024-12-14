using Sirenix.OdinInspector;
using UnityEngine;
public class GameManagerParametter : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RSO_GameParametter rsoGameParametter;

    private void OnEnable() => rsoGameParametter.OnChanged += InitializationGame;
    private void OnDisable() => rsoGameParametter.OnChanged -= InitializationGame;

    private void InitializationGame()
    {
        print(rsoGameParametter.ToString());
    }
    
}