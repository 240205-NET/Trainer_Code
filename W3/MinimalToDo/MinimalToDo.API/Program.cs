using Microsoft.EntityFrameworkCore;
using MinimalToDo.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ToDoContext>(opt => opt.UseInMemoryDatabase("ToDoDB"));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// minimal api -> specify the endpoints
app.MapGet("/", () => "Hello World!");

// By creating a Map Group you can simplify the routes you need to write for each method.
// to include something in the MapGroup, just use the group object as the parent of the method
var todoitems = app.MapGroup("/todoitems");

// Christian had asked about just using a method instead of a llambda return. 
// Here's the "minimalist" way to do that without creating more classes...

todoitems.MapGet("/", GetAllTodos); // These are Mapping or Map<HttpVerb> methods (you'll see this in the documentation) 
todoitems.MapGet("/{id}", GetTodoById);


// These methods are called "Handler Methods", as they actually handle the request.
// they're return Tasks (since the Mapping above will call them asynchronously)
// that wrap IResults that are generated when you return the TypedResults object.

// using a method like this IS easier to unit test, and sometimes easier to conceptualize, but... just not as cool.
static async Task<IResult> GetAllTodos(ToDoContext context)
{
    return TypedResults.Ok(await context.ToDos.ToArrayAsync());
}

static async Task<IResult> GetTodoById(int id, ToDoContext context)
{
    return await context.ToDos.FindAsync(id)
        is ToDo todo
        ? TypedResults.Ok(todo)
        : TypedResults.NotFound();
}





//todoitems.MapGet("/", async (ToDoContext context) => await context.ToDos.ToListAsync());

//// here's some cool use of a "one-liner".
//todoitems.MapGet("/{id}", async (int id, ToDoContext context) =>
//    await context.ToDos.FindAsync(id) //This finds an entry from the db...
//        is ToDo todo // checks that it is of ToDo type...
//            ? Results.Ok(todo) // if it is, return it in a 200 repsonse
//            : Results.NotFound() // if it's NOT, return a 404       
//);

todoitems.MapPost("/", async (ToDo todo, ToDoContext context) =>
{
    context.ToDos.Add(todo); // add this thing to the database...
    await context.SaveChangesAsync(); // and save this change to the database.
    return Results.Created($"/todoitems/{todo.Id}", todo); // 201
    // Results.NoContent(); // 204
    // Results.NotFount(); // 404
    // Results.Ok(); // 200
});

todoitems.MapPut("/{id}", async (int id, ToDo newTodo, ToDoContext context) =>
{
    var todo = await context.ToDos.FindAsync(id); // Get the entry from the database...

    if (todo is null) return Results.NotFound(); // Check if it's null, if it is return a 404, otherwise...

    todo.Name = newTodo.Name; //update the name to the new name...
    todo.Complete = newTodo.Complete; // and the completion status to the new status.

    await context.SaveChangesAsync(); // Save those modifications to the database
    return Results.NoContent(); // and return a 204 (OK, but no content to return).
});

todoitems.MapDelete("/{id}", async (int id, ToDoContext context) =>
{
    if (await context.ToDos.FindAsync(id) is ToDo toDo) // if an entry is found in the database that matches this id, hold onto that entry in toDo
    {
        context.ToDos.Remove(toDo); // remove the entry from the database that matches the toDo object
        await context.SaveChangesAsync(); // save that change to the database
        return Results.NoContent(); // return a 204
    }
    // "ELSE"
    return Results.NotFound(); // in the event that the if is false, and skips deleting anything, just return a 404.
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();