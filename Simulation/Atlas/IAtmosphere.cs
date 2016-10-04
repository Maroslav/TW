using Simulation.GameActors.Tiles;
using VRageMath;

namespace Simulation.Atlas
{
    public interface IAtmosphere
    {
        /// <summary>
        /// Temperature at given position.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        float Temperature(Vector2 position);

        /// <summary>
        /// Call before Temperature() call or every step.
        /// </summary>
        void Update();

        void RegisterHeatSource(IHeatSource heatSource);

        void UnregisterHeatSource(IHeatSource heatSource);
    }
}