namespace CoreReact.Services;
public class UserService : IUserService 
{
    protected readonly ApplicationDbContext context;
    protected readonly IMapper mapper ;
    public UserService(ApplicationDbContext context , IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }
    public async Task<User> add(User user)
    {
       await context.AddAsync(user);
       await context.SaveChangesAsync();
       return user;
    }
    public async Task<UserDTO> add(UserDTO _user)
    {
       var user = mapper.Map < User > (_user);
       await context.AddAsync(user);
       await context.SaveChangesAsync();
       return _user;
    }
    public User delete(User user)
    {
        context.Remove(user);
        context.SaveChanges();
        return user;
    }
    public async Task<IEnumerable<User>> getAll()
    {
        return await context.pj3_Users.ToListAsync();
    }
    public async Task<IEnumerable<UserDTO>> getAll_dto()
    {
        var users = await getAll();
        return mapper.Map < IEnumerable<UserDTO> > (users);
    }
    public async Task<User> getById(int id)
    {
        return await context.pj3_Users.SingleOrDefaultAsync(user => user.Id == id);
    }
    public User update(User user)
    {
        context.Update(user);
        context.SaveChanges();
        return user;
    }
    public User mapManual(User user , UserDTO userDTO)
    {
        user.name = userDTO.name;
        user.address = userDTO.address.ToJsonString();
        return user;
    }
}