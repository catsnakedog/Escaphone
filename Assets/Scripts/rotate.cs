using UnityEngine;

public class rotate : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (IsClickedObject())
            {

                float currentRotation = transform.eulerAngles.z;

                currentRotation -= 90f;

                transform.eulerAngles = new Vector3(0, 0, currentRotation);
            }
        }
    }

    private bool IsClickedObject()
    {
        Vector3 mousePosition = Input.mousePosition;

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            return true;
        }

        return false;
    }
}
