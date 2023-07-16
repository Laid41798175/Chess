using UnityEngine;

public class InputManager : MonoBehaviour {

    public static InputManager Inst;

    private void Awake() {
        Inst = this;
    }

    [SerializeField] private bool isValid = false;

    private void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 마우스 위치를 기준으로 Ray 생성
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            GameObject hitObject = hit.collider.gameObject; // 충돌한 GameObject 가져오기
            Debug.Log("Hit object: " + hitObject.name); // 충돌한 GameObject의 이름을 로그로 출력하거나 다른 작업 수행

            if (Input.GetMouseButtonDown(0)) {
                if (isValid) {
                    // TODO
                } else {
                    Debug.Log("Not your turn");
                }
            }
        }
    }

    public void Activate() {
        isValid = true;
    }

    public void Deactivate() {
        isValid = false;
    }
}