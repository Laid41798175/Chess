using UnityEngine;
using System;

public class BoardManager : MonoBehaviour {

    public static BoardManager Inst;

    private void Awake() {
        Inst = this;
    }

    private bool[,] isEmpty = new bool[8,8];
    private GameObject[,] board = new GameObject[8,8];

    public bool IsEmpty(int x, int y) {
        return isEmpty[x, y];
    }

    public bool IsPlayerUnit(int x, int y) {
        GameObject unit = Target(x, y);
        return unit.tag == "Piece";
    }

    public GameObject Target(int x, int y) {
        if (IsEmpty(x, y)) {
            Debug.Log("Unvalid Target: Undefined Behavior");
        }
        return board[x, y];
    }

    public void Place(int x, int y, GameObject unit) {
        if (!IsEmpty(x, y)) {
            Debug.Log("Place Failed");
            return;
        }
        board[x, y] = unit;

        if (IsPlayerUnit(x, y)) {
            unit.GetComponent<Piece>().Placed();
        } else {
            unit.GetComponent<Enemy>().Placed();
        }
    }

    public void Move(int x, int y, int newX, int newY) {
        GameObject unit = Target(x, y);
        isEmpty[x, y] = true;
        board[newX, newY] = unit;
        isEmpty[newX, newY] = false;
    }

    public void Remove(GameObject unit) {
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {
                if (!isEmpty[i, j] && board[i, j] == unit) {
                    isEmpty[i, j] = true;
                }
            }
        }
    }
}