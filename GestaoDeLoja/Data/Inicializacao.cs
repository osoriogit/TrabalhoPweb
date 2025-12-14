using Microsoft.AspNetCore.Identity;

namespace GestaoDeLoja.Data
{
    public static class Inicializacao
    {
        public static async Task CriaDadosIniciais(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            //Adicionar default Roles
            string[] roles = ["Admin", "Gestor", "Cliente"];

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    IdentityRole roleRole = new IdentityRole(role);
                    await roleManager.CreateAsync(roleRole);
                }
            }

            //Adicionar Default User - Admin
            string adminEmail = "admin@mail.com";
            string adminPassword = "Admin@123";
            if (await userManager.FindByEmailAsync(adminEmail) == null)
                {
                ApplicationUser adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                    Nome = "Admin",
                    Apelido = "yolo",
                    NIF = 123456789,
                    Rua = "Rua Principal, 123",
                    Localidade1 = "Lisboa",
                    Localidade2 = "Lisboa",
                    Pais = "Portugal"
                };
                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }



        }
    }
}
