using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.Infrastructure
{
    public class ResultModel<T>: ResultModel
    {
        public T Data { get; set; }
    }
    public class ResultModel
    {
        public ResultModelType Result { get; set; }
        public string Message { get; set; }
    }
}
