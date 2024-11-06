using businessDictionary.Client.Pages;
using businessDictionary.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

var fixedToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJTZXNzaW9uSWQiOiIyY0lld0ZMWU9Xb1pfN0IxTXZ1SFBYMWxpM2FWVnZNNWZ5WjdaRnI3cFQ4eVhtR2lINjExdVhldU5LdGJwckYzdzFTTVFmVUNuUHhSdVNtLXQ0dnlqYWFjalVCLTd1dkdQbXltQ2JFRGV3bz0iLCJqdGkiOiJiMWZlNGRjMC1lZWM3LTQ3ZWUtOTE4NS04NjRkMTE0MmMwYWYiLCJleHAiOjE3MzExMzMwNTh9.LEmNAAasXkfnF1dDlGJ7twOWhfI2h4NGSuyifLoibfQ";
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://app.datablueprint.ai/"),
    DefaultRequestHeaders =
    {
        Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", fixedToken)
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(businessDictionary.Client._Imports).Assembly);

app.Run();
