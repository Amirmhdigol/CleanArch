using CleanArch.Contracts;
using CleanArch.Domain.ProductsAgg.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.EventHandlers
{
    public class ProductCreatedSendSmsEventHandler : INotificationHandler<ProductCreated>
    {
        private readonly ISmsService _smsService;

        public ProductCreatedSendSmsEventHandler(ISmsService smsService)
        {
            _smsService = smsService;
        }

        public async Task Handle(ProductCreated notification, CancellationToken cancellationToken)
        {
             _smsService.SendSMS(new SMSBody());
            await Task.CompletedTask;
        }
    }
}
