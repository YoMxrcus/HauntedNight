using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BookReaderUI : MonoBehaviour
{
    public GameObject panel;          // BookPanel
    public Image bookImage;           // BookImage
    public TextMeshProUGUI text;      // Story Text (TMP)

    // property so other scripts can ask "is it open?"
    public bool IsOpen
    {
        get { return panel != null && panel.activeSelf; }
    }

    void Awake()
    {
        if (panel != null)
            panel.SetActive(false);   // start hidden
    }

    public void ShowBook(Sprite sprite, string story)
    {
        if (bookImage != null && sprite != null)
            bookImage.sprite = sprite;

        if (text != null)
            text.text = story;

        if (panel != null)
            panel.SetActive(true);
    }

    public void HideBook()
    {
        if (panel != null)
            panel.SetActive(false);
    }
}
