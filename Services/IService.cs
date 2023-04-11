// namespace CoreReact.Services;
public interface IService<T>
{
    Task<T> add(T user);
    T update(T user);
    T delete(T user);
    Task<T> getById(int id);
    Task<IEnumerable<T>> getAll();
}