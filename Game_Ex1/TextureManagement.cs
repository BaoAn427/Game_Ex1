using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Game_Ex1
{
    public class TextureManagement : GameEntity
    {
        private List<Sprite2D> _SpriteBackyard = new List<Sprite2D>();
        private List<Sprite2D> _lSpriteLilyPad = new List<Sprite2D>();
        private List<Sprite2D> _lSpriteFire = new List<Sprite2D>();
        public ContentManager _Content;

        private static int _WATER_WIDTH = 80;
        private static int _WATER_HEIGHT = 70;
        private static int _GRASS_WIDTH = 80;
        private static int _LILYPAD_COLS = 9;
        private static int _LILYPAD_ROWS = 2;
        private static int _FIRE_COLS = 9;
        private static int _FIRE_ROWS = 6;


        public void GenerateBackyard()
        {
            GenerateTexture(_SpriteBackyard, "Backyard_Pool", 1, 0, -100, 0, 0, 1, 0.1f);
            GenerateLilyPad();
        }

        public void GenerateFire()
        {
            for (int i = 0; i < _FIRE_COLS; ++i)
            {
                for (int j = 0; j < _FIRE_ROWS; ++j)
                {
                    int delta_height = 0;
                    switch (j)
                    {
                        case 0:
                            delta_height = 115;
                            break;
                        case 1:
                            delta_height = 205;
                            break;
                        case 2:
                            delta_height = 300;
                            break;
                        case 3:
                            delta_height = 370;
                            break;
                        case 4:
                            delta_height = 470;
                            break;
                        case 5:
                            delta_height = 555;
                            break;

                    }
                    GenerateTexture(_lSpriteFire, "Fire", 4, 260 + i * _GRASS_WIDTH, delta_height, 0, 0, 0.8f, 0.7f);
                }
            }
        }

        private void GenerateLilyPad()
        {
            for (int i = 0; i < _LILYPAD_COLS; ++i)
            {
                for (int j = 0; j < _LILYPAD_ROWS; ++ j)
                {
                    GenerateTexture(_lSpriteLilyPad, "LilyPad", 1, 260 + i * _WATER_WIDTH, 320 + j * _WATER_HEIGHT, 0, 0, 0.75f, 0.4f);
                }
            }
        }


        private void GenerateTexture(List<Sprite2D> lSprite, string strResourcePrefix, int nTexture, float left, float top, float width, float height, float scale, float depth)
        {
            List<Texture2D> lTexture = LoadTexture(strResourcePrefix, nTexture);
            Sprite2D sprite = new Sprite2D(strResourcePrefix, lTexture, left, top, width, height, scale, depth);
            lSprite.Add(sprite);
        }
        
        private List<Texture2D> LoadTexture(string strResourcePrefix, int nTexture)
        {
            List<Texture2D> lTexture = new List<Texture2D>();
            string tmp;
            for (int i = 1; i <= nTexture; ++i)
            {
                tmp = strResourcePrefix + i.ToString("00");
                lTexture.Add(_Content.Load<Texture2D>(tmp));
            }

            return lTexture;
        }


        public void DrawTextures(GameTime gameTime, SpriteBatch spriteBatch)
        {
            int n = _SpriteBackyard.Count;
            for (int i = 0; i < n; i++)
                _SpriteBackyard[i].Draw(gameTime, spriteBatch);

            n = _lSpriteLilyPad.Count;
            for (int i = 0; i < n; i++)
                _lSpriteLilyPad[i].Draw(gameTime, spriteBatch);

            n = _lSpriteFire.Count;
            for (int i = 0; i < n; i++)
                _lSpriteFire[i].Draw(gameTime, spriteBatch);
        }

        public void UpdateTextures(GameTime gameTime)
        {
            int n = _SpriteBackyard.Count;
            for (int i = 0; i < n; i++)
                _SpriteBackyard[i].Update(gameTime);

            n = _lSpriteLilyPad.Count;
            for (int i = 0; i < n; i++)
                _lSpriteLilyPad[i].Update(gameTime);

            n = _lSpriteFire.Count;
            for (int i = 0; i < n; i++)
                _lSpriteFire[i].Update(gameTime);
        }


        public int IsClickOnFire(float x, float y)
        {
            int n = _lSpriteFire.Count;
            for (int i = 0; i < n; ++i)
            {
                if (_lSpriteFire[i].IsSelected(x, y))
                    return i;
            }
            return -1;
        }

        public void MinimizeFireAt(int i)
        {
            //_lSpriteFire.RemoveAt(i);
            _lSpriteFire[i].MinimizeFire();
        }

    }
}
