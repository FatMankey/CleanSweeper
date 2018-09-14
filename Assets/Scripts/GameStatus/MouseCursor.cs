using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    public Texture2D CursorTexture;
    public Texture2D CursorTextureClick;
    public CursorMode CursorMode = CursorMode.Auto;
    public Vector2 HotSpot = Vector2.zero;

    private void Start()
    {
        Cursor.SetCursor(CursorTexture, HotSpot, CursorMode);
        Cursor.visible = !GameObject.FindGameObjectWithTag("Video").activeSelf;
    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(gameObject.CompareTag("Button") ? CursorTexture : CursorTextureClick, HotSpot, CursorMode);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode);
    }

    private void OnMouseUp()
    {
        Cursor.SetCursor(gameObject.CompareTag("Button") ? CursorTextureClick : CursorTexture, HotSpot, CursorMode);
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Video") != null)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.SetCursor(Input.GetMouseButton(0) ? CursorTextureClick : CursorTexture, HotSpot, CursorMode);
            //Cursor.visible = false;
        }
    }
}