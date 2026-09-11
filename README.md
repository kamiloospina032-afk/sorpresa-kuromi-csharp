# 🖤 Sorpresa Kuromi en C# - Windows Forms

¡Una sorpresa interactiva con la temática de Kuromi! Hecha en C# con Windows Forms.

## 📋 Requisitos

- **.NET 6.0** o superior
- **Visual Studio Code** o **Visual Studio**
- **C# Extension** en VS Code

## 🚀 Cómo usar

### 1. Clonar el repositorio
```bash
git clone https://github.com/kamiloospina032-afk/sorpresa-kuromi-csharp.git
cd sorpresa-kuromi-csharp
```

### 2. Abrir en Visual Studio Code
```bash
code .
```

### 3. Compilar y ejecutar
```bash
dotnet run
```

O en Visual Studio:
- Abre el archivo `.sln`
- Presiona `F5` para ejecutar

## ✏️ Personalización

Abre el archivo **`FormSorpresa.cs`** y busca la sección:

```csharp
// ============================================================
// ⚙️  ZONA DE EDICIÓN — PERSONALIZACIÓN
// ============================================================
```

Aquí puedes cambiar:

### 🎀 Nombre
```csharp
private string nombre = "mi amor";  // ← Cambia aquí
```

### 💬 Textos principales
```csharp
private string tituloPortada = "¡Feliz cumpleaños {{nombre}}!";
private string preguntaPortada = "¿Quieres ver tu sorpresa?";
```

### 🖤 Frases para convencer (cuando hace clic en "No gracias")
```csharp
private string[] frasesConvencer = new[]
{
    "¿Segura que no quieres ver tu sorpresa? 🥺",
    "Porfaaa, va a ser increíble 🖤",
    // Agrega más aquí...
};
```

### ✨ Sorpresas (Grid 2x2)
```csharp
private Sorpresa[] sorpresas = new[]
{
    new Sorpresa { Icono = "🖤", Mensaje = "Te quiero un montón" },
    new Sorpresa { Icono = "💀", Mensaje = "Eres mi persona favorita" },
    // Agrega más aquí...
};
```

### 💬 Piropos
```csharp
private string[] piropos = new[]
{
    "Te quiero muchísimo",
    "Eres mi persona favorita",
    // Agrega más aquí...
};
```

### 💌 Carta final
```csharp
private string cartaIzquierda = "Te amo porque...";
private string cartaDerecha = "Gracias por cada momento...";
private string firma = "Con cariño, tu Kuromi 🖤";
```

## 🎨 Colores Kuromi

Los colores ya están configurados en el tema de Kuromi:

```csharp
private Color bgDeep = Color.FromArgb(23, 10, 29);           // Morado oscuro
private Color cardBg = Color.FromArgb(255, 227, 240);        // Rosa claro
private Color pink = Color.FromArgb(255, 46, 136);           // Rosa Kuromi
private Color purple = Color.FromArgb(91, 42, 134);          // Morado Kuromi
```

Para cambiar los colores, modifica estos valores RGB.

## 📄 Estructura del proyecto

```
sorpresa-kuromi-csharp/
├── SorpresaKuromi.csproj  (Configuración del proyecto)
├── Program.cs              (Punto de entrada)
├── FormSorpresa.cs         (Formulario principal - EDITA AQUÍ)
└── README.md               (Este archivo)
```

## 🎯 Páginas de la sorpresa

1. **Portada** - Pregunta si quieres ver la sorpresa (botón "No" escurridizo)
2. **Sorpresas** - Grid de 4 sorpresas para destapar (debe destapar todas)
3. **Piropos** - Frases bonitas con emojis flotantes
4. **Información** - Sección de texto especial
5. **Galería** - Espacio para fotos (placeholders)
6. **Carta final** - Mensaje personalizado y botón para reiniciar

## 🔧 Desarrollo

Para agregar más funcionalidad:

1. Abre `FormSorpresa.cs`
2. Busca el método de la página que quieres modificar (ej: `ConstruirPagina0`)
3. Realiza cambios
4. Guarda y ejecuta con `dotnet run`

## 📝 Notas

- Los colores, textos y emojis pueden personalizarse completamente
- La aplicación se ejecuta en una ventana de 450x800 px
- Usa `{{nombre}}` en los textos para que se reemplace automáticamente

## 🖤 Temática Kuromi

- **Colores**: Morado oscuro + Rosa intenso + Blanco roto
- **Emojis**: 🖤 💀 🩷 ✨ 🎀
- **Fuentes**: Baloo 2 (títulos) y Poppins (cuerpo)
- **Vibes**: Misterioso, adorable y con actitud

---

**¡Hecho con amor para tu persona especial! 💀🩷**
