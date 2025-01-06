namespace RobotService.Repositories.Contracts
{
    using System.Collections.Generic;

    public interface IRepository<T>
    {
        IReadOnlyCollection<T> Models();

        void AddNew(T model);

        bool RemoveByName(string typeName);

        T FindByStandard(int interfaceStandard);
    }
}
