using UnityEngine;

public class TrapActivator : MonoBehaviour
{
    public Transform wall; // กำแพงที่จะเลื่อนลงมา
    public float dropHeight = -3f; // ระยะที่กำแพงจะเลื่อนลง
    public float dropSpeed = 2f; // ความเร็วที่กำแพงจะเลื่อนลง
     public LayerMask playerLayer;
     public float rayLength = 2f;

    private bool isTriggered = false;
    private Vector3 originalWallPosition;
    private Vector3 targetPosition;

    void Start()
    {
        if (wall != null)
        {
            originalWallPosition = wall.position;
            targetPosition = originalWallPosition + new Vector3(0, dropHeight, 0);
        }
    }

    void Update()
    {
       if (isTriggered && wall != null)
        {
            wall.position = Vector3.Lerp(wall.position, targetPosition, Time.deltaTime * dropSpeed);
        }

        // สร้าง Raycast จากพื้นขึ้นไปเพื่อหาผู้เล่น
        Ray ray = new Ray(transform.position, Vector3.right);
        RaycastHit hit;

        // แสดงเส้น Raycast ใน Scene View
        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);

        // ตรวจจับว่ามีผู้เล่นอยู่เหนือพื้นหรือไม่
        if (Physics.Raycast(ray, out hit, rayLength, playerLayer))
        {
            if (!isTriggered && hit.collider.CompareTag("Player"))
            {
                isTriggered = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
        }
    }
}
