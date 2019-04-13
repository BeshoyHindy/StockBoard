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
    public class OrderController : BaseApiController
    {

        private readonly IOrderAppService _orderAppService;

        public OrderController(
            IOrderAppService orderAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _orderAppService = orderAppService;
        }

        [HttpGet]
        [SwaggerOperation(OperationId = "GelAllOrders")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Type = typeof(IEquatable<OrderViewModel>))]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.NotFound, Description = "Posts not found")]
        public IActionResult Get()
        {
            return Response(_orderAppService.GetAll());
        }

        [HttpGet]
        [Route("{id:guid}")]
        [SwaggerOperation(OperationId = "GetOrder")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Type = typeof(OrderViewModel))]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.NotFound, Description = "the blog post not found")]
        public IActionResult Get(Guid id)
        {
            var viewModel = _orderAppService.GetById(id);

            return Response(viewModel);
        }

        [HttpPost]
        [SwaggerOperation(OperationId = "AddNewOrder")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Description = "response of adding new post")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        public IActionResult Post([FromBody]OrderViewModel orderViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(orderViewModel);
            }

            _orderAppService.AddNewOrder(orderViewModel);

            return Response(orderViewModel);
        }

        [HttpPut]
        [SwaggerOperation(OperationId = "UpdateOrder")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Description = "response of updating a post")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        public IActionResult Put([FromBody]OrderViewModel orderViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(orderViewModel);
            }

            _orderAppService.Update(orderViewModel);

            return Response(orderViewModel);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [SwaggerOperation(OperationId = "RemoveOrder")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Description = "response of deleting a post")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        public IActionResult Delete(Guid id)
        {
            _orderAppService.Remove(id);

            return Response();
        }

    }

}
