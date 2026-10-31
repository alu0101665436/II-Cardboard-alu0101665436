# Etapa 3 — Baliza que recupera los coleccionables

## Descripción

Añadir a la escena un objeto que permita recuperar las monedas que todavía no se han recogido. Cuando el jugador observa la baliza durante el tiempo configurado, las monedas activas dejan de esperar a ser miradas y se desplazan hacia el jugador.

## Configuración

1. El objeto preparado en la etapa anterior se utiliza como baliza y se configura con el script `Chest` (`scripts/Chest.cs`), un collider y la etiqueta `Beacon`.
2. El puntero Cardboard se conecta a `OnPointerEnter` y `OnPointerExit` de la baliza. Al mantenerla en la mira durante los dos segundos definidos por `collectTime`, `Chest` emite `OnItemCollected`.
3. Cada moneda se configura con el script `Coin`, un `Rigidbody` y un collider; el jugador se etiqueta como `Player`; y la baliza se etiqueta como `Beacon` y recibe el script `Chest`. Al iniciarse, cada moneda se suscribe al evento de la baliza.
4. Al recibir el evento, cada moneda desactiva la gravedad y se desplaza hacia la posición del jugador. Cuando colisiona con él, se desactiva. La velocidad de seguimiento se configura mediante `speed`.

## Conceptos utilizados

- Eventos C# (`OnItemCollected`) para comunicar la selección de la baliza a las monedas.
- Suscripción de los coleccionables al evento de la baliza.
- Movimiento físico con `Rigidbody` y detección de colisiones para recuperar monedas.
- Reutilización de la selección por mirada temporizada de la etapa anterior.

## Resultado

![TerceraEtapaGif](../videos/Etapa3.gif)

(Como se utiliza la propia interfaz de unity, no se pueden realizar rotaciones con la mirada, por lo que se mueve el cofre para que esté a la vista del jugador manualmente)

Al mirar la baliza durante el tiempo requerido, las monedas activas vuelan hacia el jugador y desaparecen al tocarlo. La moneda también puede recogerse directamente manteniéndola en la mira, como en la etapa anterior. La APK con todo este contenido está incluida en el directorio **app/** como **forest_treasure_hunt.apk**.

---

### Navegación

← [Etapa anterior](./ETAPA2.md) · [Volver al inicio](../../README.md)
