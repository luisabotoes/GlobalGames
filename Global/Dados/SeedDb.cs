

namespace Global.Dados
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Global.Dados.Entidades;
    using Global.Helpers;
    using Microsoft.AspNetCore.Identity;
    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private readonly Random random;

        public SeedDb(DataContext context,IUserHelper userHelper )
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userHelper.GetUserByEmailAsync("luisa.martins.oficial@gmail.com");
            
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Luísa",
                    LastName = "Martins",
                    Email = "luisa.martins.oficial@gmail.com",
                    UserName = "luisa.martins.oficial@gmail.com",
                    PhoneNumber = "989999999"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create user in seeder.");
                }
            }

            if (!this.context.Inscricoes.Any())
            {
                this.AddInscricao("Maria Papoila", user);
                this.AddInscricao("João Ratão", user);
                this.AddInscricao("Príncipe Encantado", user);
                this.AddInscricao("Gata Borralheira", user);
                this.AddInscricao("Fada Sininho", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddInscricao(string nome, User user)
        {
            this.context.Inscricoes.Add(new Inscricao
            {
                Nome = nome,
                User = user

            });
        }
    }
}
