using System.Collections;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
   public Rigidbody rb;   
    public float forceAmount = 10f;  
    public float resetTime = 1.5f;  
    public float cooldownTime = 3f;  
    public float resetSpeed = 2f;  

    private bool isTriggered = false; 
    private Vector3 initialPosition;  

    public AudioSource spikeSound;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        rb.isKinematic = true; 
        initialPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            StartCoroutine(ActivateTrap()); 
        }
    }

    IEnumerator ActivateTrap()
    {
        isTriggered = true; 

        if (spikeSound != null)
        {
            spikeSound.Play();
        }
        
        rb.isKinematic = false;
        rb.AddForce(Vector3.up * forceAmount, ForceMode.Impulse);

        yield return new WaitForSeconds(resetTime); 

       
        StartCoroutine(ResetPosition());

        yield return new WaitForSeconds(cooldownTime); 

        isTriggered = false; 
    }

    IEnumerator ResetPosition()
    {
        
        rb.isKinematic = true;

        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;

        while (elapsedTime < 1f) 
        {
            transform.position = Vector3.Lerp(startPosition, initialPosition, elapsedTime * resetSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        
        transform.position = initialPosition;
    }
}
