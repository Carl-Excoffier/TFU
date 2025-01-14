using UnityEngine;

public class FightTile : MonoBehaviour
{
    public GameObject interactionMarkerPrefab;
    public GameObject player;
    private GameObject currentMarkerInstance;
    private bool playerInRange = false;

    void Start()
    {
        if (interactionMarkerPrefab == null)
        {
            Debug.LogError("Interaction marker prefab is not assigned!");
        }

        if (player == null)
        {
            Debug.LogError("Player GameObject is not assigned!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;

            if (interactionMarkerPrefab != null && currentMarkerInstance == null)
            {
                Vector3 markerPosition = player.transform.position + new Vector3(0, 2f, 0);
                currentMarkerInstance = Instantiate(interactionMarkerPrefab, markerPosition, Quaternion.identity);
                currentMarkerInstance.transform.SetParent(player.transform);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;

            if (currentMarkerInstance != null)
            {
                Destroy(currentMarkerInstance);
                currentMarkerInstance = null;
            }
        }
    }

    public void OnMarkerClicked()
    {
        if (playerInRange && currentMarkerInstance != null)
        {
            Debug.Log("Player accepted the fight!");

            TeleportPlayerToBattleArena();
        }
    }

    void TeleportPlayerToBattleArena()
    {

        Vector3 battleArenaPosition = new Vector3(10, 10, 0);
        player.transform.position = battleArenaPosition;

        if (currentMarkerInstance != null)
        {
            Destroy(currentMarkerInstance);
            currentMarkerInstance = null;
        }
    }

    void Update()
    {

        if (playerInRange && currentMarkerInstance != null && Input.GetKeyDown(KeyCode.E))
        {
            OnMarkerClicked();
        }
    }
}
