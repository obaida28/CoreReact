// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// var connectionString = builder.Configuration.GetConnectionString(name:"LocalConnection");
// builder.Services.AddDbContext<ApplicationDbContext>(options => 
//     options.UseSqlServer(connectionString));

// builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();

// builder.Services.AddTransient<IUserService,UserService>();
// // builder.Services.AddHttpContextAccessor();
// builder.Services.AddCors();

// builder.Services.AddSwaggerGen();

// builder.Services.AddControllers().AddJsonOptions(x =>
//                 x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// builder.Services.AddAutoMapper(typeof(Program)); 
// // builder.Services.AddControllersWithViews();
// builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// builder.Services.AddAuthentication(options =>
// {
//     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//     options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
// }).AddJwtBearer(o =>
// {
//     o.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidIssuer = builder.Configuration["Jwt:Issuer"],
//         ValidAudience = builder.Configuration["Jwt:Audience"],
//         IssuerSigningKey = new SymmetricSecurityKey
//         (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
//         ValidateIssuer = true,
//         ValidateAudience = true,
//         ValidateLifetime = false,
//         ValidateIssuerSigningKey = true
//     };
// });
// builder.Services.AddAuthorization();

// var app = builder.Build();
// app.UseHttpsRedirection();
// app.MapGet("/security/getMessage", () => "Hello World!").RequireAuthorization();
// app.MapPost("/security/createToken",
// [AllowAnonymous] (User user) =>
// {
//     if (user.name == "a" && user.password == "123")
//     {
//         var issuer = builder.Configuration["Jwt:Issuer"];
//         var audience = builder.Configuration["Jwt:Audience"];
//         var key = Encoding.ASCII.GetBytes
//         (builder.Configuration["Jwt:Key"]);
//         var tokenDescriptor = new SecurityTokenDescriptor
//         {
//             Subject = new ClaimsIdentity(new[]
//             {
//                 new Claim("Id", Guid.NewGuid().ToString()),
//                 new Claim(JwtRegisteredClaimNames.Sub, user.name),
//                 new Claim(JwtRegisteredClaimNames.Email, user.name),
//                 new Claim(JwtRegisteredClaimNames.Jti,
//                 Guid.NewGuid().ToString())
//              }),
//             Expires = DateTime.UtcNow.AddMinutes(5),
//             Issuer = issuer,
//             Audience = audience,
//             SigningCredentials = new SigningCredentials
//             (new SymmetricSecurityKey(key),
//             SecurityAlgorithms.HmacSha512Signature)
//         };
//         var tokenHandler = new JwtSecurityTokenHandler();
//         var token = tokenHandler.CreateToken(tokenDescriptor);
//         var jwtToken = tokenHandler.WriteToken(token);
//         var stringToken = tokenHandler.WriteToken(token);
//         return Results.Ok(stringToken);
//     }
//     return Results.Unauthorized();
// });
// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// app.UseAuthentication();
// app.UseAuthorization();

// app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

// // app.UseStaticFiles(new StaticFileOptions
// // {
// //     FileProvider = new PhysicalFileProvider(
// //            Path.Combine(builder.Environment.ContentRootPath, "Pages")),
// //     RequestPath = "/Pages"
// // });

// app.MapControllers();

// app.Run();


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddAuthorization();
var app = builder.Build();
app.UseHttpsRedirection();
app.MapGet("/security/getMessage", () => "Hello World!").RequireAuthorization();
app.MapPost("/security/createToken",
[AllowAnonymous] (User user) =>
{
    if (user.name == "abc" && user.password == "123")
    {
        var issuer = builder.Configuration["Jwt:Issuer"];
        var audience = builder.Configuration["Jwt:Audience"];
        var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.name),
                new Claim(JwtRegisteredClaimNames.Email, user.name),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
             }),
            Expires = DateTime.UtcNow.AddMinutes(5),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha512Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = tokenHandler.WriteToken(token);
        var stringToken = tokenHandler.WriteToken(token);
        return Results.Ok(stringToken);
    }
    return Results.Unauthorized();
});
app.UseAuthentication();
app.UseAuthorization();
app.Run();