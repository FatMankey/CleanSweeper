using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    public Texture2D CursorTexture;
    public Texture2D CursorTextureClick;
    public CursorMode CursorMode = CursorMode.ForceSoftware;
    public Vector2 HotSpot = Vector2.zero;

    private void OnMouseEnter()
    {
        Cursor.SetCursor(CursorTexture, HotSpot, CursorMode);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode);
    }

    private void OnMouseDown()
    {
        Cursor.SetCursor(CursorTextureClick, HotSpot, CursorMode);
    }
}