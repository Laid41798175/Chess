using UnityEngine;
using System;

public class IncidentManager : MonoBehaviour {

    public static IncidentManager Inst;

    private void Awake() {
        Inst = this;
    }

    [Header("Statistics")]
    [SerializeField] private int playerUnitDestroyed = 0;
    [SerializeField] private int enemyUnitDestroyed = 0;
    [SerializeField] private int unitsFought = 0;

    public void GameOver(){
        Debug.Log("Game Over...");
    }

    public void GameClear(){
        Debug.Log("Game Clear!");
    }

    public void PlayerUnitDestroyed(GameObject piece) {
        PieceManager.Inst.PlayerUnitDestroyed(piece);
        BoardManager.Inst.Remove(piece);
        Destroy(piece);
        playerUnitDestroyed += 1;
    }

    public void EnemyUnitDestroyed(GameObject enemy) {
        EnemyManager.Inst.EnemyUnitDestroyed(enemy);
        BoardManager.Inst.Remove(enemy);
        Destroy(enemy);
        enemyUnitDestroyed += 1;
    }

    public void UnitsFought(GameObject piece, GameObject enemy) {
        unitsFought += 1;
    }
}