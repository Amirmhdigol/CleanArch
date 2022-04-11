using CleanArch.Domain.UsersAgg.Events;
using CleanArch.Domain.UsersAgg.Repository;
using CleanArch.Query.Models.Users;
using CleanArch.Query.Models.Users.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Query.EventHandlers.Users
{
    public class UserRegisteredEventHandler : INotificationHandler<UserRegistered>
    {
        private readonly IUserReadRepository _readRepository;
        private readonly IUserRepository _writeRepository;

        public UserRegisteredEventHandler(IUserReadRepository readRepository, IUserRepository userRepository)
        {
            _readRepository = readRepository;
            _writeRepository = userRepository;
        }

        public async Task Handle(UserRegistered notification, CancellationToken cancellationToken)
        {
            var user = await _writeRepository.GetbyEmail(notification.Email);
            await _readRepository.Insert(new UserReadModel()
            {
                Email = user.Email,
                CreationDate = user.CreationDate,
                Family = user.Family,
                Id = user.Id,
                Name = user.Name,
                Phone = user.PhoneNumber.Phone
            });
        }
    }
}
