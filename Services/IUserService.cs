namespace CoreReact.Services;
public interface IUserService  : IService<User>
{
    Task<UserDTO> add(UserDTO user);
    Task<IEnumerable<UserDTO>> getAll_dto();
    public User mapManual(User u , UserDTO uu);
}