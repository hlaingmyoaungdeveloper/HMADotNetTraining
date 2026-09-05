using System;
using DependencyInjectionDemo.Interfaces;

namespace DependencyInjectionDemo.Services
{
    public class DefaultOperation : ITransientOperation, IScopedOperation, ISingletonOperation
    {
        public Guid OperationId { get; }

        public DefaultOperation()
        {
            OperationId = Guid.NewGuid();
        }
    }
}
