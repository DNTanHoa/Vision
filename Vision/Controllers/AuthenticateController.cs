using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vision.Models;
using Vision.Models.Repositories;
using Vision.RequestModels;
using Vision.SharedModels.Authenticate;
using Vision.SharedModels.Common;
using Vision.SharedUltilities.Extensions;
using Vision.SharedUltilities.Helpers;

namespace Vision.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IGenericRepository<User> genericUserRepository;
        private readonly IMapper mapper;

        public AuthenticateController(IGenericRepository<User> genericUserRepository,
            IMapper mapper)
        {
            this.genericUserRepository = genericUserRepository;
            this.mapper = mapper;
        }
        
        [HttpPost]
        public ActionResult<CommonApiResponeModel> Authenticate(AuthenticateRequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                var user = genericUserRepository.GetByID(requestModel.username);
                if (user != null)
                {
                    if (SecurityHelper.Encrypt(user.hashKey, requestModel.password) == user.password)
                    {
                        var authenticatedUser = new AuthenticatedUser();
                        authenticatedUser = mapper.Map<AuthenticatedUser>(user);

                        authenticatedUser.token = ClaimHelpers.GenerateTokenStringForClaims(user.ToDictionaryStringString());

                        return new CommonApiResponeModel()
                            .SetResult(new CommonApiResult()
                            {
                                messageCode = "200",
                                message = "Success"
                            })
                            .SetData(authenticatedUser);
                    }
                    else
                    {
                        return new CommonApiResponeModel()
                            .SetResult(new CommonApiResult()
                            {
                                messageCode = "403",
                                message = "Invalid password"
                            });
                    }
                }
                else
                {
                    return new CommonApiResponeModel()
                    .SetResult(new CommonApiResult()
                    {
                        messageCode = "403",
                        message = "Username does not exist!"
                    });
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
