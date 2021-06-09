using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnManager : MonoBehaviour
{
    [SerializeField] private float respawnTime = 2f;
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private bool oneLife = false;
    
    // Start is called before the first frame update
    void Start()
    {
        LastSafezone.SetLastSafePosition(GameObject.FindGameObjectWithTag("Player").transform.position);
        Unity.LEGO.Game.EventManager.AddListener<Unity.LEGO.Game.DeathEvent>(OnPlayerDeath);
        GameInfo.ActiveScene = SceneManager.GetActiveScene().name;
    }
    
    void OnDestroy()
    {
        Unity.LEGO.Game.EventManager.RemoveListener<Unity.LEGO.Game.DeathEvent>(OnPlayerDeath);
    }
    
    void OnPlayerDeath(Unity.LEGO.Game.DeathEvent evt)
    {
        if (oneLife)
        {
            // Trigger game win event
            Unity.LEGO.Game.Events.GameOverEvent.Win = true;
            Unity.LEGO.Game.EventManager.Broadcast(Unity.LEGO.Game.Events.GameOverEvent);
            StartCoroutine(LoadGameOver(evt));
        }
        else
        {
            StartCoroutine(RespawnCoroutine(evt));
        }
    }

    IEnumerator LoadGameOver(Unity.LEGO.Game.DeathEvent evt)
    {
        Destroy(GameObject.Instantiate(deathEffect, evt.player.transform.position, evt.player.transform.rotation), 2f);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("GameOver");
    }
    
    IEnumerator RespawnCoroutine(Unity.LEGO.Game.DeathEvent evt)
    {
        Destroy(GameObject.Instantiate(deathEffect, evt.player.transform.position, evt.player.transform.rotation), 2f);
        yield return new WaitForSeconds(respawnTime);
        evt.player.GetComponent<HealthController>().OnRespawn();
        evt.player.GetComponent<Unity.LEGO.Minifig.MinifigController>().Respawn(LastSafezone.GetLastSafePosition());
    }
}
