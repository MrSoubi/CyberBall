using Sirenix.OdinInspector;
using UnityEngine;
public class GameManagerParameter : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RSO_GameParameter rsoGameParameter;

    private void OnEnable() => rsoGameParameter.OnChanged += InitializationGame;
    private void OnDisable() => rsoGameParameter.OnChanged -= InitializationGame;

    private void InitializationGame()
    {
        
    }
    
}