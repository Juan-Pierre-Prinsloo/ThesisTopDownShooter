using UnityEngine;

public class ClampToScreen : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2f;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2f;
    }

    //This method prevents player from moving off screen
    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;

        //Multiply screenbounds with -1 to get minimum value
        viewPos.x = Mathf.Clamp(viewPos.x, (screenBounds.x * -1 + objectWidth), (screenBounds.x - objectWidth));
        viewPos.y = Mathf.Clamp(viewPos.y, (screenBounds.y * -1 + objectWidth), (screenBounds.y - objectHeight));
        transform.position = viewPos;
    }
}
