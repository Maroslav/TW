using System;
using System.Collections.Generic;
using System.IO;
using TmxMapSerializer.Elements;
using World.Atlas;
using World.GameActors.GameObjects;

namespace World.WorldInterfaces
{
    public interface IWorld
    {
        Dictionary<string, Func<IAtlas, float>> SignalDispatchers { get; }
        IAtlas Atlas { get; }

        void Init(Map map, StreamReader tileset);
        /// <summary>
        /// Updates every object implementing IAutoupdatable interface and all their's GameActions
        /// Order of update is: 
        ///     1. Tiles actions
        ///     2. Avatar(s) actions
        ///     4. Characters actions
        ///     5. GameObjects actions
        ///     6. GamoObjects move (Physics)
        /// </summary>
        void Update();

        IEnumerable<int> GetAvatarIds();
        IAvatar GetAvatar(int id);
    }
}
