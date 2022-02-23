using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlappyBirdRemastered.Classes
{
    public class Pipe
    {
        public const int FRONT_STATE = 0;
        public const int BACK_STATE = 1;
        public static GraphicsDeviceManager graphics;
        public static Texture2D topPipeTexture;
        public static Texture2D bottomPipeTexture;
        private Rectangle topPipeRectangle;
        private Rectangle bottomPipeRectangle;
        private Random random;
        private readonly int pipeHeight;
        private readonly int pipeWidth;
        private readonly int verticalDistanceBetween;
        public static int horizontalDistanceBetween;
        private readonly int position;
        private readonly int position2;
        private int state;
        private bool destroyed;

        public Pipe(int state)
        {
            random = new Random();
            pipeHeight = 620;
            pipeWidth = 75;
            destroyed = false;
            verticalDistanceBetween = 200;
            if(state == GameController.PLAYING_STATE)
            {
                position = DefinePipePosition();
                horizontalDistanceBetween = 50;
            }
            position2 = position + pipeHeight + verticalDistanceBetween;
            topPipeRectangle = new Rectangle(graphics.PreferredBackBufferWidth, position, pipeWidth, pipeHeight);
            bottomPipeRectangle = new Rectangle(graphics.PreferredBackBufferWidth, position2, pipeWidth, pipeHeight);
        }

        public void Move(int gameState)
        {
            if(gameState == GameController.PLAYING_STATE)
            {
                bottomPipeRectangle.X -= 5;
                topPipeRectangle.X -= 5;
            }
        }

        public void Destroy()
        {
            if (bottomPipeRectangle.Top < graphics.PreferredBackBufferHeight)
            {
                bottomPipeRectangle.X += 10;
                bottomPipeRectangle.Y += 10;
            }

            if (topPipeRectangle.Bottom > 0)
            {
                topPipeRectangle.X += 10;
                topPipeRectangle.Y -= 10;
            }

            destroyed |= (bottomPipeRectangle.Top >= graphics.PreferredBackBufferHeight || topPipeRectangle.Bottom <= 0);
        }

        public int DefinePipePosition()
        {
            return random.Next(-570, -350);
        }

        public Rectangle TopPipeRectangle
        {
            get
            {
                return topPipeRectangle;
            }
            set
            {
                this.topPipeRectangle = value;
            }
        }

        public Rectangle BottomPipeRectangle
        {
            get
            {
                return bottomPipeRectangle;
            }
            set
            {
                this.bottomPipeRectangle = value;
            }
        }

        public int State
        {
            get
            {
                return state;
            }
            set
            {
                this.state = value;
            }
        }

        public bool Destroyed
        {
            get
            {
                return destroyed;
            }
            set
            {
                this.destroyed = value;
            }
        }
    }
}
