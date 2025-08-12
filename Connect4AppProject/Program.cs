// See https://aka.ms/new-console-template for more information

using ConsoleApp;
using ConsoleApp.connect_four;
using ConsoleApp.connect_four.paths;
using ConsoleApp.connect_four.paths.Columns;
using ConsoleApp.connect_four.paths.Rows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = Host.CreateApplicationBuilder(args);
var columns = 7;
var rows = 6;
builder.Services.AddScoped<RowFactory>();
builder.Services.AddScoped<RowsCollection>(serviceProvider =>
{
    var rowFactory = serviceProvider.GetService<RowFactory>()!;
    return new RowsCollection(rows , rowFactory);
});
builder.Services.AddScoped<ColumnFactory>();
builder.Services.AddScoped<ColumnsCollection>(serviceProvider =>
{
    var columnFactory = serviceProvider.GetService<ColumnFactory>()!;
    return new ColumnsCollection(columns , columnFactory);
});
builder.Services.AddScoped<DiagonalFactory>();

builder.Services.AddScoped<DiagonalTree>((serviceProvider) =>
{
    return new DiagonalTree(totalRows: rows , totalColumns: columns , serviceProvider.GetService<DiagonalFactory>()!);
});

builder.Services.AddScoped<Connect4Matrix>((_) => new Connect4Matrix(rows, columns));
builder.Services.AddScoped<Match>();
builder.Services.AddSingleton<Game>();

var host = builder.Build();

Game connectFour = host.Services.GetRequiredService<Game>();

connectFour.StartGame();
connectFour.RestartGame();
