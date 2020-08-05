using AutoMapper;
using FinanceTracker.API.AuthorizationAttributes;
using FinanceTracker.Business.Dtos;
using FinanceTracker.Business.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FinanceTracker.API.Controllers
{
    [ApiController]
    [Route("api/user/{userId}")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userUepository;
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userUepository,
                              IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper)
        {
            _userUepository = userUepository;
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetUser")]
        public async Task<IActionResult> GetUser(int userId)
        {
            var user = await _userUepository.RetrieveById(userId);
            var userToReturn = _mapper.Map<UserForDetailedDto>(user);
            return Ok(userToReturn);
        }

        [HttpPut]
        [UserAuthorization]
        [Route("UpdateUserBaseCurrency/{userCurrency}")]
        public async Task<IActionResult> UpdateUserBaseCurrency(int userId, string userCurrency)
        {
            var userFromRepo = await _userUepository.RetrieveById(userId);

            if (userFromRepo.UserCurrency != userCurrency)
            {
                userFromRepo.UserCurrency = userCurrency;
                if (await _unitOfWorkRepository.SaveChanges() > 0)
                {
                    var userToReturn = _mapper.Map<UserForDetailedDto>(userFromRepo);
                    return Ok(userToReturn);
                }
            }
            else
            {
                return BadRequest("User currency was not modified. In order to save your changes, please chose another currecy.");
            }

            throw new System.Exception($"Unable to save user currency, please, try again later.");
        }
    }
}