using Microsoft.Win32;
using RequestsToServer.Services.Interfaces;

namespace RequestsToServer
{
    public class App
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IResourceService _resourceService;

        public App(IUserService userService, IAuthenticationService authenticationService, IResourceService resourceService)
        {
            _userService = userService;
            _authenticationService = authenticationService;
            _resourceService = resourceService;
        }

        public async Task StartAsync()
        {
            var getUsersListByPage = Task.Run(async () => await _userService.GetUsersByPageAsync(2));
            var getUserSingleById = Task.Run(async () => await _userService.GetUserAsync(2));
            var getUserSingleByIdNotFound = Task.Run(async () => await _userService.GetUserAsync(23));

            var getResourcesList = Task.Run(async () => await _resourceService.GetResourcesAsync());
            var getResourcesSingle = Task.Run(async () => await _resourceService.GetResourceAsync(2));
            var getResourcesSingleNotFound = Task.Run(async () => await _resourceService.GetResourceAsync(23));

            var createUserEmployee = Task.Run(async () => await _userService.CreateUserEmployeeAsync("oleksii", "developer")); // POST
            var updateUserEmployee = Task.Run(async () => await _userService.UpdateUserEmployeeAsync(2, "oleksii", ".NET developer?")); // PUT
            var modifyUserEmployee = Task.Run(async () => await _userService.ModifyUserEmployeeAsync(2, "oleksii", ".NET developer")); // PATCH
            var removeUserEmployee = Task.Run(async () => await _userService.RemoveUserEmployeeAsync(2)); // DELETE

            var registerSuccessful = Task.Run(async () => await _authenticationService.RegisterAsync("jocker_cardo@reqres.in", "joke777"));
            var registerUnsuccessful = Task.Run(async () => await _authenticationService.RegisterAsync("sundae@fifl", null!));
            var loginSuccessful = Task.Run(async () => await _authenticationService.LoginAsync("jocker_cardo@reqres.in", "joke777"));
            var loginUnsuccessful = Task.Run(async () => await _authenticationService.LoginAsync("jocker_cardo@reqres.in", null!));

            var getUserWithDelayedResponse = Task.Run(async () => await _userService.GetUsersByPageAsync(3));

            await Task.WhenAll(
                getUsersListByPage,
                getUserSingleById,
                getUserSingleByIdNotFound,
                getResourcesList,
                getResourcesSingle,
                getResourcesSingleNotFound,
                createUserEmployee,
                updateUserEmployee,
                modifyUserEmployee,
                removeUserEmployee,
                registerSuccessful,
                registerUnsuccessful,
                loginSuccessful,
                loginUnsuccessful,
                getUserWithDelayedResponse);

            var usersListByPage = await getUsersListByPage;
            var userSingleById = await getUserSingleById;
            var userSingleByIdNotFound = await getUserSingleByIdNotFound;

            var resourcesList = await getResourcesList;
            var resourcesSingle = await getResourcesSingle;
            var resourcesSingleNotFound = await getResourcesSingleNotFound;

            var createUserEmployeeResult = await createUserEmployee;
            var updateUserEmployeeResult = await updateUserEmployee;
            var modifyUserEmployeeResult = await modifyUserEmployee;
            var removeUserEmployeeResult = await removeUserEmployee;

            var registerSuccessfulResult = await registerSuccessful;
            var registerUnsuccessfulResult = await registerUnsuccessful;
            var loginSuccessfulResult = await loginSuccessful;
            var loginUnsuccessfulResult = await loginUnsuccessful;
        }
    }
}