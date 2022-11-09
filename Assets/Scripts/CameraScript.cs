using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Texture2D cursor;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursor, new Vector2(16f,16f), CursorMode.ForceSoftware);
    }
}
