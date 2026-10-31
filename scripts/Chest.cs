using UnityEngine;
using UnityEngine.EventSystems;

/**
 * ================================ ETAPA 1 ================================
 * Elige un objeto en la escena que sirva para recuperar los que se recolectan. 
 * Cuando el jugador lo selecciona con la vista los recolectables se dirigen 
 * hacie el jugador.
 * =========================================================================
 */
public class Chest : MonoBehaviour {
  // Evento de recolección
  public delegate void ItemCollectedHandler();
  public event ItemCollectedHandler OnItemCollected;

  // Tiempo de recolección
  private bool collected = false;
  private float elapsedPointerTime = 0.0f;
  [SerializeField] private float collectTime = 2.0f;

  // Interacción con el jugador
  private bool hovering = false;
  
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
  
  // Simula el OnPointerStay
  void FixedUpdate() {
    if (hovering && !collected) OnPointerStay();
  }
  
  // Mientras se observa
  void OnPointerStay() {
    elapsedPointerTime += Time.deltaTime;
    if (elapsedPointerTime >= collectTime) {
      // Coin retrieval
      collected = true;
      OnItemCollected?.Invoke();
    }
  }

}
