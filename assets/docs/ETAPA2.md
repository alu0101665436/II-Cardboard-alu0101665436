# Etapa 2 — Escena, assets y recolección con la mirada

## Descripción

Crear una escena Cardboard explorable con un terreno y objetos de un paquete de la Asset Store. El jugador puede avanzar mediante un mando o inclinando la mirada hacia abajo. Se utiliza un asset de bosque como entorno y unas monedas que se recogen al mantener la vista sobre ellas.

## Configuración

1. Se añade un terreno a la escena y se importa un paquete de la Asset Store para utilizar sus modelos como entorno y coleccionables.
2. Se configura el jugador con una cámara Cardboard, un `CharacterController` y el script `VRPlayerMovement` (`scripts/Player.cs`). La cámara se asigna al campo `vrCamera` y el objeto del jugador se etiqueta como `Player`.
3. El script permite el movimiento con WASD o las flechas, y con el stick izquierdo de un mando. Si no hay mando conectado, mirar hacia abajo más allá del ángulo `maxPitch` hace avanzar al jugador. La velocidad inicial se establece en `2`.
4. Se añade un `Rigidbody` y un collider a cada moneda, y se le asigna el script `Coin` (`scripts/Coin.cs`). La referencia `player` se configura o se deja que el script busque el objeto con la etiqueta `Player`.
5. Se configura el puntero/retícula de Cardboard para que invoque `OnPointerEnter` y `OnPointerExit` en la moneda observada. Al mantener la mirada durante `collectTime` (dos segundos por defecto), la moneda se desactiva.
6. Para que las monedas puedan atraerse en la etapa siguiente, se añade a la escena un objeto con el script `Chest`, la etiqueta `Beacon` y un collider. También se configuran en él los eventos de entrada y salida del puntero.

## Conceptos utilizados

- Movimiento relativo a la orientación de la cámara, con teclado, mando o inclinación de cabeza.
- Gestor de Input moderno de **Unity**.
- `CharacterController` y aplicación de gravedad para el desplazamiento del jugador.
- Interacción por mirada temporizada mediante eventos de entrada y salida del puntero.
- Colliders y `Rigidbody` para las monedas y sus interacciones físicas.

## Resultado

![SegundaEtapaGif](../videos/Etapa2.gif)

(Como se utiliza la propia interfaz de unity, no se pueden realizar rotaciones con la mirada, por lo que se mueve la moneda para que esté a la vista del jugador manualmente y desactivando la gravedad)

Una escena de exploración con terreno y assets importados en la que el jugador puede desplazarse y recoger monedas manteniéndolas en la vista.

---

### Navegación

← [Etapa anterior](./ETAPA1.md) · [Volver al inicio](../../README.md) · [Ejercicio siguiente](./ETAPA3.md) →
