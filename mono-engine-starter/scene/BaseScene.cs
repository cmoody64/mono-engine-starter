using engine.entity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engine.scene
{
    abstract class BaseScene
    {
        protected abstract List<BaseEntity> Entities { get; set; }
        public bool Initialized { get; private set; }

        // lifecycle methods
        public virtual void OnInitialize()
        {
            Initialized = true;
        }
        public virtual void OnActivate()
        {
            Entities.ForEach(entity => entity.OnActivate());
        }
        public virtual void OnDeactivate()
        {
            Entities.ForEach(entity => entity.OnDeactivate());
        }

        // engine methods
        public void Draw(SpriteBatch spriteBatch)
        {
            Entities.ForEach(entity => entity.Draw(spriteBatch));
        }
        public void Update(MonoEngine engine, GameTime gameTime)
        {
            Entities.ForEach(entity => entity.Update(engine, gameTime));
        }

    }
}
