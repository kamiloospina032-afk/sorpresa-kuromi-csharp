using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SorpresaKuromi
{
    public partial class FormSorpresa : Form
    {
        // ============================================================
        // ⚙️  ZONA DE EDICIÓN — PERSONALIZACIÓN
        // ============================================================
        
        private string nombre = "mi amor";
        private string tituloPortada = "¡Feliz cumpleaños {{nombre}}!";
        private string preguntaPortada = "¿Quieres ver tu sorpresa?";
        
        private string[] frasesConvencer = new[]
        {
            "¿Segura que no quieres ver tu sorpresa? 🥺",
            "Porfaaa, va a ser increíble 🖤",
            "Vamos, dale que sí 🩷",
            "¡Solo un clic más y ya! 💀🩷",
            "Está bien... pero di que sí porfavor"
        };

        private string tituloSorpresa = "¡Sorpresaaa {{nombre}}!!";
        private string subtituloSorpresa = "Haz clic en cada uno";
        
        private Sorpresa[] sorpresas = new[]
        {
            new Sorpresa { Icono = "🖤", Mensaje = "Te quiero un montón" },
            new Sorpresa { Icono = "💀", Mensaje = "Eres mi persona favorita" },
            new Sorpresa { Icono = "🩷", Mensaje = "Gracias por existir" },
            new Sorpresa { Icono = "✨", Mensaje = "Esto es solo el inicio" }
        };

        private string tituloPiropos = "Todo esto es para ti";
        private string[] piropos = new[]
        {
            "Te quiero muchísimo",
            "Eres mi persona favorita",
            "Todo lo que amo",
            "Me encantas tal cual eres",
            "Eres la mejor",
            "Te mereces lo mejor",
            "Eres tan especial",
            "Iluminas mis días"
        };

        private string tituloCartas = "Te dedico esto {{nombre}}";
        private string cartaIzquierda = "Te amo porque contigo puedo ser yo misma, sin miedo a mostrar lo que siento, mis alegrías, mis inseguridades y hasta esos pequeños detalles que quizá para los demás no significan nada, pero que contigo se sienten diferentes.";
        private string cartaDerecha = "Gracias por cada momento a tu lado. Quiero que sepas que eres una persona muy especial para mí y que valoro cada instante contigo. Esto es solo un pequeño detalle para decirte cuánto te quiero.";
        private string firma = "Con cariño, tu Kuromi 🖤";

        // ============================================================
        // Variables de control
        // ============================================================
        
        private int paginaActual = 0;
        private int dodgesCount = 0;
        private List<Panel> panelesSorpresas = new List<Panel>();
        private bool[] sorpresasDestapadas;
        private bool[] bloqueos = new bool[6]; // bloqueo por página

        // Colores Kuromi
        private Color bgDeep = Color.FromArgb(23, 10, 29);           // #170a1d
        private Color cardBg = Color.FromArgb(255, 227, 240);        // #ffe3f0
        private Color pink = Color.FromArgb(255, 46, 136);           // #ff2e88
        private Color purple = Color.FromArgb(91, 42, 134);          // #5b2a86
        private Color purpleDark = Color.FromArgb(44, 15, 61);       // #2c0f3d
        private Color whiteKuromi = Color.FromArgb(255, 248, 252);   // #fff8fc

        public FormSorpresa()
        {
            InitializeComponent();
            this.Text = "Sorpresa Kuromi";
            this.ClientSize = new Size(450, 800);
            this.BackColor = bgDeep;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Poppins", 10);

            sorpresasDestapadas = new bool[4];
            bloqueos[1] = true; // Página 1 bloqueada hasta destapar todas las sorpresas

            MostrarPagina(0);
        }

        private void MostrarPagina(int numeroPagina)
        {
            this.Controls.Clear();
            paginaActual = numeroPagina;
            panelesSorpresas.Clear();

            // Panel principal con colores Kuromi
            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = cardBg,
                AutoScroll = true
            };

            switch (numeroPagina)
            {
                case 0:
                    ConstruirPagina0(mainPanel);
                    break;
                case 1:
                    ConstruirPagina1(mainPanel);
                    break;
                case 2:
                    ConstruirPagina2(mainPanel);
                    break;
                case 3:
                    ConstruirPagina3(mainPanel);
                    break;
                case 4:
                    ConstruirPagina4(mainPanel);
                    break;
                case 5:
                    ConstruirPagina5(mainPanel);
                    break;
            }

            this.Controls.Add(mainPanel);
            AgregarBotonesNavegacion();
        }

        // ============================================================
        // PÁGINA 0 — PORTADA
        // ============================================================
        private void ConstruirPagina0(Panel mainPanel)
        {
            Panel contenedor = new Panel { Dock = DockStyle.Fill, AutoScroll = true };
            contenedor.BackColor = cardBg;

            // Título
            Label lblTitulo = new Label
            {
                Text = Reemplazar(tituloPortada),
                Font = new Font("Baloo 2", 18, FontStyle.Bold),
                ForeColor = purpleDark,
                AutoSize = false,
                Width = 400,
                Height = 80,
                Left = 25,
                Top = 50,
                TextAlign = ContentAlignment.TopCenter
            };
            contenedor.Controls.Add(lblTitulo);

            // Pregunta
            Label lblPregunta = new Label
            {
                Text = preguntaPortada,
                Font = new Font("Poppins", 12),
                ForeColor = Color.FromArgb(44, 16, 51),
                AutoSize = false,
                Width = 400,
                Height = 50,
                Left = 25,
                Top = 140,
                TextAlign = ContentAlignment.TopCenter
            };
            contenedor.Controls.Add(lblPregunta);

            // Emoji Kuromi 🖤
            Label lblEmoji = new Label
            {
                Text = "🖤",
                Font = new Font("Arial", 60),
                ForeColor = pink,
                AutoSize = false,
                Width = 400,
                Height = 80,
                Left = 25,
                Top = 200,
                TextAlign = ContentAlignment.TopCenter
            };
            contenedor.Controls.Add(lblEmoji);

            // Botones
            Button btnNo = new Button
            {
                Text = "No gracias",
                Width = 100,
                Height = 45,
                Left = 50,
                Top = 320,
                BackColor = Color.White,
                ForeColor = purpleDark,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Poppins", 11, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnNo.FlatAppearance.BorderColor = purpleDark;
            btnNo.FlatAppearance.BorderSize = 2;
            btnNo.MouseEnter += (s, e) => BotonNoEscapar(btnNo, lblPregunta);
            btnNo.Click += (s, e) => BotonNoEscapar(btnNo, lblPregunta);

            Button btnSi = new Button
            {
                Text = "Sí porfavor",
                Width = 100,
                Height = 45,
                Left = 260,
                Top = 320,
                BackColor = pink,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Poppins", 11, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSi.FlatAppearance.BorderSize = 0;
            btnSi.Click += (s, e) => MostrarPagina(1);

            contenedor.Controls.Add(btnNo);
            contenedor.Controls.Add(btnSi);

            mainPanel.Controls.Add(contenedor);
        }

        private void BotonNoEscapar(Button btnNo, Label lblPregunta)
        {
            Random rand = new Random();
            int x = rand.Next(-100, 100);
            int y = rand.Next(-50, 50);
            btnNo.Left = Math.Max(10, Math.Min(350, btnNo.Left + x));
            btnNo.Top = Math.Max(10, Math.Min(400, btnNo.Top + y));

            if (dodgesCount < frasesConvencer.Length)
            {
                lblPregunta.Text = frasesConvencer[dodgesCount];
            }
            dodgesCount++;
        }

        // ============================================================
        // PÁGINA 1 — SORPRESAS (GRID 2x2)
        // ============================================================
        private void ConstruirPagina1(Panel mainPanel)
        {
            Panel contenedor = new Panel { Dock = DockStyle.Fill, AutoScroll = true };
            contenedor.BackColor = cardBg;

            Label lblTitulo = new Label
            {
                Text = Reemplazar(tituloSorpresa),
                Font = new Font("Baloo 2", 16, FontStyle.Bold),
                ForeColor = purpleDark,
                AutoSize = false,
                Width = 400,
                Height = 50,
                Left = 25,
                Top = 30,
                TextAlign = ContentAlignment.TopCenter
            };
            contenedor.Controls.Add(lblTitulo);

            Label lblSubtitulo = new Label
            {
                Text = subtituloSorpresa,
                Font = new Font("Poppins", 10),
                ForeColor = Color.FromArgb(44, 16, 51),
                AutoSize = false,
                Width = 400,
                Height = 30,
                Left = 25,
                Top = 80,
                TextAlign = ContentAlignment.TopCenter
            };
            contenedor.Controls.Add(lblSubtitulo);

            // Grid 2x2 de sorpresas
            int posX = 40;
            int posY = 130;
            int size = 130;
            int gap = 30;
            int indice = 0;

            for (int fila = 0; fila < 2; fila++)
            {
                for (int col = 0; col < 2; col++)
                {
                    Panel tile = new Panel
                    {
                        Width = size,
                        Height = size,
                        Left = posX + col * (size + gap),
                        Top = posY + fila * (size + gap),
                        BackColor = purple,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    tile.BorderStyle = BorderStyle.FixedSingle;

                    int idx = indice;
                    tile.Click += (s, e) => DestaparSorpresa(tile, idx);
                    
                    // Texto "?" inicial
                    Label lblPregunta = new Label
                    {
                        Text = "?",
                        Font = new Font("Baloo 2", 36, FontStyle.Bold),
                        ForeColor = Color.White,
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Cursor = Cursors.Hand
                    };
                    tile.Controls.Add(lblPregunta);
                    panelesSorpresas.Add(tile);
                    contenedor.Controls.Add(tile);
                    indice++;
                }
            }

            mainPanel.Controls.Add(contenedor);
        }

        private void DestaparSorpresa(Panel tile, int indice)
        {
            if (sorpresasDestapadas[indice]) return;

            sorpresasDestapadas[indice] = true;
            tile.BackColor = pink;
            tile.Controls.Clear();

            Label lblContent = new Label
            {
                Text = sorpresas[indice].Icono + "\n" + sorpresas[indice].Mensaje,
                Font = new Font("Poppins", 9, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            tile.Controls.Add(lblContent);

            // Verificar si todas están destapadas
            if (sorpresasDestapadas.All(x => x))
            {
                bloqueos[1] = false;
            }
        }

        // ============================================================
        // PÁGINA 2 — PIROPOS
        // ============================================================
        private void ConstruirPagina2(Panel mainPanel)
        {
            Panel contenedor = new Panel { Dock = DockStyle.Fill, AutoScroll = true };
            contenedor.BackColor = cardBg;

            Label lblTitulo = new Label
            {
                Text = tituloPiropos,
                Font = new Font("Baloo 2", 16, FontStyle.Bold),
                ForeColor = purpleDark,
                AutoSize = false,
                Width = 400,
                Height = 50,
                Left = 25,
                Top = 30,
                TextAlign = ContentAlignment.TopCenter
            };
            contenedor.Controls.Add(lblTitulo);

            // Emoji Kuromi
            Label lblEmoji = new Label
            {
                Text = "💀🩷",
                Font = new Font("Arial", 48),
                AutoSize = false,
                Width = 400,
                Height = 60,
                Left = 25,
                Top = 80,
                TextAlign = ContentAlignment.TopCenter
            };
            contenedor.Controls.Add(lblEmoji);

            // Panel de piropos
            Panel panelPiropos = new Panel
            {
                Width = 400,
                Height = 600,
                Left = 25,
                Top = 150,
                AutoScroll = true
            };

            int posY = 10;
            foreach (string piropo in piropos)
            {
                Panel piropopanel = new Panel
                {
                    Width = 370,
                    Height = 50,
                    Left = 5,
                    Top = posY,
                    BackColor = whiteKuromi,
                    BorderStyle = BorderStyle.FixedSingle
                };

                Label lblPiropo = new Label
                {
                    Text = piropo,
                    Font = new Font("Poppins", 10, FontStyle.Bold),
                    ForeColor = purple,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                piropopanel.Controls.Add(lblPiropo);
                panelPiropos.Controls.Add(piropopanel);
                posY += 60;
            }

            contenedor.Controls.Add(panelPiropos);
            mainPanel.Controls.Add(contenedor);
        }

        // ============================================================
        // PÁGINA 3 — INFORMACIÓN
        // ============================================================
        private void ConstruirPagina3(Panel mainPanel)
        {
            Panel contenedor = new Panel { Dock = DockStyle.Fill, AutoScroll = true };
            contenedor.BackColor = cardBg;

            Label lblTitulo = new Label
            {
                Text = "Información especial",
                Font = new Font("Baloo 2", 16, FontStyle.Bold),
                ForeColor = purpleDark,
                AutoSize = false,
                Width = 400,
                Height = 50,
                Left = 25,
                Top = 30,
                TextAlign = ContentAlignment.TopCenter
            };
            contenedor.Controls.Add(lblTitulo);

            Label lblEmoji = new Label
            {
                Text = "✨",
                Font = new Font("Arial", 48),
                AutoSize = false,
                Width = 400,
                Height = 60,
                Left = 25,
                Top = 80,
                TextAlign = ContentAlignment.TopCenter
            };
            contenedor.Controls.Add(lblEmoji);

            Label lblInfo = new Label
            {
                Text = "Eres una persona increíble y mereces ser feliz todos los días. Gracias por estar en mi vida y hacer que cada momento sea especial.",
                Font = new Font("Poppins", 11),
                ForeColor = Color.FromArgb(44, 16, 51),
                AutoSize = false,
                Width = 350,
                Height = 150,
                Left = 50,
                Top = 160,
                TextAlign = ContentAlignment.TopCenter
            };
            contenedor.Controls.Add(lblInfo);

            mainPanel.Controls.Add(contenedor);
        }

        // ============================================================
        // PÁGINA 4 — GALERÍA
        // ============================================================
        private void ConstruirPagina4(Panel mainPanel)
        {
            Panel contenedor = new Panel { Dock = DockStyle.Fill, AutoScroll = true };
            contenedor.BackColor = cardBg;

            Label lblTitulo = new Label
            {
                Text = "Mis fotos favoritas",
                Font = new Font("Baloo 2", 16, FontStyle.Bold),
                ForeColor = purpleDark,
                AutoSize = false,
                Width = 400,
                Height = 50,
                Left = 25,
                Top = 30,
                TextAlign = ContentAlignment.TopCenter
            };
            contenedor.Controls.Add(lblTitulo);

            // Espacio para fotos (placeholders)
            int posX = 40;
            int posY = 100;
            for (int i = 0; i < 4; i++)
            {
                Panel fotoPanel = new Panel
                {
                    Width = 150,
                    Height = 150,
                    Left = posX + (i % 2) * 160,
                    Top = posY + (i / 2) * 160,
                    BackColor = Color.FromArgb(238, 203, 221),
                    BorderStyle = BorderStyle.FixedSingle
                };

                Label lblFoto = new Label
                {
                    Text = "🖼️\nAgreга foto " + (i + 1),
                    Font = new Font("Poppins", 9),
                    ForeColor = purple,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                fotoPanel.Controls.Add(lblFoto);
                contenedor.Controls.Add(fotoPanel);
            }

            mainPanel.Controls.Add(contenedor);
        }

        // ============================================================
        // PÁGINA 5 — CARTA FINAL
        // ============================================================
        private void ConstruirPagina5(Panel mainPanel)
        {
            Panel contenedor = new Panel { Dock = DockStyle.Fill, AutoScroll = true };
            contenedor.BackColor = cardBg;

            Label lblTitulo = new Label
            {
                Text = Reemplazar(tituloCartas),
                Font = new Font("Baloo 2", 16, FontStyle.Bold),
                ForeColor = purpleDark,
                AutoSize = false,
                Width = 400,
                Height = 50,
                Left = 25,
                Top = 30,
                TextAlign = ContentAlignment.TopCenter
            };
            contenedor.Controls.Add(lblTitulo);

            Label lblEmoji = new Label
            {
                Text = "💌",
                Font = new Font("Arial", 48),
                AutoSize = false,
                Width = 400,
                Height = 60,
                Left = 25,
                Top = 80,
                TextAlign = ContentAlignment.TopCenter
            };
            contenedor.Controls.Add(lblEmoji);

            // Carta izquierda
            Label lblCartaIzq = new Label
            {
                Text = cartaIzquierda,
                Font = new Font("Poppins", 10),
                ForeColor = Color.FromArgb(44, 16, 51),
                AutoSize = false,
                Width = 350,
                Height = 120,
                Left = 50,
                Top = 150,
                TextAlign = ContentAlignment.TopLeft
            };
            lblCartaIzq.BorderStyle = BorderStyle.FixedSingle;
            contenedor.Controls.Add(lblCartaIzq);

            // Carta derecha
            Label lblCartaDer = new Label
            {
                Text = cartaDerecha,
                Font = new Font("Poppins", 10),
                ForeColor = Color.FromArgb(44, 16, 51),
                AutoSize = false,
                Width = 350,
                Height = 120,
                Left = 50,
                Top = 280,
                TextAlign = ContentAlignment.TopLeft
            };
            lblCartaDer.BorderStyle = BorderStyle.FixedSingle;
            contenedor.Controls.Add(lblCartaDer);

            // Firma
            Label lblFirma = new Label
            {
                Text = firma,
                Font = new Font("Baloo 2", 14, FontStyle.Bold),
                ForeColor = pink,
                AutoSize = false,
                Width = 350,
                Height = 50,
                Left = 50,
                Top = 410,
                TextAlign = ContentAlignment.TopCenter
            };
            contenedor.Controls.Add(lblFirma);

            // Botón de reinicio
            Button btnReiniciar = new Button
            {
                Text = "Volver a ver la sorpresa",
                Width = 200,
                Height = 45,
                Left = 125,
                Top = 470,
                BackColor = purple,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Poppins", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnReiniciar.FlatAppearance.BorderSize = 0;
            btnReiniciar.Click += (s, e) => { dodgesCount = 0; Array.Clear(sorpresasDestapadas, 0, sorpresasDestapadas.Length); MostrarPagina(0); };
            contenedor.Controls.Add(btnReiniciar);

            mainPanel.Controls.Add(contenedor);
        }

        // ============================================================
        // BOTONES DE NAVEGACIÓN
        // ============================================================
        private void AgregarBotonesNavegacion()
        {
            // Botón anterior
            Button btnAnterior = new Button
            {
                Text = "← Anterior",
                Width = 100,
                Height = 40,
                Left = 20,
                Top = Height - 70,
                BackColor = purple,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Poppins", 9, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnAnterior.FlatAppearance.BorderSize = 0;
            btnAnterior.Enabled = paginaActual > 0;
            btnAnterior.Click += (s, e) => MostrarPagina(paginaActual - 1);
            this.Controls.Add(btnAnterior);

            // Botón siguiente
            Button btnSiguiente = new Button
            {
                Text = "Siguiente →",
                Width = 100,
                Height = 40,
                Left = Width - 130,
                Top = Height - 70,
                BackColor = pink,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Poppins", 9, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSiguiente.FlatAppearance.BorderSize = 0;
            btnSiguiente.Enabled = paginaActual < 5 && !bloqueos[paginaActual];
            btnSiguiente.Click += (s, e) => MostrarPagina(paginaActual + 1);
            this.Controls.Add(btnSiguiente);

            // Label de página actual
            Label lblPagina = new Label
            {
                Text = $"Página {paginaActual + 1} de 6",
                Font = new Font("Poppins", 8),
                ForeColor = Color.Gray,
                AutoSize = true,
                Left = (Width / 2) - 50,
                Top = Height - 65
            };
            this.Controls.Add(lblPagina);
        }

        // ============================================================
        // UTILIDADES
        // ============================================================
        private string Reemplazar(string texto)
        {
            return texto.Replace("{{nombre}}", nombre);
        }
    }

    public class Sorpresa
    {
        public string Icono { get; set; }
        public string Mensaje { get; set; }
    }
}
