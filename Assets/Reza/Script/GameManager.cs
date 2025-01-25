using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    public class DataObj{
        public float timer;
        public float speed;
        public List<Barang> barangs;
        public List<GameObject> obstacle; 
    }
}
