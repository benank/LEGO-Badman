using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    [SerializeField] private float respawnTime = 2f;
    [SerializeField] private GameObject deathEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        LastSafezone.SetLastSafePosition(GameObject.FindGameObjectWithTag("Player").transform.position);
        Unity.LEGO.Game.EventManager.AddListener<Unity.LEGO.Game.DeathEvent>(OnPlayerDeath);
    }
    
    void OnPlayerDeath(Unity.LEGO.Game.DeathEvent evt)
    {
        StartCoroutine(RespawnCoroutine(evt));
    }
    
    IEnumerator RespawnCoroutine(Unity.LEGO.Game.DeathEvent evt)
    {
        Destroy(GameObject.Instantiate(deathEffect, evt.player.transform.position, evt.player.transform.rotation), 2f);
        yield return new WaitForSeconds(respawnTime);
        evt.player.GetComponent<Unity.LEGO.Minifig.MinifigController>().Respawn(LastSafezone.GetLastSafePosition());
    }
}
