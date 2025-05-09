using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float climbSpeed = 3f;
    private bool isClimbing = false;
    private bool isNearLadder = false;
   public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;
    public CharacterController controller;
    private bool isUIOpen = false;
    private Vector3 velocity;
    private bool isGrounded;
    private Vector3 moveDirection;
      private readonly string[] lockedCursorScenes = { "DemoMAP_version1", "Mysterious Dungeon" };

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        SceneManager.sceneLoaded += OnSceneLoaded;
        
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateCursorState();
    }

    private void UpdateCursorState()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        bool shouldLockCursor = System.Array.Exists(lockedCursorScenes, scene => scene == sceneName);
        if (isUIOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = shouldLockCursor ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !shouldLockCursor;
        }
    }
    public void SetUIState(bool isOpen)
    {
        isUIOpen = isOpen;
        UpdateCursorState();
    }   

    void Update()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (isClimbing)
        {
            float vertical = Input.GetAxis("Vertical");
            Vector3 climbDirection = new Vector3(0f, vertical * climbSpeed, 0f);
            controller.Move(climbDirection * Time.deltaTime);
        }
        else
        {       
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        
        float moveX = Input.GetAxisRaw("Horizontal");  
        float moveZ = Input.GetAxisRaw("Vertical");

        if (moveX != 0 || moveZ != 0)
        {
            moveDirection = Camera.main.transform.right * moveX + Camera.main.transform.forward * moveZ;
            moveDirection.y = 0; 
        }
        else
        {
            moveDirection = Vector3.zero; 
        }
        // กระโดด
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 10f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 5f;       
        }
        controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
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
