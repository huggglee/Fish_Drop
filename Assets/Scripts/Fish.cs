using UnityEngine;

public class Fish : MonoBehaviour
{
    public int fishLevel;
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log(this.tag);
    }

    void Update()
    {
        
    }

    void Drop()
    {
        rb.useGravity = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(this.tag))
        {
            Fish otherFish = collision.gameObject.GetComponent<Fish>();
            if (this.GetInstanceID() < otherFish.GetInstanceID())
            {
            FishManager.instance.MergeFish(this, otherFish);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag(this.tag))
        {
            Fish otherFish = collision.gameObject.GetComponent<Fish>();
            if (this.GetInstanceID() < otherFish.GetInstanceID())
            {
                FishManager.instance.MergeFish(this, otherFish);
            }
        }
    }
}
