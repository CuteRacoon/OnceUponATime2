using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player; // ������ �� transform ������
    public bool followPlayer = true; // ���� ���������� �� �������
    private Vector3 offset; // ��������� �������� ������ ������������ ������

    void Start()
    {
        Vector3 startPosition = new Vector3(
               player.position.x,
               transform.position.y,
               transform.position.z
           );
        transform.position = startPosition;
        // ��������� ��������� �������� ����� ������� � �������
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        if (followPlayer)
        {
            // ���� ���� �������, ������ ������� �� ������� �� X
            Vector3 newPosition = new Vector3(
                player.position.x + offset.x,
                transform.position.y,
                transform.position.z
            );
            transform.position = newPosition;
        }
    }
}