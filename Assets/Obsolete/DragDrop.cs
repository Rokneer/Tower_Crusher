using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private Vector2 mousePosition;
    private Vector2 spritePosition;
    public Vector2 defaultPosition;

    private bool isDragging = false;

    private Color spriteAlpha;

    [SerializeField] private SnapZones snap;

    private void Start()
    {
        defaultPosition = transform.localPosition;
        spriteAlpha = GetComponent<SpriteRenderer>().color;
    }

    private void OnMouseDown()
    {
        //Debug.Log("Mouse Down");
        isDragging = true;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spritePosition = transform.localPosition;
        spriteAlpha.a = 0.4f;
    }
    private void OnMouseDrag()
    {
        //Debug.Log("Dragging");
        if (isDragging)
        {
            transform.localPosition = spritePosition + ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - mousePosition);
        }
    }
    private void OnMouseUp()
    {
        //Debug.Log("Mouse Up");
        isDragging = false;
        snap.DragEnd();
    }
    public void DefaultPosition()
    {
        transform.localPosition = defaultPosition;
    }
}

