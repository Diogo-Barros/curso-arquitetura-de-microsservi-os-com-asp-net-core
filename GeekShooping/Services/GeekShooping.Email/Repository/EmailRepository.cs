using GeekShooping.Email.Context;
using GeekShooping.Email.Messages;
using GeekShooping.Email.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekShooping.Email.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly DbContextOptions<PostgreSQLDBContext> _dbOptions;

        public EmailRepository(DbContextOptions<PostgreSQLDBContext> dbOptions)
        {
            _dbOptions = dbOptions;
        }

        public async Task LogEmail(UpdatePaymentResultMessage message)
        {
            EmailLog email = new EmailLog()
            {
                Email = message.Email,
                SentDate = DateTime.UtcNow,
                Log = $"Order - {message.OrderId} has been created successfully!"
            };

            await using var db = new PostgreSQLDBContext(_dbOptions);
            db.Emails.Add(email);
            await db.SaveChangesAsync();
        }
    }
}
