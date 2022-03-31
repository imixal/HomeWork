using Common.Scripts.Service;

namespace Runner3D.Scripts.Core
{
    public interface IGameContext
    {
        IAudioService AudioService { get;}
        ISaveService SaveService { get; }
        ISceneService SceneService { get; }
        ICameraService CameraService { get; }

        void ShowView(string viewName);
        void HideView();
    }
}