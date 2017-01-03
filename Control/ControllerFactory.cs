using Game;
using Render.Renderer;
using World.ToyWorldCore;

namespace GoodAI.ToyWorld.Control
{
    public static class ControllerFactory
    {
        public static IGameController GetController(GameSetup gameSetup)
        {
            return new BasicGameController(new BasicGLRenderer<World.ToyWorldCore.ToyWorld>(), gameSetup);
        }

        public static IGameController GetThreadSafeController(GameSetup gameSetup)
        {
            return new ThreadSafeGameController(new BasicGLRenderer<World.ToyWorldCore.ToyWorld>(), gameSetup);
        }

        public static int GetSignalCount()
        {
            return TWConfig.Instance.SignalCount;
        }
    }
}
