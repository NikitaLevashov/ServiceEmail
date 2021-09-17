using ServiceEmail.BLL.ModelBLL.User;

namespace ServiceEmail.BLL.CronService
{
    public class Cron
    {
        private EmailScheduler emailScheduler;
        public Cron()
        {
            emailScheduler = new EmailScheduler();
        }
        public EmailScheduler CronSetting(UserBLL user)
        {
            UserHelper.user = user;
            return emailScheduler;
        }
    }
}
