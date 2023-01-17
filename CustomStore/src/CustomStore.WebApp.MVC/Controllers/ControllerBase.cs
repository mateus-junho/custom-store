using CustomStore.Core.Communication;
using CustomStore.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomStore.WebApp.MVC.Controllers
{
    public class ControllerBase : Controller
    {
        private readonly DomainNotificationHandler notificationHandler;
        private readonly ICustomMediatrHandler mediatrHandler;

        // mocked client to get from claim, cookie, or other source
        protected Guid ClientId = Guid.Parse("7389626b-aa30-4651-bce0-cdb1322019ff");

        public ControllerBase(INotificationHandler<DomainNotification> notificationHandler,
                              ICustomMediatrHandler customMediatrHandler)
        {
            this.notificationHandler = (DomainNotificationHandler)notificationHandler;
            this.mediatrHandler = customMediatrHandler;
        }

        protected bool IsValidOperation()
        {
            return !notificationHandler.HasNotifications();
        }

        protected IEnumerable<string> GetErrorNotifications()
        {
            return notificationHandler.GetNotifications().Select(n => n.Value).ToList();
        }

        protected void NotificateError(string code, string message)
        {
            mediatrHandler.PublishNotification(new DomainNotification(code, message));
        }
    }
}
