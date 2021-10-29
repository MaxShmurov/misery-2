using UnityEngine;

public class GroundTile : MonoBehaviour

{
    GroundSpawner groundSpawner;
    // Start is called before the first frame update
    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
