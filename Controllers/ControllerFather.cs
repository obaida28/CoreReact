namespace CoreReact.Controllers;
[ApiController]
[Route("[controller]")]
public class ControllerFather : ControllerBase
{
    protected readonly ApplicationDbContext context;
    public readonly IMapper mapper ;
    public ControllerFather(ApplicationDbContext context , IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }
}