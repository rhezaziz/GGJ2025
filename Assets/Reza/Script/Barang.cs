using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barang : MonoBehaviour, IObject
{
    // Data Barang
    public int level;
    public int exp;
    public int ScaleObj;
    public bool active;

    public float jarak;
    Transform objBubble;
    Transform[] obj;
    // Rigidbody2D rb;


    // void Awake(){
    //     rb = GetComponent<Rigidbody2D>();
    // }
    void Start(){
        objBubble = FindObjectOfType<Bubble>().transform;
    }
    // void Update(){
    //     if(active){
    //         float distance = Vector2.Distance(transform.position, objBubble.position);

    //         if(distance <= jarak){
    //             Action();
    //         }
    //     }
    // }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Bubble")){
            Action();
        }
    }

    void Action(){
        int levelBubble = objBubble.GetComponent<Bubble>().mLevel;
        bool bigger = level > levelBubble;


        switch(bigger){
            case true:
                Damage(objBubble.gameObject);
                break;

            case false:
                Food();
                break;
        }
        
    }

    #region Interface Object
    public void Damage(GameObject obj){
        var bubble = obj.GetComponent<IBubble>();

        bubble.GetDamage();
    }

    public void Food(){
        var bubble = objBubble.GetComponent<IBubble>();

        bubble.eat();
        gameObject.SetActive(false);
    }

    #endregion
}
