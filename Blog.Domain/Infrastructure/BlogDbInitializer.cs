using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Blog.Domain.Entities;
using Blog.Domain.IdentityService;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Blog.Domain.Infrastructure
{
    /// <summary>
    /// Database initializer, defined values.
    /// </summary>
    public class BlogDbInitializer : DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var adminRole = new IdentityRole { Name = "Admin" };
            var userRole = new IdentityRole { Name = "User" };
            roleManager.Create(adminRole);
            roleManager.Create(userRole);
            var admin = new ApplicationUser { Email = "admin@deardiary.com", UserName = "admin@deardiary.com" };
            var result = userManager.Create(admin, "123456");
            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, adminRole.Name);
                userManager.AddToRole(admin.Id, userRole.Name);
            }

            var t1 = new Tag() { Name = "Философия" };
            var t2 = new Tag() { Name = "История" };
            var t3 = new Tag() { Name = "Латынь" };
            var t4 = new Tag() { Name = "Английский" };
            context.Tags.Add(t1);
            context.Tags.Add(t2);
            context.Tags.Add(t3);
            context.Tags.Add(t4);
            context.Articles.Add(new Article
            {
                Name = "Категорический императив",
                Date = DateTime.Now,
                Content = "По Канту, благодаря наличию воли человек может совершать поступки, исходя из принципов." +
                        " Если человек устанавливает для себя принцип, зависящий от какого-либо объекта желания, то такой" +
                        " принцип не может стать моральным законом, поскольку достижение такого объекта всегда зависит от " +
                        "эмпирических условий. Понятие счастья, личного или общего, всегда зависит от условий опыта. Только " +
                        "безусловный принцип, т.е. не зависящий от всякого объекта желания, может иметь силу подлинного " +
                        "морального закона. Нравственный закон, не зависящий от посторонних причин, единственно делает " +
                        "человека по-настоящему свободным. В то же время, для человека моральный закон есть императив," +
                        " который повелевает категорически, поскольку человек имеет потребности и подвержен воздействию" +
                        " чувственных побуждений, а значит способен к максимам, противоречащим моральному закону. Императив " +
                        "означает отношение человеческой воли к этому закону как обязательность, т.е. внутреннее разумное" +
                        " принуждение к нравственным поступкам. В этом заключается понятие долга. Человек, таким образом," +
                        " должен стремиться в бесконечном прогрессе своих максим к идее нравственно совершенного закона. В" +
                        " этом состоит добродетель – самое высшее, чего может достичь конечный практический разум.",
                Tags = new List<Tag>() { t1, t2 }
            });
            context.Articles.Add(new Article
            {
                Name = "Lorem Ipsum",
                Date = DateTime.Today.AddHours(-1),
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt " +
                        "ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris" +
                        " nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit " +
                        "esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in" +
                        " culpa qui officia deserunt mollit anim id est laborum.  Et harum quidem rerum facilis est et expedita" +
                        " distinctio. Nam libero tempore, cum soluta nobis est eligendi optio, cumque nihil impedit, quo minus" +
                        " id, quod maxime placeat, facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. " +
                        "Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet, ut et" +
                        " voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente " +
                        "delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores" +
                        " repellat.",
                Tags = new List<Tag>() { t3 }
            });
            context.Articles.Add(new Article
            {
                Name = "Finibus Bonorum et Malorum",
                Date = DateTime.Today.AddHours(-2),
                Content = "Основными источниками для трактата были труды Платона, Аристотеля, Теофраста, Полибия," +
                        " Панетия и ряда философов-перипатетиков. Возможно, привлекались материалы Дикеарха. Наиболее велика" +
                        " зависимость этого сочинения от «Государства» Платона. Влияние классика греческой философии не " +
                        "ограничивается содержанием, но распространяется и на форму трактата. В обоих случаях трактат о " +
                        "государственном устройстве стилизован под происходящий во время праздников диалог с несколькими" +
                        " участниками, хотя активно беседует всего несколько человек. Цицерон вслед за Платоном начинает" +
                        " диалог с отвлечённых тем, обсуждает похожие темы и завершает его мистической картиной. В обоих " +
                        "случаях диалогическая форма трактата выглядит отчасти искусственной: за исключением книги III, длинные " +
                        "рассуждения Сципиона прерываются лишь небольшими репликами других участников. Обнаруживаются и" +
                        " некоторые черты сходства трактата с «Федоном» греческого автора — в частности, действие диалога " +
                        "на последнем году жизни главного героя и внимание к теме жизни после смерти[2]. Цицерон не был первым, " +
                        "кто попытался приспособить учение о смешанном государственном устройстве для римских политических " +
                        "реалий (впервые об этом задумался Полибий)[32]. Предполагается, что по крайней мере в книгах I—III " +
                        "Цицерон излагал теоретические идеи стоиков, в основном, по Панетию, а историю развития римской" +
                        " конституции — по Полибию. Тем не менее, этот трактат считается более оригинальным, чем ряд" +
                        " прочих философских сочинений Цицерона (за исключением сочинения «О законах»)." +
                        " «О государстве» — не компиляция греческих политических трактатов, а полностью оригинальное сочинение," +
                        " в котором Цицерон критически пересмотрел основные выводы греческой политической мысли, исходя " +
                        "из выводов философской школы скептиков. Так, определение государства Цицероном отличается от" +
                        " греческих образцов, а ряд высказанных им идей не имеет корней в выводах своих предшественников.",
                Tags = new List<Tag>() { t3, t1 }
            });
            context.Articles.Add(new Article
            {
                Name = "H. Rackham",
                Date = DateTime.Today.AddHours(-3),
                Content = "But I must explain to you how all this mistaken idea of denouncing " +
                        "pleasure and praising pain was born and I will give you a complete account of the system," +
                        " and expound the actual teachings of the great explorer of the truth, the master-builder" +
                        " of human happiness. No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, " +
                        "but because those who do not know how to pursue pleasure rationally encounter consequences " +
                        "that are extremely painful. Nor again is there anyone who loves or pursues or desires to obtain" +
                        " pain of itself, because it is pain, but because occasionally circumstances occur in which toil " +
                        "and pain can procure him some great pleasure. To take a trivial example, which of us ever" +
                        " undertakes laborious physical exercise, except to obtain some advantage from it? But who has" +
                        " any right to find fault with a man who chooses to enjoy a pleasure that has no annoying " +
                        "consequences, or one who avoids a pain that produces no resultant pleasure?",
                Tags = new List<Tag>() { t2, t4 }
            });
            context.Articles.Add(new Article
            {
                Name = "de Bonorum et Malorum",
                Date = new DateTime(2017, 6, 14, 18, 30, 00),
                Content = "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis" +
                        " praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi " +
                        "sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt " +
                        "mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et" +
                        " expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil " +
                        "impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis" +
                        " dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus" +
                        " saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum" +
                        " hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut " +
                        "perferendis doloribus asperiores repellat.",
                Tags = new List<Tag>() { t3, t2 }
            });
            context.Articles.Add(new Article
            {
                Name = "Rackham Bonorum",
                Date = new DateTime(2017, 8, 5, 16, 13, 59),
                Content = "On the other hand, we denounce with righteous indignation and dislike men who " +
                        "are so beguiled and demoralized by the charms of pleasure of the moment, so blinded by" +
                        " desire, that they cannot foresee the pain and trouble that are bound to ensue; and equal " +
                        "blame belongs to those who fail in their duty through weakness of will, which is the same " +
                        "as saying through shrinking from toil and pain. These cases are perfectly simple and easy to" +
                        " distinguish. In a free hour, when our power of choice is untrammelled and when nothing prevents" +
                        " our being able to do what we like best, every pleasure is to be welcomed and every pain avoided." +
                        " But in certain circumstances and owing to the claims of duty or the obligations of business it" +
                        " will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise" +
                        " man therefore always holds in these matters to this principle of selection: he rejects pleasures " +
                        "to secure other greater pleasures, or else he endures pains to avoid worse pains.",
                Tags = new List<Tag>() { t4 }
            });
            context.Articles.Add(new Article
            {
                Name = "Философские аспекты теории относительности",
                Date = new DateTime(2017, 12, 27, 11, 23, 36),
                Content = "Философскую основу теории относительности составляют гносеологические принципы " +
                        "наблюдаемости (запрещается пользоваться понятиями принципиально ненаблюдаемых объектов)," +
                        " простоты (все следствия теории необходимо вывести из наименьшего числа допущений), единства " +
                        "(идея единства знания и единства описываемого им объективного мира, реализуется в процессе обобщения" +
                        " законов природы, перехода от частных законов к более общим в ходе развития физики)," +
                        " методологический гипотезо-дедуктивный принцип (формулируются гипотезы, в том числе в математической" +
                        " форме, и на их основании выводятся проверяемые опытным путём следствия), онтологический" +
                        " принцип динамического детерминизма (данное состояние замкнутой физической системы однозначно" +
                        " определяет все её последующие состояния) и принцип соответствия (законы новой физической теории" +
                        " при надлежащем значении ключевого характеристического параметра, входящего в новую теорию, " +
                        "переходят в законы старой теории). Основываясь на принципе наблюдаемости, при создании специальной" +
                        " теории относительности Эйнштейн отверг понятие эфира и основанную на ней интерпретацию результатов" +
                        " опыта Майкельсона, данную Лоренцем. Осуществляя принцип единства, специальная теория относительности" +
                        " объединила понятия пространства и времени в единую сущность (четырёхмерное пространство-время" +
                        " Минковского), придала законам различных отраслей физики, механики и электродинамики единую " +
                        "лоренц-инвариантную форму, а общая теория относительности раскрыла связь между материей и геометрией" +
                        " пространства-времени, которая выражается общековариантными гравитационными уравнениями.",
                Tags = new List<Tag>() { t1 }
            });
            context.Feedbacks.Add(new Feedback
            {
                Author = "Георгий",
                Date = DateTime.Now,
                Content = "Вообще не понравилось. Зря потратил время.",
                ArticleId = 1
            });
            context.Feedbacks.Add(new Feedback
            {
                Author = "Артур",
                Date = DateTime.Now,
                Content = "Полностью согласен с автором",
                ArticleId = 1
            });
            context.Feedbacks.Add(new Feedback
            {
                Author = "Иван",
                Date = DateTime.Now,
                Content = "Интересная статья!",
                ArticleId = 1
            });
            context.Feedbacks.Add(new Feedback
            {
                Author = "Алина",
                Date = DateTime.Now,
                Content = "Вполне довольна прочтением.",
                ArticleId = 2
            });
            context.Feedbacks.Add(new Feedback
            {
                Author = "Максим",
                Date = DateTime.Now,
                Content = "Очень интересно. Продолжай в том же духе!",
                ArticleId = 2
            });
            context.Feedbacks.Add(new Feedback
            {
                Author = "Борис",
                Date = DateTime.Now,
                Content = "Классная история",
                ArticleId = 3
            });
            context.Feedbacks.Add(new Feedback
            {
                Author = "Глеб",
                Date = DateTime.Now,
                Content = "Красивый дизайн, удобный интерфейс. Всё устраивает."
            });
            context.Feedbacks.Add(new Feedback
            {
                Author = "Мария",
                Date = DateTime.Now,
                Content = "Хотелось бы увидеть больше возможностей. Не хватает регистрации."
            });
            context.Feedbacks.Add(new Feedback
            {
                Author = "Юлия",
                Date = DateTime.Now,
                Content = "Хороший сайт. Всем рекомендую"
            });
            context.Feedbacks.Add(new Feedback
            {
                Author = "Богдан",
                Date = DateTime.Now,
                Content = "Посредственный сайт."
            });
            context.Feedbacks.Add(new Feedback
            {
                Author = "Виталий",
                Date = DateTime.Now,
                Content = "Ужасный сайт!"
            });
            context.Feedbacks.Add(new Feedback
            {
                Author = "Никита",
                Date = DateTime.Now,
                Content = "Отличный сайт!"
            });
        }
    }
}