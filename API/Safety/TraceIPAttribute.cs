using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Сohabitation
{
    /// <summary>
    /// Обработчик запроса, учитывающий количество повторяющихся запросов. 
    /// </summary>
    public class TraceIpAttribute : ActionFilterAttribute
    {
        #region const

        /// <summary>
        /// Текст ошибки при многократном запросе.
        /// </summary>
        private const string Error = "Permission denied!";

        /// <summary>
        /// Максимальное количество запросов в минуту.
        /// </summary>
        private const int MinCountQuery = 5;

        /// <summary>
        /// Количество минут для реализации минимального количества запросов.
        /// Больше этого значения - блок. 
        /// </summary>
        private const int MaxCountMinutes = 1;

        /// <summary>
        /// Начальное количество запросов.
        /// </summary>
        private const int BeginCountQuery = 1;

        #endregion

        /// <summary>
        /// Ip детали запроса.
        /// </summary>
        private readonly IpDetailModel _model = new();

        /// <summary>
        /// Обработка входящего запроса.
        /// </summary>
        /// <param name="context">Запрос.</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var remoteIp = context.HttpContext.Connection.RemoteIpAddress.ToString();
            if (context.HttpContext.Session.GetString(remoteIp) == null)
            {
                CreateSession(context, remoteIp);
            }
            else
            {
                var record = JsonConvert.DeserializeObject<IpDetailModel>(context
                    .HttpContext
                    .Session
                    .GetString(remoteIp));
                
                if (DateTime.Now.Subtract(record.Time).TotalMinutes < MaxCountMinutes && record.Count > MinCountQuery)
                {
                    context.Result = new JsonResult(Error);
                    CreateSession(context, remoteIp);
                }
                else
                {
                    record.Count++;
                    context.HttpContext.Session.Remove(remoteIp);
                    context.HttpContext.Session.SetString(remoteIp, JsonConvert.SerializeObject(record));
                }
            }
        }

        /// <summary>
        /// Создание новой сессии.
        /// </summary>
        /// <param name="context">Действие запроса.</param>
        /// <param name="remoteIp">Информация об удаленном доступе.</param>
        private void CreateSession(ActionContext context, string remoteIp)
        {
            _model.Count = BeginCountQuery;
            _model.IpAddress = remoteIp;
            _model.Time = DateTime.Now;
            context.HttpContext.Session.SetString(remoteIp, JsonConvert.SerializeObject(_model));
        }
    }
}