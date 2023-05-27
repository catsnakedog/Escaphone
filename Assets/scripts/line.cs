using UnityEngine;

public class line : MonoBehaviour
{
    [SerializeField]
    private Vector2 startPoint;

    [SerializeField]
    private Vector2 endPoint;

    [SerializeField]
    private float lineWidth = 2f;

    [SerializeField]
    private Color lineColor = Color.red;

    void Start()
    {
        GameObject lineObject = new GameObject("Line");
        lineObject.transform.SetParent(transform, false);

        LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, new Vector3(startPoint.x, startPoint.y, 0f));
        lineRenderer.SetPosition(1, new Vector3(endPoint.x, endPoint.y, 0f));

        Material lineMaterial = new Material(Shader.Find("Sprites/Default"));
        lineMaterial.color = lineColor;
        lineRenderer.material = lineMaterial;
    }
}
