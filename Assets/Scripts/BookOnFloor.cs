using UnityEngine;

public class BookOnFloor : MonoBehaviour
{
    public Sprite bookSprite;
    [TextArea(4, 10)]
    public string storyText;

    public BookReaderUI bookUI;
    public float interactDistance = 2f;

    void Update()
    {
        if (bookUI == null) return;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= interactDistance && Input.GetKeyDown(KeyCode.E))
        {
            // if it's already open, close it
            if (bookUI.IsOpen)
            {
                Debug.Log("Closing book from " + gameObject.name);
                Time.timeScale = 1;
                bookUI.HideBook();
            }
            // if it's closed, open it with this book's data
            else
            {
                Time.timeScale = 0;
                Debug.Log("Opening book from " + gameObject.name);
                bookUI.ShowBook(bookSprite, storyText);
            }
        }
    }
}
