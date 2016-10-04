using Simulation.Atlas;
using Simulation.Atlas.Layers;
using Simulation.GameActions;
using Simulation.GameActors.Tiles;
using Simulation.Physics;
using VRageMath;
using Simulation.ToyWorldCore;

namespace Simulation.GameActors.GameObjects
{
    class Ball : Character, IPickableGameActor
    {
        public Ball(
            string tilesetName,
            int tileId, string name,
            Vector2 position,
            Vector2 size,
            float direction)
            : base(
            tilesetName,
            tileId,
            name,
            position,
            size,
            direction,
            typeof(CircleShape))
        {
        }

        public void PickUp(IAtlas atlas, GameAction gameAction, Vector2 position, ITilesetTable tilesetTable = null)
        {
            if (gameAction is PickUp || gameAction is LayDown)
            {
                gameAction.Resolve(new GameActorPosition(this, position, LayerType.Object), atlas, tilesetTable);
            }
        }
    }
}
