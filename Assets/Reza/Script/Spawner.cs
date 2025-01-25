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
    // public Vector2 direction = Vector2.right; // Arah default (horizontal ke kanan)

    
    public void getListBarang(){
        int num = Random.Range(0,barangs[index].Halangan.Count-1);
        // barang[num].gameObject.GetComponent<MoveBarang>().speed = this.speed;
        // barang[num].gameObject.GetComponent<MoveBarang>().direction= this.direction;
        GameObject temp = barangs[index].Halangan[num];
        GameObject _barang = Instantiate(temp,this.transform.position,this.transform.rotation);
        _barang.transform.SetParent(GameManager.instance.parent);

        if(temp.GetComponent<Barang>().level > GameManager.instance.level){
            _barang.transform.localScale = Vector2.one * 1f;
        }
        
    }
}
