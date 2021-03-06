﻿using System.Linq;
using System.Collections.Generic;
using GoodAI.ToyWorld.Control;
using GoodAI.ToyWorldAPI;
using Render.Renderer;
using RenderingBase.RenderRequests;
using Strut_Render_Base;
using TmxMapSerializer.Elements;
using TmxMapSerializer.Serializer;
using World.GameActors.GameObjects;
using World.WorldInterfaces;

namespace Game
{
    public abstract class GameControllerBase<TWorld>
        : IGameController
        where TWorld : class, IWorld, new()
    {
        private bool m_initialized;
        private readonly GameSetup m_gameSetup;

        private BasicGLRenderer<TWorld> m_renderer;
        public BasicGLRenderer<TWorld> Renderer { get { return m_renderer; } private set { m_renderer = value; } }

        private Renderer m_testRenderer;

        public TWorld World { get; private set; }

        private Dictionary<int, IAvatar> m_avatars;
        private Dictionary<int, AvatarController> m_avatarControllers;

        public event MessageEventHandler NewMessage = delegate { };

        protected GameControllerBase(BasicGLRenderer<TWorld> renderer, GameSetup setup)
        {
            Renderer = renderer;
            m_gameSetup = setup;
        }

        public virtual void Dispose()
        {
            if (m_renderer != null)
                m_renderer.Dispose();

            m_testRenderer?.Dispose();
        }


        #region IGameController overrides

        public virtual void Init()
        {
            m_initialized = true;

            // Init World
            //var serializer = new TmxSerializer();
            //Map map = serializer.Deserialize(m_gameSetup.SaveFile);
            //m_gameSetup.SaveFile.Close();

            //World = new TWorld();
            //World.Init(map, m_gameSetup.TilesetFile);

            //m_avatars = new Dictionary<int, IAvatar>();
            //foreach (int avatarId in World.GetAvatarIds())
            //{
            //    m_avatars.Add(avatarId, World.GetAvatar(avatarId));
            //}

            //m_avatarControllers = new Dictionary<int, AvatarController>();
            //foreach (KeyValuePair<int, IAvatar> avatar in m_avatars)
            //{
            //    var avatarController = new AvatarController(avatar.Value);
            //    m_avatarControllers.Add(avatar.Key, avatarController);
            //}

            // Init rendering
            Renderer.Init();
            Renderer.CreateWindow("TestGameWindow", 1024, 1024);
            Renderer.CreateContext();
            Renderer.Window.Visible = true;

            m_testRenderer = new Strut_Render_Vk.Renderer();
            m_testRenderer.WinHandle = Renderer.Window.WindowInfo.Handle;
            m_testRenderer.Init();
        }

        public virtual void MakeStep()
        {
            if (!m_initialized)
            {
                Init();
            }

            // Controls should be already set

            //World.Update();

            m_testRenderer.Draw();
            //Renderer.ProcessRequests();
        }

        public virtual void FinishStep()
        {
            ResetAvatarControllers();
        }


        public virtual T RegisterRenderRequest<T>()
            where T : class, IRenderRequest
        {
            Renderer.MakeContextCurrent();
            T rr = RenderRequestFactory.CreateRenderRequest<T>();
            InitRR(rr);
            Renderer.EnqueueRequest(rr);
            Renderer.MakeContextNotCurrent();

            return rr;
        }

        public virtual T RegisterRenderRequest<T>(int avatarId)
            where T : class, IAvatarRenderRequest
        {
            // TODO: check agentID or make the param an AgentController?

            Renderer.MakeContextCurrent();
            T rr = RenderRequestFactory.CreateRenderRequest<T>(avatarId);
            InitRR(rr);
            Renderer.EnqueueRequest(rr);
            Renderer.MakeContextNotCurrent();

            return rr;
        }

        void InitRR<T>(T rr)
            where T : class
        {
            IRenderRequestBaseInternal<TWorld> rrBase = rr as IRenderRequestBaseInternal<TWorld>; // Assume that all renderRequests created by factory inherit from IRenderRequestBaseInternal

            if (rrBase == null)
                throw new RenderRequestNotImplementedException(
                    "The supplied interface cannot be used. There is either no implementation or it is implemented incorrectly.");

            rrBase.Renderer = Renderer;
            rrBase.World = World;
        }


        public virtual IAvatarController GetAvatarController(int avatarId)
        {
            return m_avatarControllers[avatarId];
        }

        private void ResetAvatarControllers()
        {
            foreach (AvatarController avatarController in m_avatarControllers.Values)
            {
                avatarController.ResetControls();
            }
        }

        public int[] GetAvatarIds()
        {
            return m_avatarControllers.Keys.ToArray();
        }

        public Dictionary<string, float> GetSignals()
        {
            return World.SignalDispatchers.ToDictionary(pair => pair.Key, pair => pair.Value(World.Atlas));
        }

        #endregion
    }
}
