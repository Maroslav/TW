using GoodAI.ToyWorld.Control;
using Render.RenderObjects.Effects;
using Render.RenderObjects.Geometries;
using Render.RenderRequests;
using RenderingBase.Renderer;
using RenderingBase.RenderObjects.Geometries;
using RenderingBase.RenderRequests;

namespace Render.Renderer
{
    public class BasicGLRenderer<TWorld>
        : GLRenderer<TWorld>
        where TWorld : class
    {
        static BasicGLRenderer()
        {
            //////////////////////
            // NOTE: All renderRequests must inherit from RenderRequest
            //////////////////////

            //// RenderRequest registration
            RenderRequestFactory.CaseInternal<IFullMapRR, FullMapRR>();
            RenderRequestFactory.CaseInternal<IFreeMapRR, FreeMapRR>();

            RenderRequestFactory.CaseParamInternal<IFovAvatarRR, FovAvatarRR>();
            RenderRequestFactory.CaseParamInternal<IFofAvatarRR, FofAvatarRR>();
            RenderRequestFactory.CaseParamInternal<IToolAvatarRR, ToolAvatarRR>();
        }

        public BasicGLRenderer()
        {
            // TODO: gather and distribute types to TypeSwitches based on available constructor through reflection (add attributes?)

            //// Geometry registration
            // Plain geometries
            GeometryManager.Case<Quad>();
            GeometryManager.Case<QuadTex>();
            GeometryManager.Case<Cube>();
            GeometryManager.Case<DuplicatedCube>();

            // Parameterized geometries
            GeometryManager.CaseParam<DuplicatedGrid>();
            GeometryManager.CaseParam<CubeGrid>();
            GeometryManager.CaseParam<DuplicatedCubeGrid>();


            //// Effect registration
            EffectManager.Case<NoEffectTex>();
            EffectManager.Case<NoEffectOffset>();
            EffectManager.Case<SmokeEffect>();
            EffectManager.Case<NoiseEffect>();
        }
    }
}
