using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game_Ex1
{
    public abstract class VisibleGameEntity : GameEntity
    {
        public virtual void Draw(GameTime gameTime, object helper) { }
    }
}
