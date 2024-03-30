using UnityEngine;

public class DrawLineToCursor : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Camera mainCamera;

    void Start()
    {
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        lineRenderer.positionCount = 2;
        lineRenderer.sortingLayerName = "Foreground"; // Set the sorting layer to render on top
        lineRenderer.sortingOrder = 1; // Set the sorting order to render on top
        lineRenderer.useWorldSpace = true; // Ensure the line is rendered in world space
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = transform.position.z - mainCamera.transform.position.z;
        Vector3 targetPosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // Check if the cursor is within the camera view
        Vector3 viewportPos = mainCamera.WorldToViewportPoint(targetPosition);
        bool isVisible = viewportPos.x >= 0 && viewportPos.x <= 1 && viewportPos.y >= 0 && viewportPos.y <= 1 && viewportPos.z >= 0;

        if (isVisible)
        {
            lineRenderer.enabled = true;

            Vector3[] positions = { transform.position, targetPosition };
            lineRenderer.SetPositions(positions);
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }
}
