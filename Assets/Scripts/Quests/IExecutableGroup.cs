using Interfaces;

namespace Quests
{
    public interface IExecutableGroup
    {
        void Initialize(IServiceLocator serviceLocator);
        void StartGroup();
        void EndGroup();
        void Deinitialize();
    }
}