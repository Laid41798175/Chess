using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour {

    public static EnemyManager Inst;

    private void Awake() {
        Inst = this;
    }

    [Header("Change this EnemyList by difficulty or patch")]
    public EnemyList enemyList;

    [Header("Read Only")]
    [SerializeField] private List<GameObject> enemies;
    
    public void Play(int x, int y, int id) {
        GameObject prefab = PrefabManager.Inst.enemyCardPrefabs[id];
        GameObject enemy = Instantiate(PrefabManager.Inst.enemyPrefabs[id]);
        EnemyCard card = prefab.GetComponent<EnemyCard>();
        enemy.GetComponent<Enemy>().Setting(x, y, card);
        BoardManager.Inst.Place(x, y, enemy);
        enemies.Add(enemy);
    }

    public void Move() {
        foreach (GameObject enemy in enemies) {
            enemy.GetComponent<Enemy>().Move();
        }
    }

    public void EnemyUnitDestroyed(GameObject enemy) {
        enemies.Remove(enemy);
    }
    
}