using UnityEngine;
public class SkinManager : MonoBehaviour
{
    [Header("Settings")] 
    public bool isPlayer;
    public int iDCharacter;

    [Header("References")]
    [SerializeField] private SSO_Skins ssoSkins;
    [SerializeField] private RSO_GameParameter rsoGameParameter;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        SetSkin();
    }

    private void SetSkin()
    {
        
    }
}