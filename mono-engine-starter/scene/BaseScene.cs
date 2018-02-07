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
        public virtual void OnInitialize(MonoEngine engine)
        {
            Initialized = true;
        }

        public virtual void OnActivate(MonoEngine engine)
        {
            Entities.ForEach(entity => {
                if (!entity.Initialized)
                {
                    entity.OnInitialize(engine);
                }          
                entity.OnActivate(engine);
            });
        }

        public virtual void OnDeactivate(MonoEngine engine)
        {
            Entities.ForEach(entity => entity.OnDeactivate(engine));
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
