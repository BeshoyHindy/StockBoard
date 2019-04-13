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
    public class PersonController : BaseApiController
    {

        private readonly IPersonAppService _personAppService;

        public PersonController(
            IPersonAppService personAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _personAppService = personAppService;
        }

        [HttpGet]
        [SwaggerOperation(OperationId = "GelAllPersons")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Type = typeof(IEquatable<PersonViewModel>))]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.NotFound, Description = "Posts not found")]
        public IActionResult Get()
        {
            return Response(_personAppService.GetAll());
        }

        [HttpGet]
        [Route("{id:guid}")]
        [SwaggerOperation(OperationId = "GetPerson")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Type = typeof(PersonViewModel))]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.NotFound, Description = "the blog post not found")]
        public IActionResult Get(Guid id)
        {
            var viewModel = _personAppService.GetById(id);

            return Response(viewModel);
        }

        [HttpPost]
        [SwaggerOperation(OperationId = "AddNewPerson")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Description = "response of adding new post")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        public IActionResult Post([FromBody]PersonViewModel personViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(personViewModel);
            }

            _personAppService.AddNewPerson(personViewModel);

            return Response(personViewModel);
        }

        [HttpPut]
        [SwaggerOperation(OperationId = "UpdatePerson")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Description = "response of updating a post")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        public IActionResult Put([FromBody]PersonViewModel personViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(personViewModel);
            }

            _personAppService.Update(personViewModel);

            return Response(personViewModel);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [SwaggerOperation(OperationId = "RemovePerson")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Description = "response of deleting a post")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        public IActionResult Delete(Guid id)
        {
            _personAppService.Remove(id);

            return Response();
        }

    }
}
