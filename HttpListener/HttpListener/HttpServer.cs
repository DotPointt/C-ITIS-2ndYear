using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace HttpServer
{
    public class HttpServer
    {

        public HttpListener server = new HttpListener();

        public async Task RunHttp()
        {
            server.Prefixes.Add("http://127.0.0.1:8888/");
            server.Start();

            while (true)
            {
                 // начинаем прослушивать входящие подключения

                // получаем контекст
                var context = await server.GetContextAsync();

                var response = context.Response;

                if (context.Request.Url.AbsolutePath == "/jopa")
                {
                    string path = @"<!DOCTYPE html>
        <html>
            <head>
                <meta charset='utf8'>
                <title>METANIT.COM</title>
            </head>
            <body>
                <h2>NOT JOOOOOOOOOOOOOPA</h2>
            </body>
        </html>";

                

                    byte[] buffer = Encoding.UTF8.GetBytes(path);
                    // получаем поток ответа и пишем в него ответ
                    response.ContentLength64 = buffer.Length;
                    using Stream output = response.OutputStream;
                    // отправляем данные
                    output.Write(buffer);
                }
                else
                {
                    // отправляемый в ответ код html возвращает
                    string responseText =
                            @"<!DOCTYPE html>
        <html>
            <head>
                <meta charset='utf8'>
                <title>METANIT.COM</title>
            </head>
            <body>
                <h2>NOT JOOOOOOOOOOOOOPA</h2>
            </body>
        </html>"; 
                    byte[] buffer = Encoding.UTF8.GetBytes(responseText);
                    // получаем поток ответа и пишем в него ответ
                    response.ContentLength64 = buffer.Length;
                    using Stream output = response.OutputStream;
                    // отправляем данные
                    await output.WriteAsync(buffer);
                    output.FlushAsync();

                    Console.WriteLine("Запрос обработан");
                }

            }
        }
    }
}
