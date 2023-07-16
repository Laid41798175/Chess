using UnityEngine;

public class TurnManager : MonoBehaviour {

    public static TurnManager Inst;

    private void Awake() {
        Inst = this;
    }

    [Header("Read Only")]
    [SerializeField] private int turn = 0;
    [SerializeField] private bool isPlayerTurn = false;

    public void TurnStart(){
        // deactivate EnemyManager
        InputManager.Inst.Activate();
        turn += 1;
        isPlayerTurn = true;
    }

    public void TurnEnd(){
        InputManager.Inst.Deactivate();
        // activate EnemyManager
        isPlayerTurn = false;
    }

}