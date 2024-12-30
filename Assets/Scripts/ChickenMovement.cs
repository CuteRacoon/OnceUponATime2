using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
    public float moveSpeed = 3f;           // �������� ������������
    public float stopDurationMin = 1f;    // ����������� ����������������� ���������
    public float stopDurationMax = 3f;    // ������������ ����������������� ���������
    public float sphereRadius = 5f;        // ������ �����, � ������� ������ ����� ������
    public Transform sphereCenter;         // ����� �����

    private Vector3 targetPosition;         // ������� ������� ��� ��������
    private float stopTimer = 0f;          // ������ ��� ������� ������� ���������
    private bool isMoving = false;         // ��������� ��������

    private void Start()
    {
        if (sphereCenter == null)
        {
            sphereCenter = transform;
            Debug.LogWarning("Sphere center for " + gameObject.name + " not assigned, using the chicken's transform as the center");
        }
        SetNewTargetPosition();
    }

    private void Update()
    {
        if (isMoving)
        {
            // ������� ������ � ������� �������
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // ���������, �������� �� ����
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
                stopTimer = Random.Range(stopDurationMin, stopDurationMax);
            }
        }
        else
        {
            // ��������� ������ ���������
            stopTimer -= Time.deltaTime;

            // ���� ������ ��������� ����������, �������� �������� � ����� �����������
            if (stopTimer <= 0f)
            {
                SetNewTargetPosition();
                isMoving = true;
            }
        }
    }


    private void SetNewTargetPosition()
    {
        // ���������� ��������� ������� � �������� �����
        Vector2 randomCirclePoint = Random.insideUnitCircle * sphereRadius;
        targetPosition = sphereCenter.position + new Vector3(randomCirclePoint.x, 0, randomCirclePoint.y);

        // ������������� �������, ����� ������ �������� � ����������� ��������
        transform.LookAt(targetPosition);
    }
    private void OnDrawGizmosSelected()
    {
        if (sphereCenter == null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, sphereRadius);
            return;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(sphereCenter.position, sphereRadius);
    }
}