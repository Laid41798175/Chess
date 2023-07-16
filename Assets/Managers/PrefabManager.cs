using UnityEngine;
using System.Collections.Generic;

public class PrefabManager : MonoBehaviour {

    public static PrefabManager Inst;

    private void Awake() {
        Inst = this;
    }

    public GameObject[] cardPrefabs = new GameObject[30];
    public GameObject[] piecePrefabs = new GameObject[30];
    public GameObject[] enemyCardPrefabs = new GameObject[30];
    public GameObject[] enemyPrefabs = new GameObject[30];

}