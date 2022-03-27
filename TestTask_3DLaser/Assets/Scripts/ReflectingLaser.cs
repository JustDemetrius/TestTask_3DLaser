using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ReflectingLaser : MonoBehaviour
{
    [SerializeField] private Transform startPos;
    [SerializeField] private int maxReflections;

    [Header("Это и есть мощьность нашего лазера")]
    [SerializeField] private float Power;

    private LineRenderer lineRenderer;
    private Ray ray;
    private RaycastHit hit;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        LaserBeam();
    }

    private void LaserBeam()
    {
        ray = new Ray(startPos.position, transform.up);
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, startPos.position);

        float remainingLength = Power;
        for (int i = 0; i < maxReflections; i++)
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit, remainingLength))
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);
                remainingLength -= Vector3.Distance(ray.origin, hit.point);
                ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));

                if (hit.collider.CompareTag("Reflectable"))
                {
                    var b = hit.collider.GetComponent<PowerAbsorbing>();
                    if (remainingLength - b.AbsorbingValue > 0f)
                    {
                        remainingLength -= b.AbsorbingValue;
                    }
                    else
                    {
                        remainingLength = 0.1f;
                    }
                }
                else
                    break;
            }
            else
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, ray.origin + ray.direction * remainingLength);
            }
        }
    }
}
