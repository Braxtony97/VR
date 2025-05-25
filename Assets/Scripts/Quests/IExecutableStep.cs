using Interfaces;

namespace Quests
{
    public interface IExecutableStep
    {
        void Initialize(IServiceLocator serviceLocator);
        void StartStep();
        void EndStep();
        void Deinitialize();
    }
}