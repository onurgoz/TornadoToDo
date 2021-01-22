using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TornadoToDo.Business.Concrete;
using TornadoToDo.Business.Interfaces;
using TornadoToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using TornadoToDo.DataAccess.Interface;

namespace TornadoToDo.Business.MicrosoftIoC
{
    public static class CustomIocExtension
    {
        public static void AddDependicies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<IAppUserService,AppUserManager>();

            services.AddScoped<IBoardDal, EfBoardRepository>();
            services.AddScoped<IBoardService, BoardManager>();

            services.AddScoped<IColumnDal, EfColumnRepository>();
            services.AddScoped<IColumnService, ColumnManager>();

            services.AddScoped<ICardDal, EfCardRepository>();
            services.AddScoped<ICardService, CardManager>();
        }
    }
}