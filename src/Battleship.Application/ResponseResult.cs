using System.Collections.Generic;
using System.Linq;

namespace Battleship.Application
{
    public abstract class ResponseResultBase
    {
        public bool ValidationSucceeded { get; }

        public Dictionary<string, string[]> Errors { get; }

        internal ResponseResultBase(bool succeeded, IDictionary<string, string[]> errors)
        {
            this.ValidationSucceeded = succeeded;
            this.Errors = errors?.ToDictionary(t => t.Key, t => t.Value);
        }
    }

    public class ResponseResult : ResponseResultBase
    {
        internal ResponseResult(bool succeeded, IDictionary<string, string[]> errors) : base(succeeded, errors)
        {
        }

        public static ResponseResult Success()
        {
            return new ResponseResult(true, null);
        }

        public static ResponseResult Failure(IDictionary<string, string[]> errors)
        {
            return new ResponseResult(false, errors);
        }
    }

    public class ResponseResult<T> : ResponseResultBase
    {
        public T Payload { get; }

        internal ResponseResult(bool succeeded, IDictionary<string, string[]> errors, T payload) : base(succeeded, errors)
        {
            Payload = payload;
        }

        public static ResponseResult<T> Success(T payload)
        {
            return new ResponseResult<T>(true, null, payload);
        }

        public static ResponseResult<T> Failure(IDictionary<string, string[]> errors, T payload)
        {
            return new ResponseResult<T>(false, errors, payload);
        }
    }
}
