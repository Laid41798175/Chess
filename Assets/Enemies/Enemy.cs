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

    }

    public bool IsMovable() {
        if (y == 0) {
            return true;
        }
        
        if (BoardManager.Inst.IsEmpty(x, y - 1)) {
            return true;
        } else {
            return BoardManager.Inst.IsPlayerUnit(x, y - 1);
        }
    }

    public void MoveOnce() {
        if (y == 0) {
            AttackManager.Inst.PlayerAttacked(gameObject);
        }

        if (BoardManager.Inst.IsEmpty(x, y - 1)) {

        }
        
    }

    public void Placed() {

    }

    public void Killed() {
        
    }

}