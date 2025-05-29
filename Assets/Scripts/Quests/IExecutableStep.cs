using Interfaces;

namespace Quests
{
    public interface IExecutableStep
    {
        void Initialize(IServiceLocator serviceLocator, Group group);
        void StartStep();
        void EndStep();
        void Deinitialize();
    }
}