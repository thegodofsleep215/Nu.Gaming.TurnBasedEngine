using System.Drawing;
using System.Windows.Forms;
using Solitaire;

namespace WinSolitaire
{
    public partial class Form1 : Form
    {
        private SolitaireBoard board = new SolitaireBoard();

        private float cardWidth = 100;

        private float cardHeight = 150;

        private Color backgroundColor = Color.DarkGray;
        private Brush backgroundBrush = Brushes.DarkGray;

        #region Points

        private float deckX = 10;
        private float deckY = 10;
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void DrawFaceDownCard(Graphics g, float x, float y)
        {
            g.FillRectangle(Brushes.White, x, y, cardWidth, cardHeight);
            g.FillRectangle(Brushes.Blue, x + 10, y + 10, cardWidth - 20, cardHeight - 20);
            
        }

        private void DrawEmptyZone(Graphics g, float x, float y)
        {
            g.FillRectangle(Brushes.Aquamarine, x, y, cardWidth, cardHeight);
            g.FillRectangle(backgroundBrush, x + 10, y + 10, cardWidth - 20, cardHeight - 20);
        }

        private void DrawDeck(Graphics g)
        {
            DrawFaceDownCard(g, deckX, deckY);
        }

        private void DrawPile(Graphics g)
        {
            DrawEmptyZone(g, cardWidth + deckX + 10, deckY);
        }

        private void DrawPlayZones(Graphics g)
        {
           
        }

        private void DrawFinishZone(Graphics g)
        {
            
        }

        private void DrawGame(Graphics g)
        {
            g.Clear(backgroundColor);
            DrawDeck(g);
            DrawPile(g);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawGame(e.Graphics);
        }
    }
}
