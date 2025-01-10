using UnityEngine;
using UnityEngine.Events;
public class AvatarWindow : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject normalPanel;
    [SerializeField] private GameObject malePanel;
    [SerializeField] private GameObject femalePanel;
    [Space(10)]
    [SerializeField] private RSO_GameParameter rsoGameParameter;

    [Header("Output")]
    [SerializeField] private UnityEvent nextWindow;

    private void OnEnable()
    {
        if (!rsoGameParameter.Value.is_avatar_selection_enabled)
        {
            nextWindow.Invoke();
        }

        switch (rsoGameParameter.Value.avatar_selection)
        {
            case avatar.LIBRE:
                normalPanel.SetActive(true); 
                break;
            case avatar.HOMMEHYPERSEXUALISE:
                malePanel.SetActive(true);
                break;
            case avatar.FEMMEHYPERSEXUALISE:
                femalePanel.SetActive(true);
                break;
            default: break;
        }
    }

    public void SetAvatarWithIndex(int index)
    {
        rsoGameParameter.Value.avatar_selected = (avatar_selected)index;
    }
}