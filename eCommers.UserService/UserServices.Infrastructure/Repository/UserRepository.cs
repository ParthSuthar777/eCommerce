using Dapper;
using UserService.Core.Entities;
using UserService.Core.RepositoryContracts;
using UserServices.Infrastructure.DbContext;

namespace UserServices.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperDbContext _dbContext;

        public UserRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Add User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> AddUser(ApplicationUser user)
        {
            user.UserId = Guid.NewGuid();

            //SQL query
            var query = @"INSERT INTO public.""Users"" (""UserId"",""Name"",""Email"",""Password"",
                ""Gender"") VALUES (@UserId, @Name, @Email, @Password, @Gender)";
            var sqlAffectedRow = await _dbContext.DbConnection.ExecuteAsync(query, user);

            if (sqlAffectedRow <= 0)
            {
                return null;
            }
            return user;
        }
        /// <summary>
        /// Get User Details by Email id and Password
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string Email, string Password)
        {
            var query = @"SELECT * FROM public.""Users"" WHERE ""Email"" = @Email and ""Password"" = @Password";

            var parameter = new DynamicParameters();
            parameter.Add("Email", Email);
            parameter.Add("Password", Password);

            var user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query,parameter);

            return user;
        }
    }
}
