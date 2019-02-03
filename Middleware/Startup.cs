using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Owin;

namespace MiddlewareTest
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class Startup
    {
        public void Configuration(IAppBuilder app)

        {
            app.Use(new Func<AppFunc, AppFunc>(next => (async context =>

            {

                using (var writer = new StreamWriter(context["owin.ResponseBody"] as Stream))

                {

                    await writer.WriteAsync("<h1>MW1: Hello from inline Method middleware!</h1>");

                }

                await next.Invoke(context);

            })));
        }
    }
}