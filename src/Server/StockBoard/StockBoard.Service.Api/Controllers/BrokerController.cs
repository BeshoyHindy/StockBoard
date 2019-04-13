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
    public class BrokerController : BaseApiController
    {

        private readonly IBrokerAppService _brokerAppService;

        public BrokerController(
            IBrokerAppService brokerAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _brokerAppService = brokerAppService;
        }

        [HttpGet]
        [SwaggerOperation(OperationId = "GelAllBrokers")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Type = typeof(IEquatable<BrokerViewModel>))]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.NotFound, Description = "Posts not found")]
        public IActionResult Get()
        {
            return Response(_brokerAppService.GetAll());
        }

        [HttpGet]
        [Route("{id:guid}")]
        [SwaggerOperation(OperationId = "GetBroker")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Type = typeof(BrokerViewModel))]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.NotFound, Description = "the blog post not found")]
        public IActionResult Get(Guid id)
        {
            var viewModel = _brokerAppService.GetById(id);

            return Response(viewModel);
        }

        [HttpPost]
        [SwaggerOperation(OperationId = "AddNewBroker")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Description = "response of adding new post")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        public IActionResult Post([FromBody]BrokerViewModel brokerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(brokerViewModel);
            }

            _brokerAppService.AddNewBroker(brokerViewModel);

            return Response(brokerViewModel);
        }

        [HttpPut]
        [SwaggerOperation(OperationId = "UpdateBroker")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Description = "response of updating a post")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        public IActionResult Put([FromBody]BrokerViewModel brokerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(brokerViewModel);
            }

            _brokerAppService.Update(brokerViewModel);

            return Response(brokerViewModel);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [SwaggerOperation(OperationId = "RemoveBroker")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Description = "response of deleting a post")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        public IActionResult Delete(Guid id)
        {
            _brokerAppService.Remove(id);

            return Response();
        }

    }

}
