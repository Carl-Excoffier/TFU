using UnityEngine;

public class FightManager : MonoBehaviour
{

    public Vector3 battleArenaPosition;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void StartBattle()
    {
        player.transform.position = battleArenaPosition;

        Debug.Log("Player teleported to battle arena!");
    }
}