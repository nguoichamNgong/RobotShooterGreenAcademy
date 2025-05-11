using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    FirstPersonController player;
    NavMeshAgent agent;

    const string PLAYER_STRING = "Player";

    GameManager gameManager;  // Thêm tham chi?u ??n GameManager

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<FirstPersonController>();
        gameManager = FindObjectOfType<GameManager>();  // L?y tham chi?u ??n GameManager
    }

    // Update is called once per frame
    void Update()
    {
        if (!player) return;

        agent.SetDestination(player.transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_STRING))
        {
            EnemyHealth enemyHealth = GetComponent<EnemyHealth>();
            enemyHealth.SelfDestruct();  // G?i ph??ng th?c t? h?y

            // Gi?m s? l??ng k? ??ch trong GameManager khi robot t? h?y
            if (gameManager != null)
            {
                gameManager.AdjustEnemiesLeft(-1);  // Gi?m s? l??ng k? ??ch
            }
            else
            {
                Debug.LogWarning("GameManager not found!");
            }
        }
    }
}
