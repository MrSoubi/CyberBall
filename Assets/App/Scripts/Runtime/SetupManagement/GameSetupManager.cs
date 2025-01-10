using Sirenix.OdinInspector;
using UnityEngine;
public class GameSetupManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RSO_GameParameter rsoGameParameter;

    [Header("Output")]
    [SerializeField] private RSE_SetupQTE rseSetupQTE;
    [SerializeField] private RSE_SetupBot rseSetupBot;
    [SerializeField] private RSE_SetupChat rseSetupChat;
    [SerializeField] private RSE_SetActiveMicro rseSetActiveMicro;

    private void OnEnable() => rsoGameParameter.OnChanged += InitializationGame;
    private void OnDisable() => rsoGameParameter.OnChanged -= InitializationGame;

    private void InitializationGame()
    {
        rseSetupBot.Call();
        rseSetupQTE.Call();
        rseSetupChat.Call();
        rseSetActiveMicro.Call(rsoGameParameter.Value.avatar_selection == avatar.FEMMEHYPERSEXUALISE);
    }
}