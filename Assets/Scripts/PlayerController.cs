using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerData playerData;
    public bool constrainToXZ = true; // True pour mouvement sur XZ, False pour XY
    public Camera mainCamera; // Caméra principale
    public GameObject bulletPrefab; // Prefab du projectile
    public Transform firePoint; // Point de départ des projectiles (ex: un objet vide devant le joueur)
    public AudioSource shootingAudio;
    public float damageInterval = 5.0f;
    public int maxEnemiesForDamage = 5; // Limite d'ennemis infligeant des dégâts au joueur quand il sont en collision avec lui
    private int enemyCount = 0; // Compteur d'ennemis au contact du joueur
    private Coroutine damageCoroutine;
    void Update()
    {
        MovePlayer();
        RotateTowardsMouse();

        if (Input.GetMouseButtonDown(0)) // Clic gauche
        {
            FireBullet();
        }

        if(playerData.currentHP <= 0){
            if(damageCoroutine != null){
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
                // Debug.Log("Fin Coroutine");
            }
            Destroy(gameObject);
        } 
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection;
        if (constrainToXZ)
        {
            moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        }
        else
        {
            moveDirection = new Vector3(horizontalInput, verticalInput, 0);
        }

        transform.Translate(moveDirection.normalized * playerData.speed * Time.deltaTime, Space.World);
    }

    void RotateTowardsMouse()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane plane;

        if (constrainToXZ)
        {
            plane = new Plane(Vector3.up, transform.position); // Plan XZ
        }
        else
        {
            plane = new Plane(Vector3.forward, transform.position); // Plan XY
        }

        if (plane.Raycast(ray, out float distance))
        {
            Vector3 targetPoint = ray.GetPoint(distance);
            Vector3 direction = targetPoint - transform.position;
            direction.y = 0;

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }

    void FireBullet()
    {
        // Instancier le projectile au point de tir
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Récupérer le Rigidbody du projectile pour lui appliquer une vitesse
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        // Appliquer une force au projectile dans la direction du curseur
        bulletRb.velocity = firePoint.forward * bullet.GetComponent<BulletController>().bulletSpeed;
    
        if (shootingAudio != null){
            shootingAudio.Play();
        }
    }
    void OnTriggerEnter(Collider collision){
        if (collision.gameObject.tag == "target"){
            if(collision.gameObject.GetComponent<TargetData>().targetType != TargetList.bullet){
                // Debug.Log("touched");
                enemyCount++;
                if (damageCoroutine == null){
                    // Debug.Log("Debut Coroutine !");
                    damageCoroutine = StartCoroutine(ApplyDamagePeriodically());
                }

            }
        }
    }
    private void OnTriggerExit(Collider collision){
        if(collision.gameObject.tag == "target"){
            if(collision.gameObject.GetComponent<TargetData>().targetType != TargetList.bullet){
                enemyCount--;
                if(enemyCount <= 0 && damageCoroutine != null){
                    // Debug.Log("Fin Coroutine !");
                    StopCoroutine(damageCoroutine);
                    damageCoroutine = null;
                }
            }
        }
    }
    private IEnumerator ApplyDamagePeriodically(){
        while (enemyCount > 0){
            int enemiesDamages = Mathf.Min(enemyCount, maxEnemiesForDamage);

            playerData.currentHP -= enemiesDamages;
            // Debug.Log(playerData.currentHP);

            yield return new WaitForSeconds(damageInterval);
        }
    }

    // void OnCollisionEnter(Collision collision){
    //     Debug.Log(collision.gameObject.tag);
    //     if(collision.gameObject.tag == "target"){
    //         Debug.Log("am");
    //         if(collision.gameObject.GetComponent<TargetData>().targetType == TargetList.bullet){
    //             playerData.currentHP -= collision.gameObject.GetComponent<BulletController>().bulletDamage;
    //             Destroy(collision.gameObject);
    //         } else{
    //             Debug.Log("touched");
    //         }
    //     }
    // }
}
