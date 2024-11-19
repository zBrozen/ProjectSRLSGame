using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    TargetData data;

    public AudioSource deathSound;
    public AudioSource impactSound;

    private bool isDead = false;

    void Start() {
        data = this.gameObject.GetComponent<TargetData>();
    }

    void Update() {
        if(data.currentHP <= 0 && !isDead){
            isDead = true;
            StartCoroutine(DestroyAfterSound());
        }
    }

    private IEnumerator DestroyAfterSound() {
        transform.position = new Vector3(0f, -100f, 0f);
        deathSound.Play();
        yield return new WaitForSeconds(deathSound.clip.length);
        Destroy(gameObject);
    }

    // void OnTriggerEnter(Collider collision){
    //     Debug.Log(collision.gameObject.tag);
    //     if(collision.gameObject.tag == "player"){
    //         Debug.Log("bbbbbbbb");
    //         collision.gameObject.GetComponent<PlayerData>().currentHP -= damageAmount;
    //         Debug.Log(collision.gameObject.GetComponent<PlayerData>().currentHP);
    //     }
    // }
}
