using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharm.Repository.ErrorHandler
{
    public class ErrorHandler : ResponseMessage
    {
        public ErrorHandler(string ActionName = null, int NumbersOfRoleAffected = 0, int RowID = 0)
            : base(ActionName, NumbersOfRoleAffected, RowID)
        {

        }
    }
    public class ResponseMessage
    {
        public AppResponseCode Code { get; set; }
        public string Message { get; set; }
        public string ActionName { get; set; }
        public int NumbersOfRoleAffected { get; set; }
        public int RowID { get; set; }
        public enum AppResponseCode
        {
            Successful = 01,
            Failure = 02,
            TokenValidationError = 03,
            AuthenticationFailure = 04,
            ApplicationError = 05,
            AccessDenied = 06,
            AccountLockedOut = 07,
            ParametersIncomplete = 08,
            SuccessfulWithNoResult = 09,
            PaginationValueIsNotCorrect = 10
        }
        [JsonIgnore]
        public Dictionary<AppResponseCode, string> AppResponseDescription = new Dictionary<AppResponseCode, string>(){
            {AppResponseCode.Successful,"Operation successful"},
            {AppResponseCode.Failure,"Operation failed"},
            {AppResponseCode.TokenValidationError,"Token validation error"},
            {AppResponseCode.AuthenticationFailure,"Authentication failure"},
            {AppResponseCode.ApplicationError,"Application error"},
            {AppResponseCode.AccessDenied,"Access denied for user"},
            {AppResponseCode.AccountLockedOut,"Account Locked Out"},
            {AppResponseCode.ParametersIncomplete,"Parameter Incomplete Please check your params"},
            {AppResponseCode.SuccessfulWithNoResult,"Operation was successful but no result was found"},
            {AppResponseCode.PaginationValueIsNotCorrect,"Pagination value is not correct"}

        };
        public ResponseMessage ResponseMessageHandler(AppResponseCode code)
        {
            this.Code = code;
            this.Message = this.AppResponseDescription[code].ToString();
            return this;
        }
        public ResponseMessage(string ActionName = null, int NumbersOfRoleAffected = 0, int RowID = 0)
        {
            if (ActionName != null)
                this.ActionName = ActionName;
            if (NumbersOfRoleAffected != 0)
                this.NumbersOfRoleAffected = NumbersOfRoleAffected;
            if (RowID != 0)
                this.RowID = RowID;

        }

    }
}
