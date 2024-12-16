using UnityEngine;
using UnityEngine.UI;

public class Micro : MonoBehaviour
{
    [SerializeField] Sprite on, off;
    bool isOn = true;

    [SerializeField] Image microImage;

    [SerializeField] RSE_SetActiveMicro rseActiveMicro;

    private void OnEnable()
    {
        rseActiveMicro.action += SetActiveMicro;
    }
    private void OnDisable()
    {
        rseActiveMicro.action -= SetActiveMicro;
    }

    void SetActiveMicro(bool active)
    {
        gameObject.SetActive(active);
    }

    public void OnClick()
    {
        isOn = !isOn;
        microImage.sprite = isOn ? on : off;
    }
}
