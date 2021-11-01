namespace KataMachineAPI.Core.Services
{
    public interface IMachineRepository
    {
        bool IsOperative(int id);

        void UpdateMachineOperative(int id, bool isOperative);
    }
}