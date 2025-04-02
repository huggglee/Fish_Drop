using UnityEngine;

public class FishController : MonoBehaviour
{
    private Rigidbody rb;
    private bool isDrop = false;
    private GameObject controlledFish;
    private Vector3 spawnPosition;

    private float minX = -1.4f, maxX = 1.4f;
    private float Y=4f;

    void Start()
    {
        spawnPosition = new Vector3(0,Y,0);
        SpawnNewFish();
    }

    void Update()
    {
        //if (!controlledFish)
        //{
        //    SpawnNewFish();
        //}

        if (Input.touchCount > 0 && !isDrop)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
            controlledFish.transform.position = new Vector3(
                Mathf.Clamp(touchPos.x,minX,maxX),
                Y,
                0
                );

            if (touch.phase == TouchPhase.Ended)
            {
                Drop();
            }
        }
    }

    private void SpawnNewFish()
    {
        controlledFish = FishManager.instance.SpawnFish(spawnPosition);
        rb = controlledFish.GetComponent<Rigidbody>();
        rb.useGravity = false;
        isDrop = false;
    }

    private void Drop()
    {
        rb.useGravity = true;
        spawnPosition = controlledFish.transform.position;
        controlledFish = null;
        rb = null;
        isDrop = true;

        Invoke("SpawnNewFish", 1f);
    }
}
