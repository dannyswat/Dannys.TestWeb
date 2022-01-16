using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common
{
    public class ServiceResult
    {
        object returnObject;

        public ServiceResult(string action)
        {
            Action = action;
        }
        public bool Success { get { return Status != ServiceResultStatus.Failed; } }
        public ServiceResultStatus Status { get; private set; } = ServiceResultStatus.Success;
        public string Action { get; private set; }

        public string Message
        {
            get
            {
                if (Messages.Count == 1)
                    return Messages.First().Message;
                else if (Messages.Count == 0)
                    return string.Empty;
                else
                    return "There are several errors";
            }
        }

        public List<FieldMessage> Messages { get; } = new List<FieldMessage>();

        public void AddError(string field, string errorMessage)
        {
            Status = ServiceResultStatus.Failed;
            Messages.Add(new FieldMessage { FieldName = field ?? "", Message = errorMessage });
        }

        public void AddWarning(string warningMessage)
        {
            if (Status == ServiceResultStatus.Success)
                Status = ServiceResultStatus.SuccessWithWarning;
            Messages.Add(new FieldMessage { FieldName = "", Message = warningMessage });
        }

        public T GetReturn<T>()
        {
            if (returnObject is T)
                return (T)returnObject;
            else
                return default;
        }

        public ServiceResult SetReturn(object returnObject)
        {
            this.returnObject = returnObject;
            return this;
        }
    }

    public enum ServiceResultStatus
    {
        Success, Failed, SuccessWithWarning
    }
}
