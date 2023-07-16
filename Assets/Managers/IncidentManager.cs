using UnityEngine;
using System;

public class IncidentManager : MonoBehaviour {

    public static IncidentManager Inst;

    private void Awake() {
        Inst = this;
    }

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
    }

    public void EnemyUnitDestroyed(GameObject enemy) {
        EnemyManager.Inst.EnemyUnitDestroyed(enemy);
        BoardManager.Inst.Remove(enemy);
        Destroy(enemy);
    }

    public void UnitsFought(GameObject piece, GameObject enemy) {
        
    }
}