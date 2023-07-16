using UnityEngine;
using System;

public class Piece : MonoBehaviour {

    [Header("Read Only")]
    [SerializeField] private string nomenclature;

    [SerializeField] private int x;
    [SerializeField] private int y;

    [SerializeField] private Based based;
    [SerializeField] private Direction currentDirection;
    [SerializeField] private int power;
    [SerializeField] private int speed;

    public int GetPower() {
        return power;
    }

    public void SetPower(int power) {
        this.power = power;
    }

    public void Setting(int x, int y, Card card) {
        nomenclature = card.nomenclature;

        this.x = x;
        this.y = y;

        based = card.based;
        currentDirection = Directions.FirstDirection(based);
        power = card.power;
        speed = card.speed;
    }

    public void Rotate() {
        Direction nextDirection = Directions.Rotate(currentDirection, based);
        // GUI Update
        currentDirection = nextDirection;
    }

    public void Move() {
        for (int i = 0; i < speed; i++) {
            Tuple<int, int> next = NextXY();
            int nextX = next.Item1;
            int nextY = next.Item2;
            
            switch (IsMovable(next)) {
                case -2: // Piece
                    return;
                case -1: // Unreachable
                    currentDirection = Directions.Turn(currentDirection);
                    i--;
                    break;
                case 0: // Empty
                    BoardManager.Inst.Move(x, y, nextX, nextY);
                    x = nextX;
                    y = nextY;
                    break;
                case 1: // EnemyAttacked
                    AttackManager.Inst.EnemyAttacked(gameObject);
                    return;
                case 2: // Enemy
                    GameObject enemy = BoardManager.Inst.Target(nextX, nextY);
                    AttackManager.Inst.UnitsFought(gameObject, enemy);
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
        
        if (8 <= nextY) {
            return 1; // EnemyAttacked
        }

        if (BoardManager.Inst.IsEmpty(nextX, nextY)) {
            return 0; // Empty
        } else {
            if (BoardManager.Inst.IsPlayerUnit(nextX, nextY)) {
                return -2; // Piece
            } else {
                return 2; // Enemy
            }
        }

    }

    public Tuple<int, int> NextXY() {
        switch (currentDirection) {
            case Direction.L:
                return Tuple.Create(x - 1, y);
            case Direction.LLU:
                return Tuple.Create(x - 2, y + 1);
            case Direction.LU:
                return Tuple.Create(x - 1, y + 1);
            case Direction.LUU:
                return Tuple.Create(x - 1, y + 2);
            case Direction.U:
                return Tuple.Create(x, y + 1);
            case Direction.RUU:
                return Tuple.Create(x + 1, y + 2);
            case Direction.RU:
                return Tuple.Create(x + 1, y + 1);
            case Direction.RRU:
                return Tuple.Create(x + 2, y + 1);
            case Direction.R:
                return Tuple.Create(x + 1, y);
            default:
                return Tuple.Create(x, y);
        }
    }

    public void Placed() {
        
    }

    public void Killed() {
        
    }

}