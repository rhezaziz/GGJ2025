using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;
public class TestBack : MonoBehaviour
{

    public float timer;
    public float sizeScale;
    public float posY;
    // Start is called before the first frame update
    void Start()
    {
        //LAYER 1
        // .075f
        // -.6F
        //animasi();
    }

    public void changeValue(){
        transform.DOScale( transform.localScale + (Vector3.one * -.075f), 1f);
        transform.DOMoveY(transform.position.y + -.6f, 2f);
    }

    void animasi(){
        transform.DOScale(Vector2.one * sizeScale, timer);
        transform.DOMoveY(posY, timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
