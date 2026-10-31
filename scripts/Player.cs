using UnityEngine;
using UnityEngine.InputSystem;

/**
 * ================================ ETAPA 2 ================================
 * Crear el proyecto Cardboard y experimentar y generar una apk para Android.
 * =========================================================================
 */
public class VRPlayerMovement : MonoBehaviour {
  [Header("References")]
  [SerializeField] private Transform vrCamera;

  [Header("Moovement")]
  [SerializeField] private float speed = 2f;
  [SerializeField] private float gravity = -9.81f;

  [Header("Options")]
  [SerializeField] private float maxPitch = 20f;

  private CharacterController controller;
  private Vector3 verticalVelocity;

  void Awake() {
    controller = GetComponent<CharacterController>();
  }

  void Update() {
    // Movimiento
    Vector2 input = Vector2.zero;
    
    // Teclado (Input Manager Moderno)
    if (Keyboard.current != null) {
      if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) {
        input.y += 1;
      }
      if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) {
        input.y -= 1;
      }
      if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) {
        input.x += 1;
      }
      if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) {
        input.x -= 1;
      }
    }
    
    // Movimiento con Joystick (tiene que estar un mando conectado)
    if (Gamepad.current != null) {
      Vector2 stick = Gamepad.current.leftStick.ReadValue();
      if (stick.sqrMagnitude > 0.01f) {
        input = stick;
      }
    }

    // Posición actual de la Cámara (Por seguridad, si no está asignada mira su propio transform)
    Transform view = vrCamera != null ? vrCamera : transform;
    
    // Ángulo vertical de la mirada
    float pitch = Mathf.Asin(Mathf.Clamp(view.forward.y, -1f, 1f)) * Mathf.Rad2Deg;
    bool lookMovement = pitch <= -maxPitch;
    
    Vector3 moveDirection;
    
    // Si hay input manual, tiene prioridad.
    if (input.sqrMagnitude > 0.01f) {
      Vector3 forward = Vector3.ProjectOnPlane(
        view.forward, Vector3.up
      ).normalized;
    
      Vector3 right = Vector3.ProjectOnPlane(
        view.right, Vector3.up
      ).normalized;
    
      moveDirection = forward * input.y + right * input.x;
    }

    // Avanza siguiendo la inclinación de la cabeza (si no hay mando)
    else if (lookMovement && Gamepad.current == null) {
      moveDirection = view.forward.normalized;
    } 
    
    // Si no hay input
    else {
      moveDirection = Vector3.zero;
    }
    Vector3 move = moveDirection * speed;
    
    // Gravedad
    if (controller.isGrounded && verticalVelocity.y < 0f) {
      verticalVelocity.y = -2f;
    }
    verticalVelocity.y += gravity * Time.deltaTime;
    
    // Aplicar movimiento y gravedad
    controller.Move(
      (move + verticalVelocity) * Time.deltaTime
    );
  }
}
