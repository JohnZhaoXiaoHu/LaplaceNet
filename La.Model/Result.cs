using System;
using System.Collections.Generic;
using System.Text;
using La.Infra.Enums;

namespace La.Model
{
    public class Result
    {
        //public static IStringLocalizer<LocalLanguage> _local;
        public ResultCodeEnum code { get; set; }

        public bool status { get; set; }
        public string message { get; set; }
        public object data { get; set; }
        public static Result Expire(ResultCodeEnum code, string msg = "")
        {
            return new Result() { code = code, status = false, message = Get(msg, "token_expiration") };
        }
        public static Result Error(string msg = "")
        {
            return new Result() { code = ResultCodeEnum.NotSuccess, status = false, message = Get(msg, "fail") };
        }
        public static Result Success(string msg = "")
        {
            return new Result() { code = ResultCodeEnum.Success, status = true, message = Get(msg, "succeed") };
        }
        public static Result SuccessError(string msg = "")
        {
            return new Result() { code = ResultCodeEnum.Success, status = false, message = Get(msg, "fail") };
        }


        public static Result UnAuthorize(string msg = "")
        {
            return new Result() { code = ResultCodeEnum.NoPermission, status = false, message = Get(msg, "unAuthorize") };
        }
        public Result SetStatus(bool _status)
        {
            if (_status)
            {
                this.code = ResultCodeEnum.Success;
                this.message = "操作成功";
            }
            else
            {
                this.code = code = ResultCodeEnum.NotSuccess;
                this.message = "操作失败";
            }
            this.status = _status;
            return this;
        }
        public Result SetData(object obj)
        {
            this.data = obj;
            return this;
        }
        public Result SetCode(ResultCodeEnum Code)
        {
            this.code = Code;
            return this;
        }
        public Result StatusFalse()
        {
            this.status = false;
            return this;
        }
        public Result StatusTrue()
        {
            this.status = true;
            return this;
        }

        public static string Get(string msg, string msg2)
        {
            if (msg == "")
            {
                msg = msg2;
            }
            return msg;
        }
    }
    public class Result<T>
    {
        public ResultCodeEnum code { get; set; }
        public string message { get; set; }
        public T data { get; set; }
        public static Result<T> Error(string msg = "fail")
        {
            return new Result<T>() { code = ResultCodeEnum.NotSuccess, message = msg };
        }
        public static Result<T> Success(string msg = "succeed")
        {
            return new Result<T>() { code = ResultCodeEnum.Success, message = msg };
        }
        public static Result<T> UnAuthorize(string msg = "unAuthorize")
        {
            return new Result<T>() { code = ResultCodeEnum.NoPermission, message = msg };
        }

        public Result<T> SetData(T TValue)
        {
            this.data = TValue;
            return this;
        }

        public Result<T> SetCode(ResultCodeEnum Code)
        {
            this.code = Code;
            return this;
        }
    }
}