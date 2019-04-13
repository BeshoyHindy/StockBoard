using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockBoard.Application.Interfaces;
using StockBoard.Application.ViewModels;
using StockBoard.Domain.Core.Bus;
using StockBoard.Domain.Core.Notifications;
using Swashbuckle.AspNetCore.Annotations;

namespace StockBoard.Service.Api.Controllers
{
    [Route("[controller]")]
    public class StockController : BaseApiController
    {

        private readonly IStockAppService _stockAppService;

        public StockController(
            IStockAppService stockAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _stockAppService = stockAppService;
        }

        [HttpGet]
        [SwaggerOperation(OperationId = "GelAllStocks")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Type = typeof(IEquatable<StockViewModel>))]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.NotFound, Description = "Posts not found")]
        public IActionResult Get()
        {
            return Response(_stockAppService.GetAll());
        }

        [HttpGet]
        [Route("{id:guid}")]
        [SwaggerOperation(OperationId = "GetStock")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Type = typeof(StockViewModel))]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.NotFound, Description = "the blog post not found")]
        public IActionResult Get(Guid id)
        {
            var viewModel = _stockAppService.GetById(id);

            return Response(viewModel);
        }

        [HttpPost]
        [SwaggerOperation(OperationId = "AddNewStock")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Description = "response of adding new post")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        public IActionResult Post([FromBody]StockViewModel stockViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(stockViewModel);
            }

            _stockAppService.AddNewStock(stockViewModel);

            return Response(stockViewModel);
        }

        [HttpPut]
        [SwaggerOperation(OperationId = "UpdateStock")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Description = "response of updating a post")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        public IActionResult Put([FromBody]StockViewModel stockViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(stockViewModel);
            }

            _stockAppService.Update(stockViewModel);

            return Response(stockViewModel);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [SwaggerOperation(OperationId = "RemoveStock")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Description = "response of deleting a post")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        public IActionResult Delete(Guid id)
        {
            _stockAppService.Remove(id);

            return Response();
        }

    }

}
