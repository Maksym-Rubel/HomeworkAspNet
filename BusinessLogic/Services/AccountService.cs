using AutoMapper;
using BusinessLogic.DException;
using BusinessLogic.DTOs.Account;
using BusinessLogic.Interface;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class AccountService : IAccountService
    {
        private readonly SongDbContext ctx;

        public IJwtService jwtService { get; }
        public UserManager<User> userManager { get; }
        public SignInManager<User> signInManager { get; }
        public IMapper mapper { get; }

        //private readonly SongDbContext ctx;
        //SongDbContext ctx
        public AccountService(IJwtService jwtService,UserManager<User> userManager,SignInManager<User> signInManager,IMapper mapper,SongDbContext ctx)
        {
            this.jwtService = jwtService;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
            this.ctx = ctx;
            //this.ctx = ctx;

        }

        public async Task<LoginModelResponse> Refresh(string refreshToken, string? IpAddress)
        {
            var user = await userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(m=> m.Token == refreshToken));

            if (user == null)
            {
                throw new HttpException("Invalid User",HttpStatusCode.Unauthorized);
            }
            var token = ctx.RefreshTokens.Single(x => x.Token == refreshToken);
            if(token == null || token.IsExpired)
            {
                throw new HttpException("Invalid refresh token", HttpStatusCode.Unauthorized);
            }


            var newJwt = jwtService.GenerateToken(await jwtService.GetClaims(user));
            var newRefresh = jwtService.GenerateRefreshToken(IpAddress ?? "Unknown");
            user.RefreshTokens.Add(newRefresh);
            await ctx.SaveChangesAsync();


            return new()
            {
                AccesessToken = newJwt,
                RefreshToken = newRefresh.Token
            };
        }
        public async Task<LoginModelResponse> Login(LoginModel model,string? IpAddress)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null || !await userManager.CheckPasswordAsync(user, model.Password))
                throw new HttpException("Invalid email", HttpStatusCode.BadRequest);
            var newRefresh = jwtService.GenerateRefreshToken(IpAddress ?? "Unknown");
            user.RefreshTokens.Add(newRefresh);
            await ctx.SaveChangesAsync();


            //await signInManager.SignInAsync(user,true);

            return new()
            {
                AccesessToken = jwtService.GenerateToken(await jwtService.GetClaims(user)),
                RefreshToken = newRefresh.Token,
                Role = await userManager.GetRolesAsync(user),

            };

        }
        public async Task Register(RegisterModel model)
        {
            var user = mapper.Map<User>(model);
            var result = await userManager.CreateAsync(user, model.Password);
            if(!result.Succeeded)
                throw new HttpException(result.Errors.FirstOrDefault()?.Description ?? "Error",HttpStatusCode.BadRequest);
           
        }
        public async Task Logout(LogoutModel model)
        {
            await signInManager.SignOutAsync();

        }

    }
}
