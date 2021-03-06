﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game_Ex1
{
    public class Sprite2D : VisibleGameEntity
    {
        private string _Name;
        private List<Texture2D>_lTexture;    // List of Texture
        private int _nTexture;               // Length of List of Texture
        private int _iTexture;               // Pointer for element in List of Texture
        private float _Left;
        private float _Top;
        private float _Width;
        private float _Height;
        private float _Depth;
        private float _Scale;
        private float _DELAY = 80;
    
        private const int _MEDIUM_SIZE = 1;
        private const int _SMALL_SIZE = 2;
        private const int _NO_SIZE = 3;
        private int _Size;
        

        public Sprite2D() { }

        public Sprite2D(string name, List<Texture2D> lTexture, float left, float top, float width, float height, float scale, float depth)
        {
            _Name = name;

            _lTexture = lTexture;
            _nTexture = _lTexture.Count;
            _iTexture = 0;

            _Left = left;
            _Top = top;


            if (width == 0)
                _Width = _lTexture[0].Width;
            else
                _Width = width;

            if (height == 0)
                _Height = _lTexture[0].Height;
            else
                _Height = height;

            _Scale = scale;

            if (depth > 1)
                _Depth = 0;
            else
                _Depth = depth;

            _Size = _MEDIUM_SIZE;
        }


        public bool IsNull()
        {
            return (_lTexture == null);
        }


        public void Remove()
        {
            _lTexture.Clear();
            _lTexture = null;
        }


        public override void Update(GameTime gameTime)
        {
            _iTexture = ((int)(gameTime.TotalGameTime.TotalMilliseconds / _DELAY)) % _nTexture;
        }


        public override void Draw(GameTime gameTime, object helper)
        {
            SpriteBatch spriteBatch = (SpriteBatch)helper;
            switch(_Size)
            {
                case _MEDIUM_SIZE:
                    spriteBatch.Draw(_lTexture[_iTexture], new Vector2(_Left, _Top), null, Color.White, 0f, Vector2.Zero, _Scale, SpriteEffects.None, _Depth);
                    break;
                case _SMALL_SIZE:
                    float left = _Left + ((_Width * _Scale) * 0.5f) / 2;
                    float top = _Top + ((_Height * _Scale) * 0.5f);
                    spriteBatch.Draw(_lTexture[_iTexture], new Vector2(left, top), null, Color.White, 0f, Vector2.Zero, 0.5f * _Scale, SpriteEffects.None, _Depth);
                    break;
                case _NO_SIZE:
                    break;
            }
        }


        public bool IsSelected(float x, float y)
        {
            if (x >= _Left && (x <= _Left + _Scale * _Width) &&
                y >= _Top && (y <= _Top + _Scale * _Height))
                return true;
            else
                return false;
        }

        public void MinimizeFire()
        {
            if (_Size == _MEDIUM_SIZE)
                _Size = _SMALL_SIZE;
            else
            {
                if (_Size == _SMALL_SIZE)
                    _Size = _NO_SIZE;
                else
                    _Size = _MEDIUM_SIZE;
            }
        }
    }
}
