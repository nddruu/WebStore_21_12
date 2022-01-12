var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddControllersWithViews();

 var app = builder.Build();

if (app.Environment.IsDevelopment()) 
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();   //Система маршрутизации приложения 

//Загрузка информации из файла конфигурации

//var configuration = app.Configuration;
//var greetings = configuration["CustomGreetings"];
//app.MapGet("/", () => greetings);

//app.MapGet("/", () => app.Configuration["CustomGreetings"]); //Закомментировали, чтобы исключить перехват корневых вызовов
app.MapGet("/throw", () =>
{
    throw new ApplicationException("Ошибка в программе!");
});

//app.MapDefaultControllerRoute(); //Сиситема MVC   //Использование вызова контроллера по умолчанию

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=index}/{id?}"); //явный вызов контроллера

app.Run();
