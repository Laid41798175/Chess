using UnityEngine;

public enum Direction {
    L,
    LLU,
    LU,
    LUU,
    U,
    RUU,
    RU,
    RRU,
    R
}

public class Directions {
    
    public static Direction Rotate(Direction currentDirection, Based based){
        switch (based) {
            case Based.Pawn:
                if (currentDirection != Direction.U) {
                    Debug.Log("Unvalid direction");
                }
                return currentDirection;
            case Based.King:
            case Based.Queen:
                switch (currentDirection) {
                    case Direction.L:
                        return Direction.LU;
                    case Direction.LU:
                        return Direction.U;
                    case Direction.U:
                        return Direction.RU;
                    case Direction.RU:
                        return Direction.R;
                    case Direction.R:
                        return Direction.L;
                    default:
                        Debug.Log("Unvalid direction");
                        break;
                }
                return FirstDirection(based);
            case Based.Rook:
                switch (currentDirection) {
                    case Direction.L:
                        return Direction.U;
                    case Direction.U:
                        return Direction.R;
                    case Direction.R:
                        return Direction.L;
                    default:
                        Debug.Log("Unvalid direction");
                        break;
                }
                return FirstDirection(based);
            case Based.Bishop:
                switch (currentDirection) {
                    case Direction.LU:
                        return Direction.RU;
                    case Direction.RU:
                        return Direction.LU;
                    default:
                        Debug.Log("Unvalid direction");
                        break;
                }
                return FirstDirection(based);
            case Based.Knight:
                switch (currentDirection) {
                    case Direction.LLU:
                        return Direction.LUU;
                    case Direction.LUU:
                        return Direction.RUU;
                    case Direction.RUU:
                        return Direction.RRU;
                    case Direction.RRU:
                        return Direction.LLU;
                    default:
                        Debug.Log("Unvalid direction");
                        break;
                }
                return FirstDirection(based);
            default:
                return FirstDirection(based);
        }
    }

    public static Direction FirstDirection(Based based){
        switch (based) {
            case Based.King:
            case Based.Queen:
            case Based.Rook:
                return Direction.L;
            case Based.Bishop:
                return Direction.LU;
            case Based.Knight:
                return Direction.LLU;
            case Based.Pawn:
                return Direction.U;
            default:
                return Direction.L;
        }
    }
}