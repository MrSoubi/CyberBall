using UnityEngine;
using UnityEngine.Events;
public class AvatarWindow : MonoBehaviour
{
    //[Header("Settings")]

    [Header("References")]
    [SerializeField] private RSO_GameParameter rsoGameParameter;

    //[Space(10)]
    // RSO
    // RSF
    // RSP

    //[Header("Input")]
    //[Header("Output")]
    [SerializeField] private UnityEvent nextWindow;

    private void OnEnable()
    {
        Debug.Log(rsoGameParameter.Value.is_avatar_selection_enabled);
        if (!rsoGameParameter.Value.is_avatar_selection_enabled)
        {
            nextWindow.Invoke();
        }
    }

    public void SetAvatarWithIndex(int index)
    {
        rsoGameParameter.Value.avatar_selection = (avatar)index;
    }
}