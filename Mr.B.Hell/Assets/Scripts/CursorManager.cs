using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] Sprite cursorSprite;
    [SerializeField] SpriteRenderer spriteRenderer;

    Vector2 cursorPos;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        spriteRenderer.sprite = cursorSprite;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cursorPos;
    }

    public void SetCursorPos(Vector2 pos) => cursorPos = pos;
}
