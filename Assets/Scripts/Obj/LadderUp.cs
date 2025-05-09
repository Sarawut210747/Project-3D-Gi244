using UnityEngine;

public class LadderUp : MonoBehaviour
{
    public float climbSpeed = 3f;

    private bool isNearLadder = false;
    private bool isClimbing = false;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (isNearLadder && Input.GetKeyDown(KeyCode.F))
        {
            isClimbing = !isClimbing;
            Debug.Log("Climbing: " + isClimbing);
        }

        if (isClimbing)
        {
            float inputY = Input.GetAxis("Vertical");
            Vector3 climbDirection = new Vector3(0f, inputY * climbSpeed, 0f);
            controller.Move(climbDirection * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            isNearLadder = true;
            Debug.Log("Near Ladder");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            isNearLadder = false;
            isClimbing = false;
            Debug.Log("Left Ladder");
        }
    }
}
