using Fiber.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Fiber.Validations.Responses
{
    public class InvalidResponse<TErrorType> : IInvalidResponse<TErrorType> where TErrorType : struct
    {
        protected readonly List<TErrorType> errors;

        public InvalidResponse()
        {
            this.errors = new List<TErrorType>();
            this.errors.Add(DefaultError);
        }

        public InvalidResponse(List<TErrorType> errors)
        {
            this.errors = errors;
        }

        public TErrorType AddError(string title, string message)
        {
            object error = CreateErrorInstance(title, message);

            this.errors.Add((TErrorType) error);

            return (TErrorType) error;
        }

        public bool Invalid()
        {
            return this.errors.Count > 0;
        }

        public void Clear()
        {
            this.errors.Clear();
        }

        public List<TErrorType> Data()
        {
            return this.errors;
        }

        public bool Valid()
        {
            return !this.Invalid();
        }

        private TErrorType DefaultError => (TErrorType) CreateErrorInstance("Undefined Error", "Error not defined. Please contact API admin.");

        private TErrorType CreateErrorInstance(string title, string message)
        {
            return (TErrorType)Activator.CreateInstance(typeof(TErrorType), new object[] { title, message });
        }

        IResponse<List<TErrorType>> IResponse<List<TErrorType>>.Response()
        {
            return this as IResponse<List<TErrorType>>;
        }

        public string DataAsJson()
        {
            return JsonConvert.SerializeObject(this.errors);
        }
    }
}
