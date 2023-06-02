using UnityEngine;

public class swap : MonoBehaviour
{
    private Transform selectedObject;
    private bool isFirstObjectSelected;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);

            if (hit.collider != null)
            {
                if (isFirstObjectSelected)
                {
                    Transform secondObject = hit.collider.transform;
                    Vector3 tempPosition = selectedObject.position;
                    selectedObject.position = secondObject.position;
                    secondObject.position = tempPosition;

                    isFirstObjectSelected = false;
                    selectedObject = null;
                }
                else
                {
                    selectedObject = hit.collider.transform;
                    isFirstObjectSelected = true;
                }
            }
        }
        else if (Input.GetMouseButtonDown(1)) // 오른쪽 마우스 버튼 클릭
        {
            if (selectedObject != null)
            {
                selectedObject.Rotate(0f, 0f, 90f); // 선택된 객체를 90도 오른쪽으로 회전
            }
        }
    }
}
