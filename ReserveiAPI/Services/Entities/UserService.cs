using AutoMapper;
using ReserveiAPI.Objects.DTOs.Entities;
using ReserveiAPI.Repositories.Interfaces;
using ReserveiAPI.Services.Interfaces;
using ReserveiAPI.Objects.Models.Entities;

namespace ReserveiAPI.Services.Entities
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var userModel = await _userRepository.GetAll();

            userModel.ToList().ForEach(u => u.PasswordUser = "");
            return _mapper.Map<IEnumerable<UserDTO>>(userModel);
        }

        public async Task<UserDTO> GetById(int id)
        {
            var userModel = await _userRepository.GetById(id);

            if (userModel is not null) userModel.PasswordUser = "";
            return _mapper.Map<UserDTO>(userModel);
        }

        public async Task Create(UserDTO userDTO)
        {
            var userModel = _mapper.Map<UserModel>(userDTO);
            await _userRepository.Create(userModel);

            userDTO.Id = userModel.Id;
            userDTO.PasswordUser = "";
        }

        public async Task Update(UserDTO userDTO)
        {
            var userModel = _mapper.Map<UserModel>(userDTO);
            await _userRepository.Update(userModel);
            userDTO.PasswordUser = "";
        }

        public async Task Delete(UserDTO userDTO)
        {
            var userModel = _mapper.Map<UserModel>(userDTO);
            await _userRepository.Delete(userModel);

            userDTO.PasswordUser = "";
        }
    }
}
