using UnityEngine;
using System;

public class AttackManager : MonoBehaviour {

    public static AttackManager Inst;

    private void Awake() {
        Inst = this;
    }

    [Header("hp")]
    [SerializeField] private int hp = 100;
    [SerializeField] private int enemyHp = 100;

    public void UnitsFought(GameObject piece, GameObject enemy) {
        int piecePower = piece.GetComponent<Piece>().GetPower();
        int enemyPower = piece.GetComponent<Enemy>().GetPower();
        if (piecePower > enemyPower) {
            IncidentManager.Inst.EnemyUnitDestroyed(enemy);
            piece.GetComponent<Piece>().SetPower(piecePower - enemyPower);
        } else if (piecePower == enemyPower) {
            IncidentManager.Inst.EnemyUnitDestroyed(enemy);
            IncidentManager.Inst.PlayerUnitDestroyed(piece);
        } else {
            IncidentManager.Inst.PlayerUnitDestroyed(piece);
            enemy.GetComponent<Enemy>().SetPower(enemyPower - piecePower);
        }
        IncidentManager.Inst.UnitsFought(piece, enemy);
    }

    public void PlayerAttacked(GameObject enemy) {
        int power = enemy.GetComponent<Enemy>().GetPower();
        hp -= power;
        if (hp <= 0) {
            IncidentManager.Inst.GameOver();
            return;
        }
        IncidentManager.Inst.EnemyUnitDestroyed(enemy);
    }

    public void EnemyAttacked(GameObject piece) {
        int power = piece.GetComponent<Piece>().GetPower();
        enemyHp -= power;
        if (enemyHp <= 0) {
            IncidentManager.Inst.GameClear();
            return;
        }
        IncidentManager.Inst.PlayerUnitDestroyed(piece);
    }

}