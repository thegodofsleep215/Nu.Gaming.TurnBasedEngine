using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Solitaire;
using Solitaire.GameObjects;
using Solitaire.ViewModel;

namespace WinSolitaire
{
    public partial class Form1 : Form
    {
        private Guid playerGuid = Guid.NewGuid();
        private SolitaireBoard board;




        private VisibleGameState gameState = new VisibleGameState();

        #region Graphics
        private Color backgroundColor = Color.DarkGray;
        private Brush backgroundBrush = Brushes.DarkGray;
        private Brush fontBrush = Brushes.Black;
        private Font font = SystemFonts.DefaultFont;
        #endregion

        #region Points
        private static float cardWidth = 100;

        private static float cardHeight = 150;

        private static float margin = 10;
        private static float deckX = margin;
        private static float deckY = 10;

        private static float pileX = cardWidth + deckX + margin;
        private static float pileY = deckY;

        private static float[] finishZoneX =
        {
            cardWidth*3 + margin*4,
            cardWidth*4 + margin*5,
            cardWidth*5 + margin*6,
            cardWidth*6 + margin*7
        };

        private static float[] playZoneX =
        {
            margin,
            cardWidth + margin * 2,
            cardWidth * 2 + margin * 3,
            cardWidth * 3 + margin * 4,
            cardWidth * 4 + margin * 5,
            cardWidth * 5 + margin * 6,
            cardWidth * 6 + margin * 7,
        };

        private static float playZoneY = deckY + cardHeight + margin;

        #endregion

        #region Rectangles

        private Rectangle deckRect;
        private Rectangle pileRect;

        #endregion

        public Form1()
        {
            InitializeComponent();

            deckRect = new Rectangle((int) deckX, (int) deckY, (int) cardWidth, (int) cardHeight);
            pileRect = new Rectangle((int) pileX, (int) pileY, (int)cardWidth, (int)cardHeight);

            NewGame();
        }

        private void NewGame()
        {

            lock (gameState)
            {
                board = new SolitaireBoard(playerGuid);
                board.GameStateUpdated += (gs) =>
                {
                    lock (gameState)
                    {
                        gameState = gs;
                    }
                    Invalidate();
                };

                board.Publish(new StartGame(playerGuid));
            }
        }

        private void DrawFaceDownCard(Graphics g, float x, float y)
        {
            g.FillRectangle(Brushes.White, x, y, cardWidth, cardHeight);
            g.FillRectangle(Brushes.LightBlue, x + 3, y + 3, cardWidth - 6, cardHeight - 6);
            
        }

        private void DrawEmptyZone(Graphics g, float x, float y)
        {
            g.FillRectangle(Brushes.Aquamarine, x, y, cardWidth, cardHeight);
            g.FillRectangle(backgroundBrush, x + 10, y + 10, cardWidth - 20, cardHeight - 20);
        }

        private void DrawCard(Graphics g, float x, float y, PlayingCard card)
        {
            g.FillRectangle(Brushes.Black, x, y, cardWidth, cardHeight);
            g.FillRectangle(Brushes.White, x + 2, y + 2, cardWidth -2, cardHeight -2);
            string cv = $"{CardValueToString(card.CardValue)} {SuitToString(card.CardSuite)}";
            g.DrawString(cv, font, SuitToBrush(card.CardSuite), x + 5, y + 5 );
        }

        private string CardValueToString(CardValue cv)
        {
            switch (cv)
            {
                case CardValue.One:
                    return "1";
                case CardValue.Two:
                    return "2";
                case CardValue.Three:
                    return "3";
                case CardValue.Four:
                    return "4";
                case CardValue.Five:
                    return "5";
                case CardValue.Six:
                    return "6";
                case CardValue.Seven:
                    return "7";
                case CardValue.Eight:
                    return "8";
                case CardValue.Nine:
                    return "9";
                case CardValue.Ten:
                    return "10";
                case CardValue.Jack:
                    return "J";
                case CardValue.Queen:
                    return "Q";
                case CardValue.King:
                    return "K";
                case CardValue.Ace:
                    return "A";
                default:
                    throw new NotImplementedException();
            }
        }

        private string SuitToString(Suite s)
        {
            switch (s)
            {
                case Suite.Clubs:
                    return "C";
                case Suite.Diamonds:
                    return "D";
                case Suite.Hearts:
                    return "H";
                case Suite.Spades:
                    return "S";
                default:
                    throw new NotImplementedException();
            }
        }

        private Brush SuitToBrush(Suite s)
        {
            switch (s)
            {
                case Suite.Clubs:
                case Suite.Spades:
                    return Brushes.Black;
                case Suite.Diamonds:
                case Suite.Hearts:
                    return Brushes.Red;
                default:
                    throw new NotImplementedException();
            }
        }

        private void DrawDeck(Graphics g)
        {
            if (gameState.CardsInDeck > 0)
            {
                DrawFaceDownCard(g, deckX, deckY);
            }
            else
            {
                DrawEmptyZone(g, deckX, deckY);
            }
        }

        private void DrawPile(Graphics g)
        {
            
            if (gameState.CardsInPile == 0)
            {
                DrawEmptyZone(g, pileX, pileY);
            }
            else
            {
                DrawCard(g, pileX, pileY, gameState.TopCardOfPile);
            }
        }

        private void DrawPlayZones(Graphics g, int index)
        {
            if (!gameState.PlayZoneCards[index].Any())
            {
                DrawEmptyZone(g, playZoneX[index], playZoneY);
            }

            float offsetY = 0;
            float offsetPixels = 15;

            for (int i = 0; i < gameState.PlayZoneCards[index].Length; i++)
            {
                if (gameState.PlayZoneCards[index][i] != null)
                {
                    DrawCard(g, playZoneX[index], playZoneY + offsetY*offsetPixels, gameState.PlayZoneCards[index][i]);
                }
                else
                {
                    DrawFaceDownCard(g, playZoneX[index], playZoneY + offsetY*offsetPixels);
                }
                offsetY++;
            }

        }

        private void DrawFinishZone(Graphics g, int index)
        {
            if (gameState.FaceUpFinishCards[index] == null)
            {
                DrawEmptyZone(g, finishZoneX[index], deckY);
            }
            else
            {
                DrawCard(g, finishZoneX[index], deckY, gameState.FaceUpFinishCards[index]);
            }
        }

        private void DrawGame(Graphics g)
        {
            g.Clear(backgroundColor);
            DrawDeck(g);
            DrawPile(g);
            for (int i = 0; i < 4; i++)
            {
                DrawFinishZone(g, i);
            }
            for (int i = 0; i < 7; i++)
            {
                DrawPlayZones(g, i);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawGame(e.Graphics);
        }

        private Zone CardIsClicked(int x, int y)
        {
            if (deckRect.Contains(x, y)) return Zone.Deck;
            if (pileRect.Contains(x, y)) return Zone.Pile;

            return Zone.None;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            var zone = CardIsClicked(e.X, e.Y);

            switch (zone)
            {
                case Zone.Deck:
                    board.Publish(new StepDeck(playerGuid));
                    break;
            }

        }
    }

    enum Zone
    {
        None,
        Deck,
        Pile,
    }
}
