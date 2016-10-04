using Simulation.Atlas;
using Simulation.Atlas.Layers;
using Simulation.GameActors.Tiles.OnGroundInteractable;
using VRageMath;
using Simulation.ToyWorldCore;

namespace Simulation.GameActors.Tiles.ObstacleInteractable
{
    public class KeyDoorClosed : DynamicTile, ISwitchableGameActor
    {
        public KeyDoorClosed(ITilesetTable tilesetTable, Vector2I position) : base(tilesetTable, position)
        {
        }

        public KeyDoorClosed(int tileType, Vector2I position) : base(tileType, position)
        {
        }

        public ISwitchableGameActor Switch(GameActorPosition gameActorPosition, IAtlas atlas, ITilesetTable table)
        {
            KeyDoorOpened openedDoor = new KeyDoorOpened(table, Position);
            bool added = atlas.Add(new GameActorPosition(openedDoor, (Vector2)Position, LayerType.OnGroundInteractable));
            if (!added) return this;
            atlas.Remove(new GameActorPosition(this, (Vector2)Position, LayerType.ObstacleInteractable));
            return openedDoor;
        }
    }
}