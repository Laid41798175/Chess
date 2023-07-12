using UnityEngine;

public class Card : MonoBehaviour, ICard {

    public int id;
    public string nomenclature;
    public int cost;

    public Based based;
    public int power;
    public int speed;

    public GameObject piecePrefab;

    public void Play(int x, int y) {
        GameObject piece = GameObject.Instantiate(piecePrefab);
        Unit unit = piece.GetComponent<Unit>();
        unit.Setting(x, y, this);
    }

}