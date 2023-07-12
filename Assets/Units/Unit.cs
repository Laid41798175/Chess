using UnityEngine;

public class Unit : MonoBehaviour, IUnit {

    [Header("Read Only")]
    [SerializeField] private string nomenclature;

    [SerializeField] private int x;
    [SerializeField] private int y;

    [SerializeField] private Based based;
    [SerializeField] private Direction currentDirection;
    [SerializeField] private int power;
    [SerializeField] private int speed;

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

    }


}