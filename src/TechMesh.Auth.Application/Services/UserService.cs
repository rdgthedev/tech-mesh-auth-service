using TechMesh.Auth.Application.Contracts.Services;
using TechMesh.Auth.Application.DTOs.Auth.Request;
using TechMesh.Auth.Application.DTOs.User.Request;
using TechMesh.Auth.Application.DTOs.Users.Response;
using TechMesh.Auth.Application.Mappers;
using TechMesh.Auth.Domain.Contracts.Repositories;
using TechMesh.Auth.Domain.Contracts.UnitOfWork;

namespace TechMesh.Auth.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(
        IUserRepository userRepository,
        IRoleRepository roleRepository,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<UserDetailsResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);

        if (!users.Any())
            throw new Exception("Users not found!");

        return Mapper.Map(users);
    }

    public async Task<UserDetailsResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(id, cancellationToken);

        if (user is null)
            throw new Exception("User not found!");

        return Mapper.Map(user);
    }

    public async Task UpdateAsync(UpdateUserRequest updateUserRequest, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(updateUserRequest.Id, cancellationToken);

        if (user is null)
            throw new Exception("User not found!");

        user.UpdateEmail(updateUserRequest.Email);

        await _userRepository.UpdateAsync(user, cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);
    }

    public async Task DeactivateAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(id, cancellationToken);

        if (user is null)
            throw new Exception("User not found!");

        user.Deativate();

        await _userRepository.UpdateAsync(user, cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);
    }

    public async Task ActivateAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(id, cancellationToken);

        if (user is null)
            throw new Exception("User not found!");

        user.Activate();

        await _userRepository.UpdateAsync(user, cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);
    }

    public async Task ChangeRoleAsync(ChangeUserRoleRequest changeUserRoleRequest, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(changeUserRoleRequest.UserId, cancellationToken);

        if (user is null)
            throw new Exception("User not found!");

        var role = await _roleRepository.GetByIdAsync(changeUserRoleRequest.RoleId, cancellationToken);

        if (role is null)
            throw new Exception("Role not found!");

        if (user.RoleId == role.Id)
            throw new Exception("Role already has this role!");

        user.ChangeRole(role.Id);

        await _userRepository.UpdateAsync(user, cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);
    }
}