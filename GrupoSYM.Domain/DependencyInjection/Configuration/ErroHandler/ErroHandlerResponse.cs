﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoSYM.Domain.DependencyInjection.Configuration.ErroHandler
{
    public class ErroHandlerResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public object InnerException { get; set; }

        public ErroHandlerResponse() { }

        public ErroHandlerResponse(int code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
