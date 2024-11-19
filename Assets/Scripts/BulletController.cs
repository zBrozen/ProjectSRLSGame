using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int bulletDamage;
    public int bulletSpeed;

    private bool hasCollided = false;
    
    void Start(){
        Destroy(gameObject, 3);
    }

    void Update(){
        if(this.gameObject.TryGetComponent<TargetData>(out TargetData data)){
            if(data.currentHP <= 0) Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider collision){
        if(this.gameObject.tag != "target" && collision.gameObject.tag == "target"){
            if(!hasCollided){
                hasCollided = true;
                collision.gameObject.GetComponent<TargetData>().currentHP -= bulletDamage;
                collision.gameObject.GetComponent<EnemyController>().impactSound.Play();
                Destroy(gameObject);
            }
        } else if(this.gameObject.tag == "target" && collision.gameObject.tag != "target"){
            Debug.Log("Touché ahah !");
            collision.gameObject.GetComponent<PlayerData>().currentHP -= bulletDamage;
            Debug.Log(collision.gameObject.GetComponent<PlayerData>().currentHP);
            Destroy(gameObject);
        }
    }
}
