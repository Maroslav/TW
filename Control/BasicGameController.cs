using GoodAI.ToyWorld.Control;
using Render.Renderer;
using World.ToyWorldCore;

namespace Game
{
    public class BasicGameController : GameControllerBase<ToyWorld>
    {
        public BasicGameController(BasicGLRenderer<ToyWorld> renderer, GameSetup gameSetup)
            : base(renderer, gameSetup)
        { }
    }
}
