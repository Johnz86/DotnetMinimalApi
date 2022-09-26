namespace Minimal.Api.Tests;

using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;

public class UnitTest
{
    [Fact]
    public async Task HelloWorldTests()
    {
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();

        var response = await client.GetStringAsync("/");
    
        Assert.Equal("Hello World!", response);
    }

    [Fact]
    public async Task PostOneTodoResponseCreated()
    {
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        using var response = await client.PostAsJsonAsync("/todoitems/", new Todo{
            Name = "My Todo is incomplete",
            IsComplete = false
        });
        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        Assert.NotNull(response.Headers.Location);
        Assert.Matches("My Todo is incomplete", responseBody);
    }


    [Fact]
    public async Task GetOneCompleteTodoItem()
    {
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        List<Todo>? emptyTodo = await client.GetFromJsonAsync<List<Todo>>("/todoitems/complete");
        var startCount = emptyTodo?.Count();
        using var response = await client.PostAsJsonAsync("/todoitems/", new Todo{
            Name = "My Todo is complete!",
            IsComplete = true
        });
        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        Assert.NotNull(response.Headers.Location);
        Assert.Matches("My Todo is complete!", responseBody);
        List<Todo>? oneTodo = await client.GetFromJsonAsync<List<Todo>>("/todoitems/complete");
        Assert.NotNull(oneTodo);
        Assert.Equal(startCount + 1, oneTodo?.Count());
    }

    [Fact]
    public async Task DeleteOneCompleteTodoItem()
    {
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        List<Todo>? todoList = await client.GetFromJsonAsync<List<Todo>>("/todoitems/");
        var startTodoCount = todoList?.Count();
        using var response = await client.PostAsJsonAsync("/todoitems/", new Todo{
            Name = "My Todo will delete!",
            IsComplete = true
        });
        var responseBody = await response.Content.ReadFromJsonAsync<Todo>();
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        Assert.NotNull(response.Headers.Location);
        Assert.Equal("My Todo will delete!", responseBody?.Name);
        Todo? addedToDoItem = await client.GetFromJsonAsync<Todo>($"/todoitems/{responseBody?.Id}");
        Assert.NotNull(addedToDoItem);
        Assert.Equal("My Todo will delete!", addedToDoItem?.Name);
        var deleteResponse = await client.DeleteAsync($"/todoitems/{addedToDoItem?.Id}");
        Assert.NotNull(deleteResponse);
        Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);
        List<Todo>? currentTodo = await client.GetFromJsonAsync<List<Todo>>("/todoitems/");
        var currentTodoCount = currentTodo?.Count();
        Assert.Equal(startTodoCount, currentTodoCount);
    }

    [Fact]
    public async Task UpdateOneTodoItem()
    {
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        using var response = await client.PostAsJsonAsync("/todoitems/", new Todo{
            Name = "My Todo will update!",
            IsComplete = false
        });
        var responseBody = await response.Content.ReadFromJsonAsync<Todo>();
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        Assert.NotNull(response.Headers.Location);
        Assert.Equal("My Todo will update!", responseBody?.Name);
        var updateResponse = await client.PutAsJsonAsync($"/todoitems/{responseBody?.Id}", new Todo{
            Name = "My Todo is updated!",
            IsComplete = true
        });
        Assert.NotNull(updateResponse);
        Assert.Equal(HttpStatusCode.NoContent, updateResponse.StatusCode);
        Todo? addedToDoItem = await client.GetFromJsonAsync<Todo>($"/todoitems/{responseBody?.Id}");
        Assert.NotNull(addedToDoItem);
        Assert.Equal("My Todo is updated!", addedToDoItem?.Name);
        Assert.Equal(true, addedToDoItem?.IsComplete);
    }
}