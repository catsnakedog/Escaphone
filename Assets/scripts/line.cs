using UnityEngine;

public class line : MonoBehaviour
{
    [SerializeField]
    private int lineCount = 4;

    [SerializeField]
    private float lineWidth = 0.1f;

    [SerializeField]
    private Color lineColor = Color.black;

    private Vector3[] startPoints;
    private Vector3[] endPoints;

    private float verticalLineLength = 2.0f;
    private float verticalLineSpacingMin = 1.0f;
    private float verticalLineSpacingMax = 2.0f;
    private float minXRange = -4.0f;
    private float maxXRange = 4.0f;

    void Start()
    {
        startPoints = new Vector3[lineCount];
        endPoints = new Vector3[lineCount];

        startPoints[0] = new Vector3(5, 3, 0);
        endPoints[0] = new Vector3(-5, 3, 0);

        startPoints[1] = new Vector3(5, 1, 0);
        endPoints[1] = new Vector3(-5, 1, 0);

        startPoints[2] = new Vector3(5, -1, 0);
        endPoints[2] = new Vector3(-5, -1, 0);

        startPoints[3] = new Vector3(5, -3, 0);
        endPoints[3] = new Vector3(-5, -3, 0);

        CreateLines(startPoints, endPoints);
        CreateRandomVerticalLines(-3, -1); 
        CreateRandomVerticalLines(-1, 1); 
        CreateRandomVerticalLines(1, 3); 
    }

    private void CreateLines(Vector3[] starts, Vector3[] ends)
    {
        for (int i = 0; i < starts.Length; i++)
        {
            CreateLine(starts[i], ends[i]);
        }
    }

    private void CreateLine(Vector3 start, Vector3 end)
    {
        GameObject lineObject = new GameObject("Line");
        lineObject.transform.SetParent(transform, false);

        LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);

        Material lineMaterial = new Material(Shader.Find("Sprites/Default"));
        lineMaterial.color = lineColor;
        lineRenderer.material = lineMaterial;
    }

    private void CreateRandomVerticalLines(float minY, float maxY)
    {
        int numLines = Mathf.CeilToInt((maxXRange - minXRange) / verticalLineSpacingMax);

        if (numLines <= 0)
            return;

        float currentY = minY;
        float spacing = (maxXRange - minXRange) / numLines;

        while (currentY + verticalLineLength / 2.0f <= maxY)
        {
            for (int i = 0; i < numLines; i++)
            {
                float x = Random.Range(minXRange + spacing * i, minXRange + spacing * (i + 1));
                Vector3 start = new Vector3(x, currentY, 0);
                Vector3 end = new Vector3(x, currentY + verticalLineLength, 0);
                CreateLine(start, end);
            }

            currentY += verticalLineSpacingMax;
        }
    }
}
