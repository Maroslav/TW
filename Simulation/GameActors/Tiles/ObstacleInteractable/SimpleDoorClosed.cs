using Simulation.Atlas;
using Simulation.Atlas.Layers;
using Simulation.GameActions;
using Simulation.GameActors.Tiles.OnGroundInteractable;
using VRageMath;
using Simulation.ToyWorldCore;

namespace Simulation.GameActors.Tiles.ObstacleInteractable
{
    public class SimpleDoorClosed : StaticTile, IInteractableGameActor
    {
        public SimpleDoorClosed(ITilesetTable tilesetTable)
            : base(tilesetTable)
        {
        }

        public SimpleDoorClosed(int tileType)
            : base(tileType)
        {
        }

        public void ApplyGameAction(IAtlas atlas, GameAction gameAction, Vector2 position, ITilesetTable tilesetTable)
        {
            var doorOpened = new SimpleDoorOpened(tilesetTable);
            bool added = atlas.Add(new GameActorPosition(doorOpened, position, LayerType.OnGroundInteractable));
            if (added)
            {
                atlas.Remove(new GameActorPosition(this, position, LayerType.ObstacleInteractable));
            }
        }
    }
}