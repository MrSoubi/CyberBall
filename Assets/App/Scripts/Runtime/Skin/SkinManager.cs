using UnityEngine;
public class SkinManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SSO_Skins ssoSkins;
    [SerializeField] private RSO_GameParameter rsoGameParameter;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void OnEnable() => SetSkin();

    private void SetSkin() =>
        spriteRenderer.sprite = ssoSkins.skinsData
            .Find(o => o.enumAvatar == rsoGameParameter.Value.avatar_selected).sprite;
}