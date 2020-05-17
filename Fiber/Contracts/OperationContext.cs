using Fiber.Interfaces;
using Fiber.Interfaces.Operations;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Fiber.Contracts
{
    public class OperationContext<T> : IOperationContext<T>
    {
        private readonly IEnumerable<T> operationContext; // A dictionary

        public OperationContext(IEnumerable<T> operationContext)
        {
            this.operationContext = operationContext;
        }

        public IContext<T> Context()
        {
            return this.operationContext as IContext<T>;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IOperationContext<T> OpContext()
        {
            return this;
        }

        public bool Valid()
        {
            throw new NotImplementedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
