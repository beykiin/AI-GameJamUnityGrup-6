using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Color normalColors;
    public Color hoverColors = new Color(1f, 1f, 1f, 1f);
    private TMP_Text buttonText;

    void Start()
    {
        buttonText = GetComponentInChildren<TMP_Text>();
        normalColors = buttonText.color;
    }

    
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = hoverColors;
    }

    
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = normalColors;
    }
}
