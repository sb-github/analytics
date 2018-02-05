using AutoMapper;
using ReportingDataBase.DAL;
using ReportingDataBase.DAL.SQL;
using ReportingDataBase.MapperSettings;
using ReportingDataBase.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DataBaseAnalytics
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
                cfg.AddProfile<MapProfile>();
            }
           );
            

            DatabaseContext context = new DatabaseContext();
            SkillRepository repo = new SkillRepository(context);
            repo.copySkills();
            UnitOfWork skill = new UnitOfWork();
            var list = skill.SkillRepository.GetAll();
            
            ReportingSkillRepository reporting = new ReportingSkillRepository(context);
            foreach (var i in list)
            {
                reporting.FormReporting(DateTime.Now, i.SkillName , i.ID);
            }


            //Start timer with start project
            Thread thread = new Thread(new ThreadStart(Time));
            thread.IsBackground = true;
            thread.Name = "Time";
            thread.Start();
        }

        //Work of timer every day
        protected void TimerEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (DateTime.Now.Hour == 0)
            {
                DateTime dateReporting = DateTime.Now.AddDays(-1);
                //call method
            }
        }

        //Timer configuration
        protected void Time()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(TimerEvent);
            timer.Interval = 600000;
            timer.Enabled = true;
            timer.AutoReset = true;
            timer.Start();
        }
    }
}
