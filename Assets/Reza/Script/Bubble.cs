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


    void Start(){
        //exp = data[level].exp;
    }

    #region  Interface
    public void GetDamage(){
        // Health Berkurang
        Debug.Log("Get Damage");
    }

    public void eat(){
        test.changeValue(level);
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
           // float currentSize = transform.localScale.x;
            Sequence anim = DOTween.Sequence();
            anim.Append(transform.DOScale(Vector2.one * .75f, .25f));
            anim.Append(transform.DOScale(Vector2.one * 1.25f, .25f));
            anim.Append(transform.DOScale(Vector2.one, .25f));
        }
    }
    #endregion
}
