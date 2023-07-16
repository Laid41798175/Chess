using UnityEngine;
using System;

public class Enemy : MonoBehaviour {

    [Header("Read Only")]
    [SerializeField] private string nomenclature;

    [SerializeField] private int x;
    [SerializeField] private int y;

    [SerializeField] private int power;
    [SerializeField] private int speed;

    public int GetPower() {
        return power;
    }
    
    public void SetPower(int power) {
        this.power = power;
    }

    public void Setting(int x, int y, EnemyCard card) {
        nomenclature = card.nomenclature;

        this.x = x;
        this.y = y;

        power = card.power;
        speed = card.speed;
    }

    public void Move() {
        for (int i = 0; i < speed; i++) {
            Tuple<int, int> next = NextXY();
            int nextX = next.Item1;
            int nextY = next.Item2;
            
            switch (IsMovable(next)) {
                case -2: // Enemy
                    return;
                case -1: // Unreachable
                    return;
                case 0: // Empty
                    BoardManager.Inst.Move(x, y, nextX, nextY);
                    x = nextX;
                    y = nextY;
                    break;
                case 1: // PlayerAttacked
                    AttackManager.Inst.PlayerAttacked(gameObject);
                    return;
                case 2: // Piece
                    GameObject piece = BoardManager.Inst.Target(nextX, nextY);
                    AttackManager.Inst.UnitsFought(piece, gameObject);
                    BoardManager.Inst.Move(x, y, nextX, nextY);
                    x = nextX;
                    y = nextY;
                    break;
                default:
                    return;
            }
        }
    }

    public int IsMovable(Tuple<int, int> next) {
        int nextX = next.Item1;
        int nextY = next.Item2;

        if (nextX < 0 || 8 <= nextX) {
            return -1; // Unreachable
        }

        if (nextY < 0) {
            return 1; // PlayerAttacked
        }
        
        if (BoardManager.Inst.IsEmpty(nextX, nextY)) {
            return 0; // Empty
        } else {
            if (BoardManager.Inst.IsPlayerUnit(nextX, nextY)) {
                return 2; // Piece
            } else {
                return -2; // Enemy
            }
        }
    }

    public Tuple<int, int> NextXY() {
        return Tuple.Create(x, y - 1);
    }

    public void Placed() {

    }

    public void Killed() {
        
    }

}