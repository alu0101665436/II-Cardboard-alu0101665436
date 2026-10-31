# Etapa 1 — Proyecto Cardboard y compilación para Android

## Descripción

Preparar un proyecto de Unity para realidad virtual con Google Cardboard, probarlo en el editor y configurar una compilación para Android.

## Configuración

La configuración se basa en la [guía de inicio rápido de Google Cardboard para Unity](https://developers.google.com/cardboard/develop/unity/quickstart?hl=es-419). Los pasos siguientes resumen el proceso para Android:

### Requisitos

- Unity 6000.0.23f1 o posterior, con los módulos de compilación para Android instalados.
- Git instalado y disponible en la variable de entorno `PATH`, para importar el complemento desde Git URL.

### Crear el proyecto e importar el SDK

1. Se crea un proyecto **3D** en Unity.
2. Se abre **Window > Package Manager**, se pulsa **+** y se selecciona **Add package from git URL**.
3. Se introduce `https://github.com/googlevr/cardboard-xr-plugin.git` y se espera a que se instale **Google Cardboard XR Plugin for Unity**.
4. En la sección **Samples** del paquete, se selecciona **Import into Project**. Los recursos de ejemplo se importan en `Assets/Samples/Google Cardboard/<version>/Hello Cardboard`.

### Preparar la escena de ejemplo

1. Se abre `Assets/Samples/Google Cardboard/<version>/Hello Cardboard/Scenes/HelloCardboard`.
2. En **Edit > Project Settings > Tags and Layers**, se crea la capa `Interactive`.
3. Al objeto `Treasure` se le asigna la capa `Interactive`; si Unity lo solicita, también se aplica el cambio a sus objetos secundarios.
4. En `Player > Camera > CardboardReticlePointer`, se configura **Reticle Interaction Layer Mask** para que incluya `Interactive`.

### Configurar la compilación para Android

1. Se abre **File > Build Settings**, se selecciona **Android**, se pulsa **Switch Platform** y se añade la escena `HelloCardboard` con **Add Open Scenes**.
2. En **Edit > Project Settings > Player > Resolution and Presentation**, se establece la orientación predeterminada como **Landscape Left** o **Landscape Right** y se desactiva **Optimized Frame Pacing**.
3. En **Player > Other Settings**, se configuran los siguientes valores:
   - Una API de gráficos compatible, como **OpenGLES3** o **Vulkan**. OpenGLES2 no es compatible con Unity 2023.1 y versiones posteriores.
   - **Minimum API Level** en Android 8.0 (API 26) o posterior, y **Target API Level** en API 35 o posterior.
   - **Scripting Backend** en `IL2CPP` y **Target Architectures** en `ARMv7`, `ARM64` o ambas.
   - **Internet Access** en `Require`, **Active Input Handling** en `Input System Package (New)` y un identificador propio en **Package Name**.
   - Si se utiliza Vulkan, se desactiva **Apply display rotation during rendering** y se selecciona `ETC2` como formato de compresión de texturas.
   - En **Application Entry Point**, se selecciona `Activity` y se desactiva `GameActivity`.
4. En **Player > Publishing Settings > Build**, se habilitan **Custom Main Gradle Template** y **Custom Gradle Properties Template**. En la sección `dependencies` de `Assets/Plugins/Android/mainTemplate.gradle` se añaden estas dependencias:

   ```gradle
   implementation 'androidx.appcompat:appcompat:1.6.1'
   implementation 'com.google.android.gms:play-services-vision:20.1.3'
   implementation 'com.google.android.material:material:1.12.0'
   implementation 'com.google.protobuf:protobuf-javalite:3.19.4'
   ```

5. En `Assets/Plugins/Android/gradleTemplate.properties` se añaden estas propiedades:

   ```properties
   android.enableJetifier=true
   android.useAndroidX=true
   ```

6. En **XR Plug-in Management**, se selecciona **Cardboard XR Plugin** como proveedor de complementos para Android.
7. En **File > Build Settings**, se pulsa **Build** para generar el APK, o **Build and Run** para instalarlo y ejecutarlo en un dispositivo conectado.

Los nombres de algunas opciones pueden variar según la versión de Unity. La guía oficial y la configuración del SDK Cardboard sirven de referencia si cambian las dependencias de Gradle.

## Conceptos utilizados

- Integración de un visor VR mediante el complemento Cardboard.
- Configuración de la plataforma Android y generación de un paquete APK.
- Separación entre los scripts del repositorio y el proyecto Unity donde se ejecutan.

## Resultado

El proyecto queda preparado para ejecutar una escena Cardboard y generar una APK instalable en un dispositivo Android. La APK está incluida en el directorio **app/** como **cardboard.apk**.

---

### Navegación

[Volver al inicio](../../README.md) · [Ejercicio siguiente](./ETAPA2.md) →
