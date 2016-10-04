using Simulation.Atlas;
using Simulation.GameActors;
using Simulation.GameActors.Tiles;
using Simulation.GameActors.Tiles.ObstacleInteractable;
using Simulation.ToyWorldCore;

namespace Simulation.GameActions
{
    class Interact : GameAction
    {
        public Interact(GameActor sender) : base(sender)
        {
        }

        public override void Resolve(GameActorPosition target, IAtlas atlas, ITilesetTable table)
        {
            if (target.Actor is Apple || target.Actor is Pear)
            {
                atlas.Remove(target);
            }

            var switcher = target.Actor as ISwitcherGameActor;

            if (switcher != null)
            {
                switcher.Switch(target, atlas, table);
            }
        }
    }
}
