var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:8000");

var app = builder.Build();

int resultado = 0;

app.MapGet("/", () => {
    return  new { mensagem= "API em execução"};
});

// Aula de SWITCH
app.MapGet("/calcula/{opcao}/{valor1}/{valor2}", (int opcao, int valor1, int valor2) => {
   switch (opcao)
    {
        case 1:
            resultado = valor1 + valor2;
            return Results.Ok(new
            {
                operacao = "soma",
                valor1,
                valor2,
                resultado
            });

        case 2:
            resultado =  valor1 - valor2;
            return Results.Ok(new
            {
                operacao = "subtracao",
                valor1,
                valor2,
                resultado 
            });

        case 3:
            resultado =  valor1 * valor2;
            return Results.Ok(new
            {
                operacao = "multiplicacao",
                valor1,
                valor2,
                resultado 
            });

        case 4:            
            if (valor2 == 0)
            {
                return Results.BadRequest(new
                {
                    erro = "Não é possível realizar divisão por zero."
                });
            }

            resultado = valor1 / valor2;
            return Results.Ok(new
            {
                operacao = "divisao",
                valor1,
                valor2,
                resultado 
            });
        
        default:
            return Results.BadRequest(new
            {
                erro = "Operação inválida. Utilize: soma, subtracao, multiplicacao ou divisao."
            });
    }
});

//AULA QUE FOI DEPOIS DA DE SWITCH
app.MapGet("/calcula/soma/{valor1}/{valor2}", (int valor1, int valor2) => {
    resultado = valor1 + valor2;
            return Results.Ok(new
            {
                valor1,
                valor2,
                resultado
            });
    });

app.MapGet("/calcula/subtracao/{valor1}/{valor2}", (int valor1, int valor2) => {  
    resultado =  valor1 - valor2;
            return Results.Ok(new
            {
                valor1,
                valor2,
                resultado 
            });
    });

app.MapGet("/calcula/multiplicacao/{valor1}/{valor2}", (int valor1, int valor2) => {  
    resultado =  valor1 * valor2;
            return Results.Ok(new
            {
                valor1,
                valor2,
                resultado 
            });
    });

app.MapGet("/calcula/divisao/{valor1}/{valor2}", (int valor1, int valor2) => {  
    resultado = valor1 / valor2;
            return Results.Ok(new
            {
                valor1,
                valor2,
                resultado 
            });
    });

app.Run();