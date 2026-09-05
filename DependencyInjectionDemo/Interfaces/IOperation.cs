using System;

namespace DependencyInjectionDemo.Interfaces
{
    public interface IOperation
    {
        Guid OperationId { get; }
    }

    public interface ITransientOperation : IOperation { }
    
    public interface IScopedOperation : IOperation { }
    
    public interface ISingletonOperation : IOperation { }
}
