using Simulation.Atlas;
using Simulation.GameActors;
using Simulation.GameActors.Tiles;
using Simulation.ToyWorldCore;

namespace Simulation.GameActions
{
    public class UsePickaxe : GameAction
    {
        public float Damage { get; set; }

        public UsePickaxe(GameActor sender) : base(sender) { }

        public override void Resolve(GameActorPosition target, IAtlas atlas, ITilesetTable table)
        {
            throw new System.NotImplementedException();
        }
    }
}