using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
public class Bubble : MonoBehaviour, IBubble
{

    [System.Serializable]
    public class BubbleData{
        public int exp;
        
    }

    public TMPro.TMP_Text text_Level;

    public AudioClip audioEat, audioDamage;
    AudioSource sound;
    public int heart = 3;

    [SerializeField] private int level;
    float currentExp;
    float exp;

    public BubbleData[] data;
    public int mLevel{
        get{
            return level;
        }
        set{
            level = value;
        }
    }

    public TestBack test;

    void Awake(){
        sound = GetComponent<AudioSource>();
    }

    void Start(){
        exp = data[level].exp;
        text_Level.text = $"{level + 1}";
    }

    #region  Interface
    public void GetDamage(){
        sound.PlayOneShot(audioDamage);
        // Health Berkurang
        if(this.heart >1){
        this.heart--;
        this.BlinkAndChangeColor();

        }
        else{
            Destroy(this.gameObject);
        }
        
    }

        void BlinkAndChangeColor()
    {
         float blinkDuration = 0.5f; // Time for one blink cycle
         int blinkCount = 5; // Number of times to blink
        // Get the material of the object
        Material material = this.gameObject.GetComponent<Renderer>().material;
        Color targetColor = Color.red; // The color to change to
        Color originalColor = material.color;

        // Create a DOTween Sequence
        Sequence sequence = DOTween.Sequence();

        // Add color change to the sequence
        sequence.Append(material.DOColor(targetColor, blinkDuration / 2));

        // Add blinking effect to the sequence
        for (int i = 0; i < blinkCount; i++)
        {
            sequence.Append(material.DOFade(0f, blinkDuration / 2)) // Fade out
                    .Append(material.DOFade(1f, blinkDuration / 2)); // Fade in
        }

        // Reset the color back to the original color after blinking
        sequence.Append(material.DOColor(originalColor, blinkDuration / 2));

        // Start the sequence
        sequence.Play();
        
    }

    public void eat(){
        test.changeValue(level);
        sound.PlayOneShot(audioEat);
        Sequence anim = DOTween.Sequence();
        anim.Append(transform.DOScale(Vector2.one  * .75f, .25f));
        anim.Append(transform.DOScale(Vector2.one  * 1.25f, .25f));
        anim.Append(transform.DOScale(Vector2.one, .25f).OnComplete(addExp));
    }

    // GGgsdgs
    void addExp(){
        currentExp += 5;
        if(currentExp >= exp){
            level += 1; 
            currentExp = 0;
            exp = data[level].exp;
                    text_Level.text = $"{level + 1}";
           // float currentSize = transform.localScale.x;
            Sequence anim = DOTween.Sequence();
            anim.Append(transform.DOScale(Vector2.one * .75f, .25f));
            anim.Append(transform.DOScale(Vector2.one * 1.25f, .25f));
            anim.Append(transform.DOScale(Vector2.one, .25f));

            GameManager.instance.initLevel();
        }
    }
    #endregion
}



