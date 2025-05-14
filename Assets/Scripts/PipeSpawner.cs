using Unity.VisualScripting;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{

    public float MaxOffsetTop = 1.8f;
    public float MaxOffsetBottom = -1f;
    public GameObject PipesObject;
    public float PipesFrecuency = 2f;
    float counter = 0;
    void Start()
    {
        counter = 0;
        Instantiate<GameObject>(PipesObject, transform.position, transform.rotation);
    }
    void Update()
    {
        counter += Time.deltaTime;
        if (counter > PipesFrecuency)
        {
            GameObject pipe = Instantiate(PipesObject, new Vector3(transform.position.x, randomYPosition(), transform.position.z), transform.rotation);
            Destroy(pipe, 10f);
            counter = 0;
        }

    }
    float randomYPosition()
    {
        float offset = Random.Range(MaxOffsetBottom, MaxOffsetTop);
        return transform.position.y + offset;
    }
}


