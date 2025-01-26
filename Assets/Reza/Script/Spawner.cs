using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public class BarangSpawn{
        public List<GameObject> Halangan;
    }

    public List<BarangSpawn> barangs = new List<BarangSpawn>();
    public int index{
        get; set;
    }

    // public float speed = 10f; // Kecepatan peluru
    public Vector2 direction = Vector2.right; // Arah default (horizontal ke kanan)

    
    public void getListBarang(){

        transform.localPosition = randomPosition();

        if(barangs[index].Halangan.Count <= 0)
            return;

        int num = Random.Range(0,barangs[index].Halangan.Count-1);
        GameObject temp = barangs[index].Halangan[num];
        GameObject _barang = Instantiate(temp,transform.position, Quaternion.identity);
        _barang.transform.SetParent(GameManager.instance.parent);

        _barang.GetComponent<MoveBarang>().direction = direction;
        if(temp.GetComponent<Barang>().level > GameManager.instance.level){
            _barang.transform.localScale = Vector2.one * .4f;
        }
        
    }

    Vector2 randomPosition(){
        if(direction.x != 0)
            return new Vector2(transform.localPosition.x, Random.Range(-1f, 6f));

        else if(direction.y != 0)
            return new Vector2(Random.Range(-8f, 8f), transform.localPosition.y);

        return transform.localPosition;
    }
}
