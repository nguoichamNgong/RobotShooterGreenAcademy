using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] GameObject Robot;
    [SerializeField] float spawnTime = 5f;
    [SerializeField] Transform spawnPos;

    PlayerHealth player;

    private void Start()
    {
        player = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (player)
        {
            Instantiate(Robot, spawnPos.position, transform.rotation);
            yield return new WaitForSeconds(spawnTime);
        }
        
    }
}
