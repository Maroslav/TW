using Simulation.Atlas;
using Simulation.Atlas.Layers;
using Simulation.GameActions;
using Simulation.GameActors.Tiles.ObstacleInteractable;
using VRageMath;
using Simulation.ToyWorldCore;

namespace Simulation.GameActors.Tiles.OnGroundInteractable
{
    public class SimpleDoorOpened : StaticTile, IInteractableGameActor
    {
        public SimpleDoorOpened(ITilesetTable tilesetTable)
            : base(tilesetTable)
        {
        }

        public SimpleDoorOpened(int tileType)
            : base(tileType)
        {
        }

        public void ApplyGameAction(IAtlas atlas, GameAction gameAction, Vector2 position, ITilesetTable tilesetTable)
        {
            var doorClosed = new SimpleDoorClosed(tilesetTable);
            bool added = atlas.Add(new GameActorPosition(doorClosed, position, LayerType.ObstacleInteractable), true);
            if (added)
            {
                atlas.Remove(new GameActorPosition(this, position, LayerType.OnGroundInteractable));
            }
        }
    }
}