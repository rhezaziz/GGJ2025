
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TestBack : MonoBehaviour
{

    public float timer;
    public float sizeScale;
    public float posY;

    public Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        //LAYER 1
        // .075f
        // -.6F
        //animasi();
    }

    public void changeValue(int level){
        if(level <= 2){
            mengecilBackground();
            return;
        }
        else{
            mengecilParent();
            return;
        }
    }

    void mengecilBackground(){
        transform.DOScale(transform.localScale + (Vector3.one * -.075f), 1f);
        transform.DOMoveY(transform.position.y + -.6f, 2f);
    }

    void mengecilParent(){
        Debug.Log("Mengecil");
        foreach(Transform child in parent.GetComponentsInChildren<Transform>()){
            if(child.name != parent.name){
                child.DOScale(child.localScale + (Vector3.one * -.05f), 1f);
            }

        }
    }

    void animasi(){
        transform.DOScale(Vector2.one * sizeScale, timer);
        transform.DOMoveY(posY, timer);
    }

    Transform objAnim(int level){
        if(level <= 2){
            return transform;
        }
        else{
            return parent.transform;
        }
    }
}
