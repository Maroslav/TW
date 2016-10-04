using System.Collections.Generic;
using System.Linq;
using Simulation.Atlas;
using Simulation.GameActors.GameObjects;
using VRageMath;
using Simulation.ToyWorldCore;

namespace Simulation.GameActors.Tiles.OnGroundInteractable
{
    public class Recharger : DynamicTile, IAutoupdateableGameActor, IDetectorTile
    {
        private float ENERGY_RECHARGED = 0.1f;
        public int NextUpdateAfter { get; private set; }
        public bool SomeoneOnTile { get; set; }
        public bool RequiresCenterOfObject { get; private set; }

        public Recharger(ITilesetTable tilesetTable, Vector2I position) : base(tilesetTable, position)
        {
            Init();
        }

        public Recharger(int tileType, Vector2I position) : base(tileType, position)
        {
            Init();
        }

        private void Init()
        {
            NextUpdateAfter = 0;
            RequiresCenterOfObject = false;
        }

        public void ObjectDetected(IGameObject gameObject, IAtlas atlas, ITilesetTable tilesetTable)
        {
            if(SomeoneOnTile) return;
            NextUpdateAfter = 60;
            atlas.RegisterToAutoupdate(this);
        }

        public void Update(IAtlas atlas, ITilesetTable table)
        {
            List<IGameObject> gameActorPositions = atlas.StayingOnTile(Position);

            SomeoneOnTile = gameActorPositions.Any();

            foreach (IGameObject gameActor in gameActorPositions)
            {
                var avatar = gameActor as IAvatar;
                if (avatar != null)
                {
                    avatar.Energy += ENERGY_RECHARGED;
                }
            }
        }
    }
}