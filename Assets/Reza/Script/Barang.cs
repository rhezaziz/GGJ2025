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

    public AudioClip clips;
    AudioSource sound;
    // Rigidbody2D rb;


    void Awake(){
        sound = GetComponent<AudioSource>();
    }

    void Start(){
        if(clips != null){
            sound.PlayOneShot(clips);
        }
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

        if(other.CompareTag("Wall")){
            Destroy(this.gameObject);

        }
    }

    void Action(){
        int levelBubble = FindObjectOfType<Bubble>().mLevel;
        bool bigger = level > levelBubble;


        switch(bigger){
            case true:
                Damage(FindObjectOfType<Bubble>().gameObject);
                break;

            case false:
                Food();
                break;
        }
        
    }

    #region Interface Object
    public void Damage(GameObject obj){
        var bubble = FindObjectOfType<Bubble>().GetComponent<IBubble>();

        bubble.GetDamage();
    }

    public void Food(){
        var bubble = FindObjectOfType<Bubble>().GetComponent<IBubble>();

        bubble.eat();
        Destroy(this.gameObject);
    }

    #endregion
}
