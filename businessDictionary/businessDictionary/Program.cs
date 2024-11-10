using businessDictionary.Client.Pages;
using businessDictionary.Components;
using businessDictionary.services;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

// Define the fixed token for authorization
var fixedToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJTZXNzaW9uSWQiOiIyY0lld0ZMWU9Xb1pfN0IxTXZ1SFBYMWxpM2FWVnZNNWZ5WjdaRnI3cFQ4eVhtR2lINjExdVhldU5LdGJwckYzdzFTTVFmVUNuUHhSdVNtLXQ0dnlqYWFjalVCLTd1dkdQbXltQ2JFRGV3bz0iLCJqdGkiOiJiMWZlNGRjMC1lZWM3LTQ3ZWUtOTE4NS04NjRkMTE0MmMwYWYiLCJleHAiOjE3MzExMzMwNTh9.LEmNAAasXkfnF1dDlGJ7twOWhfI2h4NGSuyifLoibfQ";

// Register HttpClient with the base address and default authorization header
builder.Services.AddScoped(sp => {
    var httpClient = new HttpClient
    {
        BaseAddress = new Uri("https://app.datablueprint.ai/")
    };
    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", fixedToken);
    return httpClient;
});
builder.Services.AddScoped<BusinessDictionaryService>();
builder.Services.AddScoped<AuthService>();


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
