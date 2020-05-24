using Fiber.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Fiber.Validations.Responses
{
    public class InvalidResponse<IError> : IInvalidResponse<IError>
    {
        protected readonly List<IError> errors;

        public InvalidResponse()
        {
            this.errors = new List<IError>();
            this.errors.Add(DefaultError);
        }

        public InvalidResponse(List<IError> errors)
        {
            this.errors = errors;
        }

        public IError AddError(string title, string message)
        {
            object error = CreateErrorInstance(title, message);

            this.errors.Add((IError) error);

            return (IError) error;
        }
        
        public IError AddError(IError error)
        {
            this.errors.Add(error);

            return error;
        }

        public bool Invalid()
        {
            return this.errors.Count > 0;
        }

        public void Clear()
        {
            this.errors.Clear();
        }

        public List<IError> Data()
        {
            return this.errors;
        }

        public bool Valid()
        {
            return !this.Invalid();
        }

        private IError DefaultError => (IError) CreateErrorInstance("Undefined Error", "Error not defined. Please contact API admin.");

        private IError CreateErrorInstance(string title, string message)
        {
            return (IError)Activator.CreateInstance(typeof(IError), new object[] { title, message });
        }

        IResponse<List<IError>> IResponse<List<IError>>.Response()
        {
            return this as IResponse<List<IError>>;
        }

        public string DataAsJsonString()
        {
            return JsonConvert.SerializeObject(this.errors);
        }

        public List<IError> Errors()
        {
            return Data();
        }
    }
}
