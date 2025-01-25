using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Drag : MonoBehaviour
{
    bool onDrag = false;

    SpriteRenderer sprite;
    void OnMouseDown(){
        onDrag = true;
    }

    private void OnMouseUp()
    {
        onDrag = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //if (dragObject)
        float direction = GetMousePos().x - transform.position.x;

        if(direction > 0){
            sprite.flipX = false;
        }else if(direction < 0){
            sprite.flipX = true;
        }
        transform.position = GetMousePos();

        //transform.DOScale(new Vector2(2.5f, 1.25f), 0.5f);
    }

    Vector3 GetMousePos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
