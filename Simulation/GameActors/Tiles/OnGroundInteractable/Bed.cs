using System.Collections.Generic;
using System.Linq;
using Simulation.Atlas;
using Simulation.GameActors.GameObjects;
using Simulation.ToyWorldCore;
using VRageMath;

namespace Simulation.GameActors.Tiles.OnGroundInteractable
{
    public class Bed : DynamicTile, IAutoupdateableGameActor, IDetectorTile
    {
        public bool RequiresCenterOfObject { get { return true; } }
        public int NextUpdateAfter { get; private set; }
        public bool SomeoneOnTile { get; set; }

        public Bed(ITilesetTable tilesetTable, Vector2I position) : base(tilesetTable, position) { Init(); }

        public Bed(int tileType, Vector2I position) : base(tileType, position) { Init(); }

        private void Init()
        {
            NextUpdateAfter = 0;
        }

        public void ObjectDetected(IGameObject gameObject, IAtlas atlas, ITilesetTable tilesetTable)
        {
            if (SomeoneOnTile) return;
            NextUpdateAfter = 60;
            atlas.RegisterToAutoupdate(this);
        }

        public void Update(IAtlas atlas, ITilesetTable table)
        {
            List<IGameObject> gameActorPositions = atlas.StayingOnTile(Position);

            SomeoneOnTile = gameActorPositions.Any();

            foreach (IGameObject gameActor in gameActorPositions)
            {
                IAvatar avatar = gameActor as IAvatar;
                if (avatar != null)
                    avatar.Rested += TWConfig.Instance.BedRechargeRate;
            }
        }
    }
}
