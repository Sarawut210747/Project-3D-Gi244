using UnityEngine;

public class FloatingRotatingGem : MonoBehaviour
{
    public int scoreValue = 10; 
    public float floatStrength = 0.5f; 
    public float rotationSpeed = 50f;  
    private AudioSource pickupSound;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position; 
        pickupSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        
        transform.position = startPos + new Vector3(0, Mathf.Sin(Time.time) * floatStrength, 0);

        
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            if (pickupSound != null)
            {
                pickupSound.Play();
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<Collider>().enabled = false;
            }
            GameManager.instance.AddGem();
            gameObject.SetActive(false);
        }
    }

    
}
