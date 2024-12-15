using UnityEngine;
using UnityEngine.Events;
public class AvatarWindow : MonoBehaviour
{
    //[Header("Settings")]

    [Header("References")]
    [SerializeField] private RSO_GameParameter rseGameParameter;

    //[Space(10)]
    // RSO
    // RSF
    // RSP

    //[Header("Input")]
    //[Header("Output")]
    [SerializeField] private UnityEvent nextWindow;

    private void OnEnable()
    {
        Debug.Log(rseGameParameter.Value.is_avatar_selection_enabled);
        if (!rseGameParameter.Value.is_avatar_selection_enabled)
        {
            nextWindow.Invoke();
        }
    }
}