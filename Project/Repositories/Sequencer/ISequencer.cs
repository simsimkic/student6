namespace Project.Repositories.Sequencer
{
    public interface ISequencer<T>
    {
        void Initialize(T initId);

        T GenerateId();
    }
}
