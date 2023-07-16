using UnityEngine;

public class Card : MonoBehaviour {

    public int id;
    public string nomenclature;
    public int cost;

    public Based based;
    public int power;
    public int speed;

    public void Play(int x, int y) {
        PieceManager.Inst.Play(x, y, id);
    }

}