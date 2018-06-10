using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ResidenceAdmin.DomainModel;
using ResidenceAdmin.Persistency;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class AccountController : ApiController
    {

        [Route("api/User/Register")]
        [HttpPost]
        [AllowAnonymous]
        public IdentityResult Register(AccountModel model)
        {
            var userStore = new UserStore<User>(new PersistencyContext());
            var manager = new UserManager<User>(userStore);
            var user = new User() { UserName = model.UserName, Email = model.Email };
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 3
            };
            IdentityResult result = manager.Create(user, model.Password);
            return result;
        }

        [HttpGet]
        [Route("api/GetUserClaims")]
        [AllowAnonymous]

        public AccountModel GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            if(User.Identity.IsAuthenticated)
            {
                IEnumerable<Claim> claims = identityClaims.Claims;
                AccountModel model = new AccountModel()
                {
                    UserName = identityClaims.FindFirst("Username").Value,
                    Email = identityClaims.FindFirst("Email").Value,
                    FirstName = identityClaims.FindFirst("FirstName").Value,
                    LastName = identityClaims.FindFirst("LastName").Value,
                    LoggedOn = identityClaims.FindFirst("LoggedOn").Value
                };
                return model;
            }
            return new AccountModel();
        }

        [HttpGet]
        [Route("api/GetUser")]
        [AllowAnonymous]
        public User GetUser()
        {
            var db = new PersistencyContext();
            string currentUserId = User.Identity.GetUserId();
            User currentUser = db.Users.Find(currentUserId);
            return currentUser;
        }
    }
}
