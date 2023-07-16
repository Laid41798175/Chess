using UnityEngine;
using System.Collections.Generic;

public class PieceManager : MonoBehaviour {

    public static PieceManager Inst;

    private void Awake() {
        Inst = this;
    }

    [Header("Read Only")]
    [SerializeField] private List<GameObject> pieces;
    
    public void Play(int x, int y, int id) {
        GameObject prefab = PrefabManager.Inst.cardPrefabs[id];
        GameObject piece = Instantiate(PrefabManager.Inst.piecePrefabs[id]);
        Card card = prefab.GetComponent<Card>();
        piece.GetComponent<Piece>().Setting(x, y, card);
        BoardManager.Inst.Place(x, y, piece);
        pieces.Add(piece);
    }

    public void Move() {
        foreach (GameObject piece in pieces) {
            // TODO
        }
    }

    public void PlayerUnitDestroyed(GameObject piece) {
        pieces.Remove(piece);
    }
    
}