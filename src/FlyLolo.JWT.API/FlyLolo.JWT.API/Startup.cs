using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FlyLolo.JWT.API
{
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        #region 读取配置
        JWTConfig config = new JWTConfig();
        Configuration.GetSection("JWT").Bind(config);
        #endregion

        #region 启用JWT认证
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).
        AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = config.Issuer,
                ValidAudience = config.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.IssuerSigningKey)),
                //ClockSkew = TimeSpan.FromMinutes(5)
            };
            //通过TokenValidationParameters的构造方法查看参数的默认值如下：
            //public TokenValidationParameters()
            //{
            //    RequireExpirationTime = true;
            //    RequireSignedTokens = true;
            //    SaveSigninToken = false;
            //    ValidateActor = false;
            //    ValidateAudience = true;
            //    ValidateIssuer = true;
            //    ValidateIssuerSigningKey = false;
            //    ValidateLifetime = true;
            //    ValidateTokenReplay = false;
            //}
            //DefaultClockSkew = TimeSpan.FromSeconds(300); //即ClockSkew的默认值为5分钟
        });
        #endregion

        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseAuthentication();
        app.UseMvc();
    }
}
}
