using UnityEngine;

public class FishManager : MonoBehaviour
{
    public static FishManager instance;
    public GameObject[] Fishs;
    private GameObject currentFish;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        //InvokeRepeating("SpawnFish", 3.0f, 5.0f);
    }

    void Update()
    {

    }

    public GameObject SpawnFish(Vector3 position)
    {
        int index = Random.Range(0, 4);
        currentFish = Instantiate(Fishs[index], position, Fishs[index].transform.rotation);
        return currentFish;
    }

    public void MergeFish(Fish fish1, Fish fish2)
    {
        int newLevel = fish1.fishLevel + 1;
        if (newLevel < Fishs.Length)
        {
            Vector3 newPosition = (fish1.transform.position + fish2.transform.position) / 2;
            GameObject newFish = Instantiate(Fishs[newLevel], newPosition, Fishs[newLevel].transform.rotation);
            newFish.GetComponent<Rigidbody>().useGravity = true;
            Destroy(fish1.gameObject);
            Destroy(fish2.gameObject);
        }
    }
}
