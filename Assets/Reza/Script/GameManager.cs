using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 
    [System.Serializable]
    public class DataObj{
        public float timer;

    }

    public List<Spawner> spawners;
    public List<DataObj> objS;
    public int level;
    float intervalTime;
    float nextTime;

    public Transform parent;


    private void Awake() {
        instance = this;
    }
    void Start(){
        intervalTime = objS[level].timer;
    }

    void Update(){
        /*
        if(Time.time >= nextTime){
            int num1 = Random.Range(0,objS[level].spawners.Count-1);
            int num2 = Random.Range(0,objS[level].spawners.Count-1);

            
            

            Instantiate(objS[level].spawners[num1],objS[level].spawners[num1].transform.position,objS[level].spawners[num1].transform.rotation);
            objS[level].spawners[num1].getListBarang();
            Instantiate(objS[level].spawners[num2],objS[level].spawners[num2].transform.position,objS[level].spawners[num2].transform.rotation);
            objS[level].spawners[num2].getListBarang();


            nextTime = Time.time + intervalTime;
        }
        */

        if(Time.time >= nextTime){
            List<int> num = new List<int>();
            num.Add(Random.Range(0,spawners.Count-1));
            num.Add(Random.Range(0,spawners.Count-1));
            // Instantiate(objS[level].spawners[num1],objS[level].spawners[num1].transform.position,objS[level].spawners[num1].transform.rotation);
            // objS[level].spawners[num1].getListBarang();
            // Instantiate(objS[level].spawners[num2],objS[level].spawners[num2].transform.position,objS[level].spawners[num2].transform.rotation);
            // objS[level].spawners[num2].getListBarang();
            foreach(var index in num){
                spawners[index].getListBarang();
            }

            nextTime = Time.time + intervalTime;
        }
    }

    public void initLevel(){
        level += 1;
        intervalTime = objS[level].timer;
        foreach(var spawn in spawners){
            spawn.index = level;
        }
    }
}
