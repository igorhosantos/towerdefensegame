using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Build;
#endif

public class GradientScript : MonoBehaviour
{
    [SerializeField] private Color[] colors = { Color.blue, Color.red };

    private void Awake ()
    {
        CreateGradient();
    }

    /// <summary>
    /// Change gradient colors. 0 index holds topmost color.
    /// </summary>
    public void SetColors(Color[] newColors)
    {
        colors = newColors;
        CreateGradient();
    }

#if UNITY_EDITOR

    internal void OnValidate()
    {
        if (Application.isPlaying)// || BuildUtils.IsBuildingBundles)
            return;

        CreateGradient();
    }

    [ContextMenu("UpdateEvent gradient")]
    private void UpdateGradient()
    {
        CreateGradient();
    }

#endif

    private void CreateGradient()
    {
        var colorsAmount = colors.Length;
        var texture2D = new Texture2D(1, colorsAmount);

        for (int i = 0; i < colorsAmount; i++)
            texture2D.SetPixel(0, colorsAmount - i - 1, colors[i]);

        texture2D.filterMode = FilterMode.Bilinear;
        texture2D.wrapMode = TextureWrapMode.Clamp;
        texture2D.Apply();

        var sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), 0.5f * Vector2.one, 100);

        SetSprite(sprite);
    }

    private void SetSprite(Sprite sprite)
    {
        var targetImage = GetComponent<Image>();
        if (targetImage == null)
        {
            var targetRenderer = GetComponent<SpriteRenderer>();
            if (targetRenderer == null)
            {
                var targetMask = GetComponent<SpriteMask>();
                targetMask.sprite = sprite;
            }
            else
            {
                targetRenderer.sprite = sprite;
            }
        }
        else
        {
            targetImage.sprite = sprite;
        }
    }
}
