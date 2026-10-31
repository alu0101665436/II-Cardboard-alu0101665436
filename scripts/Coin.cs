using UnityEngine;

/**
 * ================================ ETAPA 2 ================================
 * Crea una escena con Cardboard que tenga objetos que al llegar el jugador a 
 * ellos los recolecte con la vista. El jugador se puede desplazar con un mando 
 * o con la vista. La escena debe contener un terreno y objetos de algún paquete 
 * de la Asset Store.
 * =========================================================================
 */
public class Coin : MonoBehaviour {
  // Velocity
  private bool followPlayer = false;
  [SerializeField] private float speed = 1f;
  [SerializeField] private float rotateSpeed = 1f;
  [SerializeField] private GameObject player;


  // Tiempo de recolección
  private bool collected = false;
  private float elapsedPointerTime = 0.0f;
  [SerializeField] private float collectTime = 2.0f;

  // Interacción con el jugador
  private bool hovering = false;

  void Start() {
    // Escuchamos el cofre
    ListenToChest();   

    // Obtenemos el jugador
    if (player == null) {
      player = GameObject.FindWithTag("Player");
    }
  }
  
  void FixedUpdate() {
    // Persiguiendo al jugador
    if (followPlayer) {
      // Position Update
      Vector3 objective = player.GetComponent<Transform>().position;
      Vector3 direction = (objective - GetComponent<Transform>().position).normalized;

      // Velocity Update
      GetComponent<Rigidbody>().linearVelocity = direction * speed;
    }      
    
    // Recolección
    if (hovering && !collected) OnPointerStay();   
  }

  // Se pone en escucha del cofre
  void ListenToChest() {
    Chest chest = GameObject.FindWithTag("Beacon").GetComponent<Chest>();
    if (chest != null) {
      chest.OnItemCollected += FollowPlayer;
    }
  }
  
  // Desaparece si toca el jugador
  void OnCollisionEnter(Collision collision) {
    if (collision.collider.gameObject == player) {
      gameObject.SetActive(false);
    }
  }

  // Entrada en Observación
  void OnPointerEnter() {
    if (!collected) {
      hovering = true;
      elapsedPointerTime = 0.0f;
    }
  }
  
  // Se sale de la observación
  void OnPointerExit() {
    if (!collected) {
      hovering = false;
      elapsedPointerTime = 0.0f;
    }
  }

  // Mientras se observa
  void OnPointerStay() {
    elapsedPointerTime += Time.deltaTime;
    if (elapsedPointerTime >= collectTime) {
      // Coin retrieval
      collected = true;
      gameObject.SetActive(false);
    }
  }
  
  // Persigue al jugador
  void FollowPlayer() {
    // Seguimiento del jugador
    followPlayer = true;

    // Desactivamos la gravedad
    GetComponent<Rigidbody>().useGravity = false;
    GetComponent<Rigidbody>().angularVelocity = new Vector3(
      rotateSpeed * Random.Range(-1f, 1f), 
      rotateSpeed * Random.Range(-1f, 1f), 
      rotateSpeed * Random.Range(-1f, 1f)
      );
  }
}
